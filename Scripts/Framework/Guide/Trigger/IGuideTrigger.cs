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
    public interface ITrigger
    {
        bool isReady { get; }
		void SetParam(object[] param);
        void Start(Action<bool, ITrigger> l);
        void Stop();
    }
}
