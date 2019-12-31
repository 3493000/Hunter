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
    public class WorldUIBindPos : WorldUI
    {
        [SerializeField]
        private Vector3 m_FollowPosition;

        public Vector3 followPosition
        {
            get { return m_FollowPosition; }
            set { m_FollowPosition = value; UpdateBinding(); }
        }

        protected override bool IsNeedUpdate()
        {
            return IsWorldPositionInView(m_FollowPosition);
        }

        protected override void OnWorldUIBinding()
        {
            if (m_Binding == null)
            {
                m_Binding = new WorldUIBinding();
            }

            m_Binding.Set(m_TargetUI, m_FollowPosition, m_UIOffset, m_WorldOffset);
        }
    }
}
