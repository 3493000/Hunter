﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Hunter
{
    public partial class TDLanguage
    {
        private string m_Id;
        private string m_Value;
        private static int m_Index;

        // 主键
        public string id { get { return m_Id; } }

        // 当前值
        public string value
        {
            get
            {
                return m_Value;
            }
        }

        public void ReadRow(DataStreamReader dataR, int[] filedIndex)
        {
            dataR.MoreFieldOnRow();
            m_Id = dataR.ReadString();
            if (dataR.MoreFieldOnRow() != -1)
            {
                m_Value = dataR.ReadString().Replace("\\n", "\n");
            }
            else
            {
                m_Value = string.Empty;
            }


        }
    }
}//namespace LR
