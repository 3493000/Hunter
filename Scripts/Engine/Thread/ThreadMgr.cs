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
    public class ThreadMgr : TSingleton<ThreadMgr>
    {
        private ThreadHandler m_WorkThread;
        private MainThreadHandler m_MainThread;

        public override void OnSingletonInit()
        {
            m_MainThread = MainThreadHandler.S;
            m_WorkThread = new ThreadHandler("WorkThread");
        }

        public void Init()
        {

        }

        public IThreadHandler workThread
        {
            get { return m_WorkThread; }
        }

        public IThreadHandler mainThread
        {
            get { return m_MainThread; }
        }

    }
}
