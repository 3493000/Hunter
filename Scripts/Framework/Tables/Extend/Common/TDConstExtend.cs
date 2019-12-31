//  Desc:        Framework For Game Develop with Unity3d
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

    public partial class TDConst
    {
        public void Reset()
        {
            m_IntVal = Helper.String2Int(m_Value);
            m_FloatVal = Helper.String2Float(m_Value);
        }
    }
}
