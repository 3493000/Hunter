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

namespace Hunter
{
    public class CaptureHelperTester : MonoBehaviour
    {
        [SerializeField]
        protected RawImage m_Image;

        protected Texture2D m_Tex;

        private void Awake()
        {
            StartCoroutine(CaptureHelper.Capture(UIMgr.S.uiRoot.uiCamera, false, OnCaptureFinish));
        }

        private void OnCaptureFinish(Texture2D tex, string path)
        {
            m_Image.texture = tex;
        }

        private void OnDestroy()
        {
            if (m_Tex != null)
            {
                GameObject.Destroy(m_Tex);
            }
        }
    }
}
