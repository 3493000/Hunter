﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Hunter
{
    public class HotUpdateRes : AbstractRes, IDownloadTask
    {
		public const string PREFIX_KEY = "HotUpdateRes:";
        private string  m_Url;
        private int     m_TotalSize = 1;
        private int     m_DownloadSize;
        private string  m_LocalPath;
        private int     m_FileSize;
        private OnDownloadValidCheck m_Checker;

        public static HotUpdateRes Allocate(string name)
        {
            HotUpdateRes res = ObjectPool<HotUpdateRes>.S.Allocate();
            if (res != null)
            {
                res.name = name;
            }
            return res;
        }

        public void SetUpdateInfo(string localPath, string url, int fileSize, OnDownloadValidCheck checker)
        {
            m_LocalPath = localPath;
            m_Url = url;
            m_FileSize = fileSize;
            m_Checker = checker;
        }

        public string localResPath
        {
            get
            {
                return m_LocalPath;
            }
        }

        public bool logError
        {
            get { return false; }
        }

        public void SetDownloadProgress(int totalSize, int download)
        {
            m_TotalSize = totalSize + 1;
            m_DownloadSize = download;
            //Log.i(string.Format("#>> {0}:{1}", m_Name, CalculateProgress()));
        }

        public bool needDownload
        {
            get
            {
                return refCount > 0;
            }
        }

        public string url
        {
            get
            {
                return m_Url;
            }
        }

        public int fileSize
        {
            get
            {
                return m_FileSize;
            }
        }

        public override bool UnloadImage(bool flag)
        {
            return false;
        }

        public override bool LoadSync()
        {
            return false;
        }

        public override void LoadAsync()
        {
            if (!CheckLoadAble())
            {
                return;
            }

            if (string.IsNullOrEmpty(m_Url))
            {
                return;
            }

            if (string.IsNullOrEmpty(m_LocalPath))
            {
                return;
            }

            DoLoadWork();
        }

        private void DoLoadWork()
        {
            resState = eResState.kLoading;

            m_DownloadSize = 0;
            m_TotalSize = 1;
            //OnDownLoadResult(true);

            
            if (File.Exists(localResPath))
            {
                //如果cache中文件存在，则删除,避免断点续传
                File.Delete(localResPath);
            }

            ResDownloader.S.AddDownloadTask(this);
        }

        protected override void OnReleaseRes()
        {
            ResDownloader.S.RemoveDownloadTask(this);
        }

        public override void Recycle2Cache()
        {
            ObjectPool<HotUpdateRes>.S.Recycle(this);
        }

        public override void OnCacheReset()
        {
            m_LocalPath = null;
            m_Url = null;
            m_Checker = null;
        }

        public void DeleteOldResFile()
        {
            //throw new NotImplementedException();
        }

        public void OnDownLoadResult(bool result)
        {
            if (!result)
            {
                OnResLoadFaild();
                return;
            }

            if (refCount <= 0)
            {
                resState = eResState.kWaiting;
                return;
            }

            resState = eResState.kReady;
        }

        public bool OnValidCheck(byte[] raw)
        {
            if (m_Checker != null)
            {
                return m_Checker(raw);
            }

            return true;
        }

        protected override float CalculateProgress()
        {
            return m_DownloadSize / (float)m_TotalSize;
        }
    }
}
