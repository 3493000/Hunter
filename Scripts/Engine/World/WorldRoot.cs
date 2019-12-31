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
    public class WorldRoot : MonoBehaviour
    {
        [SerializeField]
        private Camera m_WorldCamera;
        [SerializeField]
        private Transform m_EnvironmentRoot;

        public Camera worldCamera
        {
            get { return m_WorldCamera; }
        }

        public Transform environmentRoot
        {
            get { return m_EnvironmentRoot; }
        }
    }
}
