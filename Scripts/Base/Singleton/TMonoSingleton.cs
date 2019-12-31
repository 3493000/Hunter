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
    public abstract class TMonoSingleton<T> : MonoSingleton, ISingleton where T : TMonoSingleton<T>
    {
        private static T        m_Instance = null;
        private static object   s_lock = new object();


        public static T S
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (s_lock)
                    {
                        if (m_Instance == null)
                        {
                            m_Instance = CreateMonoSingleton<T>();
                        }
                    }
                }

                return m_Instance;
            }
        }

        public virtual void OnSingletonInit() { }

    }
}
