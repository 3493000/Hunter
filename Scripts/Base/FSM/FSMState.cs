//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using UnityEngine;
using System.Collections;

namespace Hunter
{
    public class FSMState<T>
    {
        public virtual string stateName
        {
            get { return this.GetType().Name; }
        }

        public virtual void Enter(T entity)
        {

        }

        public virtual void Execute(T entity, float dt)
        {

        }

        public virtual void Exit(T entity)
        {

        }

        public virtual void OnMsg(T entity, int key, params object[] args)
        {

        }
    }

}
