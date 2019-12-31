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
    public interface IRefCounter
    {
        int refCount
        {
            get;
        }

        void AddRef();
        void SubRef();
    }

    public class RefCounter : IRefCounter
    {
        private int m_RefCount = 0;

        public int refCount
        {
            get { return m_RefCount; }
        }

        public void AddRef() { ++m_RefCount; }
        public void SubRef()
        {
            --m_RefCount;
            if (m_RefCount == 0)
            {
                OnZeroRef();
            }
        }

        protected virtual void OnZeroRef()
        {

        }
    }
}
