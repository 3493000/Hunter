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
    public class AppConfigEditor
    {
        [MenuItem("Assets/Hunter/Config/Build AppConfig")]
        public static void BuildAppConfig()
        {

            AppConfig data = null;
            string folderPath = EditorUtils.GetSelectedDirAssetsPath();
            string spriteDataPath = folderPath + "/AppConfig.asset";

            data = AssetDatabase.LoadAssetAtPath<AppConfig>(spriteDataPath);
            if (data == null)
            {
                data = ScriptableObject.CreateInstance<AppConfig>();
                AssetDatabase.CreateAsset(data, spriteDataPath);
            }
            Log.i("Create App Config In Folder:" + spriteDataPath);
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
        }
    }
}
