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

namespace Hunter.Editor
{
    public class AssetFileFilter
    {
        public static bool IsAsset(string fileName)
        {
            if (fileName.EndsWith(".meta") || fileName.EndsWith(".gaf") || fileName.EndsWith(".DS_Store"))
            {
                return false;
            }
            return true;
        }

		public static bool IsAssetBundle(string fileName)
		{
			if (fileName.EndsWith(".bundle"))
			{
				return true;
			}
			return false;
		}

        public static bool IsConfigTable(string fileName)
        {
            if (fileName.EndsWith(".txt"))
            {
                return true;
            }
            return false;
        }
    }
}
