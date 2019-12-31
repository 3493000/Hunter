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
    [AttributeUsage(AttributeTargets.Class)]
    public class TMonoSingletonAttribute : System.Attribute
    {
        private string m_AbsolutePath;

        public TMonoSingletonAttribute(string relativePath)
        {
            m_AbsolutePath = relativePath;
        }

        public string AbsolutePath
        {
            get { return m_AbsolutePath; }
        }
    }
}
