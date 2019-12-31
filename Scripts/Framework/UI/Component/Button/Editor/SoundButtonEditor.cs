﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hunter;
using UnityEditor.UI;
using UnityEditor;

namespace Hunter
{
    [CustomEditor(typeof(SoundButton), true)]
    [CanEditMultipleObjects]
    public class SoundButtonEditor : ButtonEditor
    {
        SerializedProperty m_ClickSoundProperty;
        SerializedProperty m_UseDefaultSoundProperty;
        SerializedProperty m_IsSoundEnableProperty;

        protected override void OnEnable()
        {
            base.OnEnable();

            m_IsSoundEnableProperty = serializedObject.FindProperty("m_IsSoundEnable");
            m_ClickSoundProperty = serializedObject.FindProperty("m_ClickSound");
            m_UseDefaultSoundProperty = serializedObject.FindProperty("m_UseDefaultSound");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space();

            serializedObject.Update();

            EditorGUILayout.PropertyField(m_IsSoundEnableProperty);
            EditorGUILayout.PropertyField(m_ClickSoundProperty);
            EditorGUILayout.PropertyField(m_UseDefaultSoundProperty);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
