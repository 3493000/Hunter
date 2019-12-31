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
    public class FloatMessage : TSingleton<FloatMessage>
    {
        public void ShowMsg(string msg)
        {
            FloatMessagePanel fP = UIMgr.S.FindPanel(EngineUI.FloatMessagePanel) as FloatMessagePanel;
            if (fP != null)
            {
                fP.ShowMsg(msg);
                return;
            }

            UIMgr.S.OpenPanel(EngineUI.FloatMessagePanel, (panel) =>
            {
                FloatMessagePanel panel1 = panel as FloatMessagePanel;
                panel1.ShowMsg(msg);
            });
        }

        public void ShowLightMsg(string msg)
        {
            FloatMessagePanel fP = UIMgr.S.FindPanel(EngineUI.LightMessagePanel) as FloatMessagePanel;
            if (fP != null)
            {
                fP.ShowMsg(msg);
                return;
            }

            UIMgr.S.OpenPanel(EngineUI.LightMessagePanel, (panel) =>
            {
                FloatMessagePanel panel1 = panel as FloatMessagePanel;
                panel1.ShowMsg(msg);
            });
        }
    }
}
