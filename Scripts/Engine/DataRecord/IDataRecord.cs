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
    public interface IDataRecord
    {
        void Init();
        void Reset();
        void Save();

        bool GetBool(string key, bool defaultValue = false);

        string GetString(string key, string defaultValue = "");

        float GetFloat(string key, float defaultValue = 0);

        int GetInt(string key, int defaultValue = 0);

        void SetString(string key, string value);

        void SetBool(string key, bool value);

        void SetFloat(string key, float value);

        void SetInt(string key, int value);

        void AddInt(string key, int offset);
    }

    public class DataRecord
    {
        private static IDataRecord s_Record;

        public static IDataRecord S
        {
            get
            {
                if (s_Record == null)
                {
                    s_Record = new DataRecord_Default();
                    s_Record.Init();
                }
                return s_Record;
            }
        }

        public static void SetInstance(IDataRecord record)
        {
            if (record == null)
            {
                return;
            }

            s_Record = record;
        }
    }
}
