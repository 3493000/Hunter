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

namespace Hunter
{
    public class ResFactory
    {
        public delegate IRes ResCreator(string name);

        public interface IResCreatorWrap
        {
            bool CheckResType(string name);
            IRes CreateRes(string name);
        }

        class ResCreatorWrap : IResCreatorWrap
        {
            private string m_Key;
            private ResCreator m_Creator;

            public ResCreatorWrap(string key, ResCreator creator)
            {
                m_Key = key;
                m_Creator = creator;
            }

            public bool CheckResType(string name)
            {
                return name.StartsWith(m_Key);
            }

            public IRes CreateRes(string name)
            {
                return m_Creator(name);
            }
        }

        class AssetResCreatorWrap : IResCreatorWrap
        {
            public IRes CreateRes(string name)
            {
                AssetData data = AssetDataTable.S.GetAssetData(name);

                switch (data.assetType)
                {
                    case eResType.kAssetBundle:
                        return AssetBundleRes.Allocate(name);
                    case eResType.kABAsset:
                        return AssetRes.Allocate(name);
                    case eResType.kABScene:
                        return SceneRes.Allocate(name);
                    default:
                        return null;
                }
            }

            public bool CheckResType(string name)
            {
                AssetData data = AssetDataTable.S.GetAssetData(name);

                return data != null;
            }
        }

        private static List<IResCreatorWrap> s_CreatorList;
        private static IResCreatorWrap s_AssetResCreatorWrap;

        static ResFactory()
        {
            Log.i("Init[ResFactory]");
            ObjectPool<AssetBundleRes>.S.maxCacheCount = 20;
            ObjectPool<AssetRes>.S.maxCacheCount = 40;
            ObjectPool<InternalRes>.S.maxCacheCount = 40;
            ObjectPool<NetImageRes>.S.maxCacheCount = 20;
            ObjectPool<LocalAudioRes>.S.maxCacheCount = 5;

            s_CreatorList = new List<IResCreatorWrap>();

            s_AssetResCreatorWrap = new AssetResCreatorWrap();

			RegisterResCreate(InternalRes.PREFIX_KEY, InternalRes.Allocate);
			RegisterResCreate(NetImageRes.PREFIX_KEY, NetImageRes.Allocate);
            RegisterResCreate(NetTextRes.PREFIX_KEY, NetTextRes.Allocate);
            RegisterResCreate(HotUpdateRes.PREFIX_KEY, HotUpdateRes.Allocate);
            RegisterResCreate(LocalAudioRes.PREFIX_KEY, LocalAudioRes.Allocate);
        }

        public static void RegisterResCreate(string key, ResCreator creator)
        {
            if (creator == null || string.IsNullOrEmpty(key))
            {
                Log.e("Register InValid Creator.");
                return;
            }

            RegisterResCreateWarp(new ResCreatorWrap(key, creator));
        }

        public static void RegisterResCreateWarp(IResCreatorWrap wrap)
        {
            if (wrap == null)
            {
                Log.e("Register InValid Wrap.");
                return;
            }

            s_CreatorList.Add(wrap);
        }

        public static IRes Create(string name)
        {
            if (s_AssetResCreatorWrap.CheckResType(name))
            {
                return s_AssetResCreatorWrap.CreateRes(name);
            }
            else
            {
                for (int i = s_CreatorList.Count - 1; i >= 0; --i)
                {
                    if (s_CreatorList[i].CheckResType(name))
                    {
                        return s_CreatorList[i].CreateRes(name);
                    }
                }
            }
            Log.e("Not Find ResCreate For Res:" + name);
            return null;
        }

        public static IRes Create(string name, short assetType)
        {
            switch (assetType)
            {
                case eResType.kAssetBundle:
                    return AssetBundleRes.Allocate(name);
                case eResType.kABAsset:
                    return AssetRes.Allocate(name);
                case eResType.kABScene:
                    return SceneRes.Allocate(name);
                case eResType.kInternal:
                    return InternalRes.Allocate(name);
                case eResType.kNetImageRes:
                    return NetImageRes.Allocate(name);
                case eResType.kHotUpdateRes:
                    return HotUpdateRes.Allocate(name);
                default:
                    Log.e("Invalid assetType :" + assetType);
                    return null;
            }
        }
    }
}
