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
    public class TimerTest : MonoBehaviour
    {
        //private TimeItem m_RepeatTimeItem;

        private void Start()
        {
            Log.i(DateTime.Now);
            //m_RepeatTimeItem = Timer.S.Post2Really(OnTimeTick, 1, -1);
            //DateTime time = DateTime.Now;
            //time = time.AddSeconds(5);
            //Timer.S.Post2Really(OnDateTimeTick, time);

            //Time.timeScale = 0.5f;
            //Timer.S.Post2Scale(OnScaleTimeTick, 1, -1);
        }

        private void OnTimeTick(int tick)
        {
            Log.i("TickTick:" + DateTime.Now);
        }

        private void OnDateTimeTick(int tick)
        {
            Log.i("DateTimeTick:" + tick);
        }

        private void OnScaleTimeTick(int tick)
        {
            Log.i("ScaleTickTick:" + tick);
        }
    }
}
