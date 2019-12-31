//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System.Collections;

namespace Hunter
{
    public class TSingleton<T> : ISingleton where T : TSingleton<T>, new()
	{
		protected static T		m_Instance;
        protected static object s_lock = new object();

        public static T S
		{
			get
			{
				if(m_Instance == null)
				{
                    lock (s_lock)
                    {
                        if (m_Instance == null)
                        {
                            m_Instance = new T();
                            m_Instance.OnSingletonInit();
                        }
                    }
				}
				return m_Instance;
			}
		}

        public static T ResetInstance()
        {
            m_Instance = new T();
            m_Instance.OnSingletonInit();
            return m_Instance;
        }

        public virtual void OnSingletonInit()
        {
        }
	}
}
