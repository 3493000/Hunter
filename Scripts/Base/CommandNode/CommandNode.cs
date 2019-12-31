﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Hunter
{
	//����ģʽ:��������Ż�����֯��ʽ��ȫ��ͨ��Event��ʵ�ֵĻ�����Ч�����е��
	public class CommandNode
	{
		public delegate void CommandNodeEvent(CommandNode commond);

		private CommandNodeEvent m_OnCommandComplate;

		private CommandNode	m_NextCommand;
		
		public CommandNode nextCommand
		{
			get { return m_NextCommand; }
			set { m_NextCommand = value; }
		}

        public void SetCommandNodeEventListener(CommandNodeEvent c)
        {
            m_OnCommandComplate = c;
        }

        public virtual void Start()
		{

		}

        protected virtual void FinishCommand()
        {
            if (m_OnCommandComplate != null)
            {
                m_OnCommandComplate(this);
            }
        }

    }
}


















