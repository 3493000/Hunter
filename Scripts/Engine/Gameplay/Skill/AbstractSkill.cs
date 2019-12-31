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
    public class AbstractSkill : ISkill
    {
        private float               m_RunTime = 0;
        private SkillInfo           m_SkillInfo;
        private AbstractSkillSystem m_SkillSystem;
        private ISkillReleaser      m_SkillReleaser;

        public float runTime
        {
            get { return m_RunTime; }
        }

        public SkillInfo skillInfo
        {
            get { return m_SkillInfo; }

            set { m_SkillInfo = value; }
        }

        public AbstractSkillSystem skillSystem
        {
            get { return m_SkillSystem; }
        }

        public ISkillReleaser skillReleaser
        {
            get { return m_SkillReleaser; }
        }

        public void StopSelf()
        {
            if (m_SkillSystem != null)
            {
                m_SkillSystem.RemoveSkill(this);
            }
        }

        public void DoSkillRelease(AbstractSkillSystem system, ISkillReleaser releaser)
        {
            //Log.i("OnSkillRelease");
            m_RunTime = 0;
            m_SkillSystem = system;
            m_SkillReleaser = releaser;

            OnSkillRelease();

            if(m_SkillReleaser != null)
            {
                m_SkillReleaser.OnSkillRelease(this);
            }
        }

        public void DoSkillRemove()
        {
            //Log.i("OnSkillRemove");
            OnSkillRemove();

            if (m_SkillReleaser != null)
            {
                m_SkillReleaser.OnSkillRemove(this);
                m_SkillReleaser = null;
            }

            m_SkillSystem = null;
            m_SkillInfo = null;
        }

        public void DoSkillUpdate(float deltaTime)
        {
            //Log.i("OnSkillUpdate");
            m_RunTime += deltaTime;
            OnSkillUpdate(deltaTime);
        }

        protected virtual void OnSkillUpdate(float deltaTime)
        {

        }

        protected virtual void OnSkillRelease()
        {

        }

        protected virtual void OnSkillRemove()
        {

        }

    }
}
