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
    public class LuaPanel : AbstractPanel
    {
        [SerializeField]
        private string m_LuaSciptName;

        protected override void OnUIInit()
        {
            InitLuaBind();
        }

        protected void InitLuaBind()
        {

        }
    }
}
