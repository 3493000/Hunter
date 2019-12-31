﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;

namespace Hunter
{
    public class DisposableObject : IDisposable
    {
        private Boolean     m_Disposed = false;

        ~DisposableObject()
        {
            Dispose(false);
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Overrides it, to dispose managed resources.
        protected virtual void DisposeGC() { }

        // Overrides it, to dispose unmanaged resources
        protected virtual void DisposeNGC() { }

        private void Dispose(Boolean disposing)
        {
            if (m_Disposed)
            {
                return;
            }

            if (disposing)
            {
                DisposeGC();
            }

            DisposeNGC();

            m_Disposed = true;
        }
    }
}
