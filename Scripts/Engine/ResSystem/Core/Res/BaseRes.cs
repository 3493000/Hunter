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
    public class BaseRes : AbstractRes
    {
        public BaseRes(string name) : base(name)
        {
        }

        public BaseRes()
        {

        }

        protected override void OnReleaseRes()
        {
            //如果Image 直接释放了，这里会直接变成NULL
            if (m_Asset != null)
            {
                if (m_Asset is GameObject)
                {

                }
                else
                {
                    //ResMgr.S.timeDebugger.Begin("Unload AssetRes:" + m_Name);
                    Resources.UnloadAsset(m_Asset);
                    //ResMgr.S.timeDebugger.End();
                }

                m_Asset = null;
            }
        }
    }
}
