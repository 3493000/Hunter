//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hunter
{
    public class RectTransformHelper
    {
        private static Vector3[] m_TempPosArray = new Vector3[4];
        public static Vector2[] GetRectTransformViewPort(RectTransform target)
        {
            target.GetWorldCorners(m_TempPosArray);
            Vector2[] result = new Vector2[2];

            result[0] = UIMgr.S.uiRoot.uiCamera.WorldToViewportPoint(m_TempPosArray[0]);
            result[1] = UIMgr.S.uiRoot.uiCamera.WorldToViewportPoint(m_TempPosArray[2]);

            return result;
        }
    }
}
