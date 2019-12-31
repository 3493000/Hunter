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
using DG.Tweening;
using UnityEngine.UI;

namespace Hunter
{
    public class GuideHandPanel : AbstractPanel
    {
        [SerializeField]
        private Transform m_HandImage;
        [SerializeField]
        protected float m_FlySpeed = 500;
        [SerializeField]
        protected Vector3 m_OffsetPos;
        [SerializeField]
        protected Text m_TipText;

        [SerializeField]
        protected Vector3 m_MoveToPos = new Vector3(0, 15, 0);

        protected Vector3 m_OldPos = Vector3.zero;

        private Transform m_Target;

        protected override void OnPanelOpen(params object[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            m_Target = args[0] as Transform;

            if (args.Length > 1)
            {
                m_OffsetPos = (Vector3)args[1];
            }
            if (args.Length > 2)
            {
                m_MoveToPos= (Vector3)args[2];
            }
            if (args.Length > 3)
            {
                m_TipText.transform.localPosition = (Vector3)args[3];
            }
            if (args.Length > 4)
            {
                m_TipText.text = (string)args[4];
            }
            else
            {
                m_TipText.text = "";
            }
            Update();


        }

        private void Update()
        {
            if (m_Target == null)
            {

                return;
            }

            Vector3 pos = GetHandPos();
            if (pos.x != m_OldPos.x || pos.y != m_OldPos.y)
            {
                m_HandImage.position = pos;

                var localpos = m_HandImage.localPosition;
                localpos = localpos + m_OffsetPos;
                m_HandImage.localPosition = localpos;

                m_HandImage.transform.DOKill();

                if (m_MoveToPos != Vector3.zero)
                {
                    m_HandImage.transform.DOLocalMove((localpos + m_MoveToPos), 1f).SetLoops(-1)
                        .SetEase(Ease.Linear);
                }

                m_OldPos = pos;
            }
        }

        private Vector3 GetHandPos()
        {
            return m_Target.position;
        }

    }
}

