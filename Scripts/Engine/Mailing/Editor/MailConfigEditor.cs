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
    public class MailConfigEditor
    {
        [MenuItem("Assets/Hunter/Config/Build MailConfig")]
        public static void BuildMailConfig()
        {
            MailConfig data = null;
            string folderPath = EditorUtils.GetSelectedDirAssetsPath();
            string dataPath = folderPath + "/MailConfig.asset";

            data = AssetDatabase.LoadAssetAtPath<MailConfig>(dataPath);
            if (data == null)
            {
                data = ScriptableObject.CreateInstance<MailConfig>();
                AssetDatabase.CreateAsset(data, dataPath);
            }
            Log.i("Create Mail Config In Folder:" + dataPath);
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
        }
    }
}
