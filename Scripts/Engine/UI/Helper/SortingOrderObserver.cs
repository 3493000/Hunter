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
using Hunter;

namespace Hunter
{
    public class SortingOrderObserver : MonoBehaviour
    {
        [SerializeField]
        private Canvas m_TargetCanvas;
        [SerializeField]
        private int m_OrderOffset;
        [SerializeField]
        private Renderer m_Renderer;

        public virtual void OnSortingOrderUpdate()
        {
            if (m_Renderer == null || m_TargetCanvas == null)
            {
                return;
            }

            m_Renderer.sortingOrder = m_TargetCanvas.sortingOrder + m_OrderOffset;
        }
    }
}
