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
using System.Threading;

namespace Hunter
{
    public class ThreadHandler : IThreadHandler
    {
        protected Thread        m_Thread;
        protected string        m_ThreadName;
        protected TaskLoop      m_TaskLoop = new TaskLoop();
        protected bool          m_IsRunning = true;

        private AutoResetEvent m_ResetEvent = new AutoResetEvent(false);

        public bool isRunning
        {
            get { return m_IsRunning; }
            set
            {
                if (m_IsRunning == value)
                {
                    return;
                }

                m_IsRunning = value;

                m_ResetEvent.Set();
            }
        }

        public void PostTask(IThreadTask task)
        {
            if (!m_IsRunning)
            {
                Log.w("Work Thread Not Start.");
                return;
            }

            m_TaskLoop.PostTask(task);
            m_ResetEvent.Set();
        }

        public void PostAction(Action action)
        {
            if (!m_IsRunning)
            {
                Log.w("Work Thread Not Start.");
                return;
            }

            m_TaskLoop.PostAction(action);
            m_ResetEvent.Set();
        }

        public ThreadHandler(string threadName)
        {
            if (m_Thread != null)
            {
                return;
            }

            if (m_Thread == null)
            {
                m_ThreadName = threadName;
                
                m_Thread = new Thread(LoopFunc);
                m_Thread.Start();
            }
        }

        private void LoopFunc()
        {
            while (m_IsRunning)
            {
                if (!m_TaskLoop.OnceLoop())
                {
                    m_ResetEvent.WaitOne();
                }
            }
        }
    }
}
