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
using UnityEditor;

namespace Hunter
{
    [CustomEditor(typeof(RaycastArea), false)]
    [CanEditMultipleObjects]
    public class RaycastAreaEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

        }
    }
}
