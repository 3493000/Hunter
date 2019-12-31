//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;
using System.Collections;
using System.Collections.Generic;

namespace Hunter
{
    public delegate void DTableOnParse(byte[] data);
    public delegate void Run();
    public delegate void Run<T>(T v);
    public delegate void Run<T, K>(T v1, K v2);
    
}
