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
    //面板管理的内部事件
    public enum ViewEvent
    {
        MIN = 0,
        Action_ClosePanel,
        Action_HidePanel,
        Action_ShowPanel,
        OnPanelOpen,
        OnPanelClose,
        OnParamUpdate,
        OnSortingLayerUpdate,
        DumpTest,
    }

    public interface IView
    {

    }

    public interface IViewDelegate
    {

    }
}
