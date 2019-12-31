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
    public class GuideHandCommand : AbstractGuideCommand
    {
        private IUINodeFinder m_Finder;
        private bool m_NeedClose = true;
        private Vector3 m_Offset;
        private Vector3 m_MoveTo;
        private Vector3 m_TipPosition;
        private string m_TipText;

        public override void SetParam(object[] pv)
        {
            if (pv.Length == 0)
            {
                Log.w("GuideHandCommand Init With Invalid Param.");
                return;
            }

            try
            {
                m_Finder = pv[0] as IUINodeFinder;

                if (pv.Length > 1)
                {
                    m_NeedClose = Helper.String2Bool((string)pv[1]);
                }

                if (pv.Length > 2)
                {
                    m_Offset = Helper.String2Vector3((string)pv[2], '|');
                }
                if (pv.Length > 3)
                {
                    m_MoveTo = Helper.String2Vector3((string)pv[3], '|');
                }
                if (pv.Length > 4)
                {
                    m_TipPosition = Helper.String2Vector3((string)pv[4], '|');
                }
                if (pv.Length > 5)
                {
                    m_TipText = (string)pv[5];
                }
                else
                {
                    m_TipText = "";
                }

            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }

        protected override void OnStart()
        {
            RectTransform targetNode = m_Finder.FindNode(false) as RectTransform;

            if (targetNode == null)
            {
                return;
            }

            UIMgr.S.OpenTopPanel(EngineUI.GuideHandPanel, null, targetNode, m_Offset, m_MoveTo,m_TipPosition,m_TipText);
        }

        protected override void OnFinish(bool forceClean)
        {
            if (m_NeedClose || forceClean)
            {
                UIMgr.S.ClosePanelAsUIID(EngineUI.GuideHandPanel);
            }
            
        }
    }
}

