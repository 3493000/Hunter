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
    public enum EngineEventID
    {
        EngineEventIDMin = 1000000,
        OnPanelUpdate,

        OnApplicationFocusChange,
        OnApplicationPauseChange,
        OnAfterApplicationPauseChange,
        OnAfterApplicationFocusChange,

        OnApplicationQuit,

        BackKeyDown,
        OnShare2Social,
        OnAchievementComplate,
        OnAchievementFinish,

        OnDateUpdate,//日期更新
        OnSignStateChange,

        OnShareCaptureBegin,
        OnShareCaptureEnd,
        OnLanguageChange,
        OnLanguageTableSwitchFinish,
        OnNeedShowBanner,
        OnNeedHideBanner,
        ///////////////
    }
}
