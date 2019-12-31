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
    public interface ICom
    {
        AbstractActor actor
        {
            get;
        }

        int comOrder
        {
            get;
        }

        //自身的初始化工作
        void AwakeCom(AbstractActor actor);
        //和其它组件有关的初始化工作
        void OnComStart();
        void OnComEnable();
        void OnComUpdate(float dt);
        void OnComLateUpdate(float dt);
        void OnComDisable();
        void DestroyCom();
    }
}
