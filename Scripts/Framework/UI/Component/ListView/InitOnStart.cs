﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Hunter.LoopScrollRect))]
[DisallowMultipleComponent]
public class InitOnStart : MonoBehaviour {
	void Start () {
        GetComponent<Hunter.LoopScrollRect>().RefillCells();
	}
}
