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
    public interface ISkill
    {
        SkillInfo skillInfo { get; set; }
        AbstractSkillSystem skillSystem { get; }
        ISkillReleaser skillReleaser { get; }
        void DoSkillRelease(AbstractSkillSystem system, ISkillReleaser releaser);
        void DoSkillRemove();
        void DoSkillUpdate(float deltaTime);
    }
}
