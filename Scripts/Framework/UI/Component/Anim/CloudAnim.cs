﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public class CloudAnim : MonoBehaviour
    {
        [SerializeField]
        private Rect m_Rect;
        [SerializeField]
        private float m_SpeedX = 10;

        private float m_R = 5;
        private float m_BaseY;
        private float m_CurrentSpeed;

        private Vector3 m_OriPosition;

        private void Awake()
        {
            m_OriPosition = transform.localPosition;
            RandomPath(true);
        }

        private void RandomPath(bool ori)
        {
            //确定速度方向
            int dir = RandomHelper.Range(0, 10);
            int speed = (int)RandomHelper.Range(30, m_SpeedX);
            m_BaseY = m_OriPosition.y + RandomHelper.Range(10, 100);

            if (dir > 5)
            {
                if (!ori)
                {
                    transform.localPosition = new Vector3(m_Rect.xMax, m_BaseY, 0);
                }
                m_CurrentSpeed = -speed;
            }
            else
            {
                if (!ori)
                {
                    transform.localPosition = new Vector3(m_Rect.xMax, m_BaseY, 0);
                }
                m_CurrentSpeed = speed;
            }

            m_R = RandomHelper.Range(15, m_Rect.height);
        }

        private void Update()
        {
            Vector3 currentPos = transform.localPosition;
            currentPos.x += m_CurrentSpeed * Time.deltaTime;
            currentPos.y = m_BaseY + Mathf.Sin(currentPos.x * 0.03f) * m_R;

            transform.localPosition = currentPos;

            if (currentPos.x > m_Rect.xMax || currentPos.x < m_Rect.xMin)
            {
                RandomPath(false);
            }
        }
    }
}
