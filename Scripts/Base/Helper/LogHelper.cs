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
    public class LogHelper
    {
        public static void LogArray(string[] value)
        {
            if (value == null || value.Length == 0)
            {
                return;
            }

            for (int i = 0; i < value.Length; ++i)
            {
                Log.i(value[i]);
            }
        }
    }
}
