﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Hunter.Editor
{
    public class ABConfigUnit
    {
        private string m_FolderAssetPath;
        public int m_ABFlag = ABFlagDefine.FOLDER;
        public string folderAssetPath
        {
            get { return m_FolderAssetPath; }
            set { m_FolderAssetPath = value; }
        }

        public int abFlag
        {
            get { return m_ABFlag; }
            set { m_ABFlag = value; }
        }

        public bool isFolderFlag
        {
            get { return m_ABFlag == ABFlagDefine.FOLDER; }
            set
            {
                if (value)
                {
                    m_ABFlag = ABFlagDefine.FOLDER;
                }
                else
                {
                    m_ABFlag = ABFlagDefine.FILE;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Folder:{0}, TagMode:{1}", m_FolderAssetPath, m_ABFlag);
        }
    }
}
