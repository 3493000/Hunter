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
    [TMonoSingletonAttribute("[Singleton]/Mgr")]
    public class WorldMgr : TMonoSingleton<WorldMgr>
    {
        private WorldRoot m_WorldRoot;

        public WorldRoot worldRoot
        {
            get { return m_WorldRoot; }
        }

        public override void OnSingletonInit()
        {
            if (m_WorldRoot == null)
            {
                WorldRoot root = GameObject.FindObjectOfType<WorldRoot>();
                if (root == null)
                {
                    Log.e("Failed to Find WorldRoot!");
                    return;
                }

                m_WorldRoot = root;
            }
        }
    }
}
