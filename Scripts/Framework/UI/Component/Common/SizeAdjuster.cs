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
    public class SizeAdjuster : MonoBehaviour
    {
        [SerializeField]
        private RectTransform m_Target;
        [SerializeField]
        private Vector2 m_Offset;

        private RectTransform m_SelfTransform;

        private void Awake()
        {
            m_SelfTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (m_Target == null)
            {
                return;
            }

            Vector2 size = m_Target.rect.size + m_Offset;
            m_SelfTransform.sizeDelta = size;
        }
    }
}
