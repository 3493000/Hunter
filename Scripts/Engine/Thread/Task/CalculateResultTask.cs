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
    public class CalculateResultTask : AbstractTask
    {
        protected IThreadHandler m_SourceThread;

        public CalculateResultTask(IThreadHandler sourceThread)
        {
            m_SourceThread = sourceThread;
        }

        protected void SendResult()
        {
            if (m_SourceThread == null)
            {
                return;
            }

            m_SourceThread.PostTask(new ResultTask(this));
        }

        public override void ProcessResult()
        {

        }
    }
}
