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
    public interface IInputter
    {
        bool isEnabled
        {
            get;
            set;
        }
        void RegisterKeyCodeMonitor(KeyCode code, Run begin, Run end, Run press);
        void Release();
        void LateUpdate();
    }
}

