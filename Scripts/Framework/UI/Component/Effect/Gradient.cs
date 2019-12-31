﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Hunter
{
    [AddComponentMenu("UI/Effects/Gradient")]
    public class Gradient : BaseMeshEffect
    {
        public Color32 topColor = Color.white;

        public Color32 bottomColor = Color.black;

        public override void ModifyMesh(VertexHelper vh)
        {
            if (!IsActive())
            {
                return;
            }

            var vertexList = ListPool<UIVertex>.Allocate();
            vh.GetUIVertexStream(vertexList);

            int count = vertexList.Count;
            if (count > 0)
            {
                float bottomY = vertexList[0].position.y;
                float topY = bottomY;

                for (int i = 1; i < count; i++)
                {
                    float y = vertexList[i].position.y;
                    if (y > topY)
                    {
                        topY = y;
                    }
                    else if (y < bottomY)
                    {
                        bottomY = y;
                    }
                }
                float uiElementHeight = topY - bottomY;
                for (int i = 0; i < count; i++)
                {
                    UIVertex uiv = vertexList[i];
                    uiv.color = Color32.Lerp(bottomColor, topColor, (vertexList[i].position.y - bottomY) / uiElementHeight);
                    vertexList[i] = uiv;
                }
                
                vh.Clear();
                vh.AddUIVertexTriangleStream(vertexList);
                ListPool<UIVertex>.Recycle(vertexList);
            }
        }
    }
}
