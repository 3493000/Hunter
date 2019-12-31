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
    public class MainThreadHandler : TMonoSingleton<MainThreadHandler>, IThreadHandler
    {
        protected TaskLoop m_TaskLoop = new TaskLoop();

        public void PostTask(IThreadTask task)
        {
            m_TaskLoop.PostTask(task);
        }

        public void PostAction(Action action)
        {
            m_TaskLoop.PostAction(action);
        }

        public void Dump()
        {

        }

        private void Update()
        {
            m_TaskLoop.OnceLoop();
        }
    }
}
