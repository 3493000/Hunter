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
    public interface ITransitionAction
    {
        ITransitionHandler transitionHandler
        {
            get;
            set;
        }

        bool transitionSameTime
        {
            get;
        }

        void PrepareTransition();
        void TransitionIn(AbstractPanel panel);
        void TransitionOut(AbstractPanel panel);

        void OnTransitionDestroy();

        void OnNextPanelReady();
    }

}
