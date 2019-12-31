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
    public class ABUnitHelper
    {
        //计算成成更新的资源列表
        public static List<ABUnit> CalculateLateList(AssetDataTable oldData, AssetDataTable newData, bool addNew)
        {
            if (newData == null || oldData == null)
            {
                return null;
            }

            List<ABUnit> newABUnitList = newData.GetAllABUnit();

            List<ABUnit> lateABList = new List<ABUnit>();

            for (int i = newABUnitList.Count - 1; i >= 0; --i)
            {
                ABUnit newUnit = newABUnitList[i];
                ABUnit oldUnit = oldData.GetABUnit(newUnit.abName);

                if (oldUnit == null)
                {
                    //更新的新资源
                    if (addNew)
                    {
                        lateABList.Add(newUnit);
                    }
                    continue;
                }

                if (oldUnit.md5.Equals(newUnit.md5))
                {
                    continue;
                }

                if (oldUnit.buildTime < newUnit.buildTime)
                {
                    lateABList.Add(newUnit);
                }
            }

            return lateABList;
        }

    }
}
