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
using UnityEngine.UI;

namespace Hunter
{
    public class ScrollRectProtect : MonoBehaviour
    {
        [SerializeField]
        private ScrollRect m_Rect;

        private void Awake()
        {
            if (m_Rect == null)
            {
                m_Rect = GetComponent<ScrollRect>();
            }
        }

        private void Update()
        {
            bool isDirty = false;
            var pos = m_Rect.normalizedPosition;

            if (pos.y > 1.0f)
            {
                isDirty = true;
                pos.y = 1;
            }
            else if (pos.y < 0)
            {
                isDirty = true;
                pos.y = 0;
            }

            if (pos.x < 0)
            {
                isDirty = true;
                pos.x = 0;
            }
            else if (pos.x > 1.0f)
            {
                isDirty = true;
                pos.x = 1;
            }

            if (isDirty)
            {
                m_Rect.normalizedPosition = pos;
            }
        }
    }
}
