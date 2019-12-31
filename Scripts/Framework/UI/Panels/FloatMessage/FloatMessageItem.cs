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
using UnityEngine.UI;

namespace Hunter
{
    public class FloatMessageItem : MonoBehaviour
    {
        [SerializeField]
        private Text m_Text;

        public void SetFloatMsg(FloatMsg msg)
        {
            if (msg == null)
            {
                return;
            }

            m_Text.text = msg.message;
        }
    }
}
