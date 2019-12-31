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
using System.IO;
using UnityEditor;

namespace Hunter.Editor
{
    [CustomEditor(typeof(ProjectPathConfig), false)]
    public class ProjectPathConfigEditor : UnityEditor.Editor
    {
        [MenuItem("Assets/Hunter/Config/Build ProjectConfig")]
        public static void BuildProjectConfig()
        {

            ProjectPathConfig data = null;
            string folderPath = EditorUtils.GetSelectedDirAssetsPath();
            string spriteDataPath = folderPath + "/ProjectConfig.asset";

            data = AssetDatabase.LoadAssetAtPath<ProjectPathConfig>(spriteDataPath);
            if (data == null)
            {
                data = ScriptableObject.CreateInstance<ProjectPathConfig>();
                AssetDatabase.CreateAsset(data, spriteDataPath);
            }
            Log.i("Create Project Config In Folder:" + spriteDataPath);
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Sync"))
            {
                ProjectPathConfig.Reset();
            }
        }
    }
}
