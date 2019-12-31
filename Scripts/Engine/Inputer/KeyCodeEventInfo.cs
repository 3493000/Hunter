//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunter
{
    public class KeyCodeEventInfo
    {
        private bool m_IsProcess = false;

        public void Process()
        {
            m_IsProcess = true;
        }

        public bool IsProcess()
        {
            return m_IsProcess;
        }

        public void Reset()
        {
            m_IsProcess = false;
        }

    }
}
