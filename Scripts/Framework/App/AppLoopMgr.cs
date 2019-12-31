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
    [TMonoSingletonAttribute("[App]/AppLoopMgr")]
    public class AppLoopMgr : TMonoSingleton<AppLoopMgr>
    {
        public event Action onUpdate;

        private void Update()
        {
            if (onUpdate != null)
            {
                try
                {
                    onUpdate();
                }
                catch (Exception e)
                {
                    Log.e(e);
                }
            }
        }
    }
}
