//  Desc:        Framework For Game Develop with Unity3d
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
    public class DefaultLoaderStrategy : IResLoaderStrategy
    {
        public void OnAllTaskFinish(IResLoader loader)
        {

        }

        public void OnAsyncLoadFinish(IResLoader loader, AssetRes res)
        {

        }

        public void OnAsyncLoadFinish(IResLoader loader, AssetBundleRes res)
        {

        }

        public void OnAsyncLoadFinish(IResLoader loader, InternalRes res)
        {

        }

        public void OnAsyncLoadFinish(IResLoader loader, IRes res)
        {

        }

        public void OnSyncLoadFinish(IResLoader loader, InternalRes res)
        {

        }

        public void OnSyncLoadFinish(IResLoader loader, AssetRes res)
        {

        }

        public void OnSyncLoadFinish(IResLoader loader, AssetBundleRes res)
        {

        }

        public void OnSyncLoadFinish(IResLoader loader, IRes res)
        {

        }
    }
}
