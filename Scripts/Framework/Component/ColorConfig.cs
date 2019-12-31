﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Hunter
{
    [System.Serializable]
    public class ColorConfig : ScriptableObject
    {
        [SerializeField]
        public Color[] colors;
    }
}
