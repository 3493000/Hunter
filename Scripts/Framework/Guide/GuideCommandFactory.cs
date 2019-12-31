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
	public class GuideCommandFactory : TSingleton<GuideCommandFactory>
    {
		public delegate AbstractGuideCommand GuideCommandCreator();
		private Dictionary<string, GuideCommandCreator> m_CreatorMap = new Dictionary<string, GuideCommandCreator>();

		public void RegisterCreator(string name, GuideCommandCreator creator)
		{
			if (m_CreatorMap.ContainsKey(name))
			{
				Log.w ("Already Add Creator for :" + name);
				return;
			}

			m_CreatorMap.Add (name, creator);
		}


		public AbstractGuideCommand Create(string name)
		{
			GuideCommandCreator creator = null;
			if (m_CreatorMap.TryGetValue(name, out creator))
			{
				return creator ();
			}

			return null;
		}
    }
}
