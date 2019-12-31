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
using DG.Tweening;

namespace Hunter
{
    public class FlipAnim : MonoBehaviour
    {
        [SerializeField]
        private Transform m_FrontPage;
        [SerializeField]
        private Transform m_BackPage;

        public void FlipPage(Ease easeType, float duration = 0.3f)
        {
            m_FrontPage.localScale = new Vector3(1, 1, 1);
            m_BackPage.localScale = new Vector3(0, 1, 1);
            m_FrontPage.DOScaleX(0, duration).SetEase(easeType);
            m_BackPage.DOScaleX(1, duration).SetEase(easeType).SetDelay(duration);

            var temp = m_FrontPage;
            m_FrontPage = m_BackPage;
            m_BackPage = temp;
        }

        public void FlipPage()
        {
            m_FrontPage.localScale = new Vector3(1, 1, 1);
            m_BackPage.localScale = new Vector3(0, 1, 1);
            m_FrontPage.DOScaleX(0, 0.3f);
            m_BackPage.DOScaleX(1, 0.3f).SetDelay(0.3f);

            var temp = m_FrontPage;
            m_FrontPage = m_BackPage;
            m_BackPage = temp;

        }
    }
}
