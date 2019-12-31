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
using UnityEngine.UI;
using DG.Tweening;


namespace Hunter
{
    public class FloatMsg
    {
        private string m_Message;

        public string message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }
    }

    public class FloatMessagePanel : AbstractPanel
    {
        [SerializeField]
        private GameObject m_Prefab;
        [SerializeField]
        private Transform m_Root;
        [SerializeField]
        private Vector3 m_StartPos;
        [SerializeField]
        private Vector3 m_EndPos;
        [SerializeField]
        private float m_AnimTime = 1.0f;
        [SerializeField]
        private float m_SendOffsetTime = 0.1f;

        private Stack<FloatMsg> m_MsgList;
        private GameObjectPool m_GameObjectPool;
        private float m_LastSendTime;

        private int m_AnimItemCount = 0;
        private bool m_IsOpen = false;

        private bool m_IsInit = false;

        private Color m_InitColor;

        public override int sortIndex
        {
            get
            {
                return UIRoot.FLOAT_PANEL_INDEX;
            }
        }

        protected override void OnUIInit()
        {
            InitFloatMessage();
        }



        protected override void OnOpen()
        {
            m_IsOpen = true;
        }

        protected override void OnClose()
        {
            m_IsOpen = false;
        }

        protected override void OnPanelOpen(params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return;
            }

            string msg = args[0] as string;

            if (msg == null)
            {
                return;
            }

            PlayFloatMessage(msg);
        }

        public void ShowMsg(string msg)
        {
            if (msg == null)
            {
                return;
            }

            PlayFloatMessage(msg);
        }

        protected override void BeforDestroy()
        {
            if (m_GameObjectPool != null)
            {
                m_GameObjectPool.RemoveAllObject(true, false);
                m_GameObjectPool = null;
            }
        }

        public void PlayFloatMessage(string msg)
        {
            PlayFloatMessage(msg, Vector3.zero, Vector3.zero);
        }

        public void PlayFloatMessage(string msg, Vector3 from, Vector3 to)
        {
            if (UIMgr.isApplicationQuit)
            {
                return;
            }

            FloatMsg fm = new FloatMsg();
            fm.message = msg;
            ShowMsg(fm);
        }

        private void InitFloatMessage()
        {
            m_MsgList = new Stack<FloatMsg>();
            m_GameObjectPool = GameObjectPoolMgr.S.CreatePool("FloatMessagePool", m_Prefab, -1, 5, UIPoolStrategy.S);
            m_Prefab.SetActive(false);
            var text = m_Prefab.GetComponentInChildren<Text>();
            m_InitColor = text.color;
            m_IsInit = true;
        }


        private bool CheckIsShowAble()
        {
            if (Time.realtimeSinceStartup - m_LastSendTime > m_SendOffsetTime)
            {
                return true;
            }

            return false;
        }

        private void ShowMsg(FloatMsg msgVo, bool check = true)
        {
            if(!m_IsInit)
            {
                InitFloatMessage();
            }

            if (check)
            {
                if (!CheckIsShowAble())
                {
                    m_MsgList.Push(msgVo);
                    return;
                }
            }

            GameObject obj = m_GameObjectPool.Allocate();
            if (obj)
            {
                obj.SetActive(true);
                ++m_AnimItemCount;
                FloatMessageItem item = obj.GetComponentInChildren<FloatMessageItem>();

                item.SetFloatMsg(msgVo);

                obj.transform.SetParent(m_Root, true);

                obj.transform.localPosition = m_StartPos;

                var image = obj.GetComponent<Image>();
                var text = obj.GetComponentInChildren<Text>();
                text.color = m_InitColor;
                image.color = m_InitColor;
                text.DOColor(new Color(m_InitColor.r, m_InitColor.g, m_InitColor.b, 0f), m_AnimTime)
                    //.SetDelay(m_AnimTime)
                    .OnComplete(() =>
                    {
                        m_GameObjectPool.Recycle(obj);
                        --m_AnimItemCount;
                    });
                image.DOColor(new Color(m_InitColor.r, m_InitColor.g, m_InitColor.b, 0f), m_AnimTime)
                    ;
                   // .SetDelay(m_AnimTime);
                obj.transform.DOLocalMove(m_EndPos, m_AnimTime).SetEase(Ease.Linear);
                m_LastSendTime = Time.realtimeSinceStartup;
            }
        }

        private void Update()
        {
            if (!m_IsOpen)
            {
                return;
            }

            if (m_MsgList.Count != 0)
            {
                if (CheckIsShowAble())
                {
                    ShowMsg(m_MsgList.Pop(), false);
                }
            }
            else if (m_AnimItemCount == 0)
            {
                CloseSelfPanel();
            }
        }
    }
}
