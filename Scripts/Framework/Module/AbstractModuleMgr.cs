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
    public class AbstractModuleMgr : AbstractActor
    {
        private Dictionary<string, IModule> m_ModuleMgrMap = new Dictionary<string,IModule>();

        public IModule GetModule(string name)
        {
            IModule ret = null;
            if (m_ModuleMgrMap.TryGetValue(name, out ret))
            {
                return ret;
            }
            return null;
        }

        protected override void OnAddCom(ICom com)
        {
            if (com is IModule)
            {
                IModule module = com as IModule;
                string name = module.GetType().Name;
                if (m_ModuleMgrMap.ContainsKey(name))
                {
                    Log.e("ModuleMgr Already Add Module:" + name);
                    return;
                }
                m_ModuleMgrMap.Add(name, module);

                OnModuleRegister(module);
            }
        }

        protected virtual void OnModuleRegister(IModule module)
        {

        }
    }
}
