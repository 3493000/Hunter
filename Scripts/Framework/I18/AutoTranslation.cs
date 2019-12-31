﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hunter;
using UnityEngine.UI;

namespace Hunter
{
    public class AutoTranslation : MonoBehaviour
    {
        [SerializeField]
        private string m_Key;
        [SerializeField]
        private Text m_Text;

        private object[] m_Value;

        public string sKey
        {
            get
            {
                return m_Key;
            }
        }

        public static void ReTranslationAll()
        {
            AutoTranslation[] coms = UIMgr.S.uiRoot.GetComponentsInChildren<AutoTranslation>();
            if (coms != null && coms.Length > 0)
            {
                for (int i = 0; i < coms.Length; ++i)
                {
                    coms[i].Translate();
                }
            }
        }

        private void Awake()
        {
            Translate();
        }

        public void SetKey(string key)
        {
            m_Key = key;
            Translate();
        }

        public void SetKeyValue(string key, object[] value)
        {
            m_Key = key;
            m_Value = value;
            Translate();
        }
        public void Translate()
        {
            if (m_Text == null)
            {
                m_Text = GetComponent<Text>();
            }

            if (m_Text == null)
            {
                Log.e("Not Find Text Componment On:" + gameObject.name);
                return;
            }
            if (m_Value != null)
            {
                m_Text.text = string.Format(TDLanguageTable.Get(m_Key), m_Value);
            }
            else
            {
                m_Text.text = TDLanguageTable.Get(m_Key);
            }   
        }
    }
}
