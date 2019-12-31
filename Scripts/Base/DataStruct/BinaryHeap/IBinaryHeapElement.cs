//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;

namespace Hunter
{
    public interface IBinaryHeapElement
    {
        float sortScore
        {
            get;
        }

        int heapIndex
        {
            set;
        }

        void RebuildHeap<T>(BinaryHeap<T> heap) where T : IBinaryHeapElement;
    }
}


