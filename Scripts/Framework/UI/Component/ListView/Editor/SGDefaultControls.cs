﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using UnityEngine;
using System.Collections.Generic;
using Hunter;

namespace UnityEngine.UI
{
    public static class SGDefaultControls
    {
        #region code from DefaultControls.cs
        public struct Resources
        {
            public Sprite standard;
            public Sprite background;
            public Sprite inputField;
            public Sprite knob;
            public Sprite checkmark;
            public Sprite dropdown;
            public Sprite mask;
        }

        private const float kWidth = 160f;
        private const float kThickHeight = 30f;
        private const float kThinHeight = 20f;
        //private static Vector2 s_ThickElementSize = new Vector2(kWidth, kThickHeight);
        //private static Vector2 s_ThinElementSize = new Vector2(kWidth, kThinHeight);
        //private static Vector2 s_ImageElementSize = new Vector2(100f, 100f);
        //private static Color s_DefaultSelectableColor = new Color(1f, 1f, 1f, 1f);
        //private static Color s_PanelColor = new Color(1f, 1f, 1f, 0.392f);
        private static Color s_TextColor = new Color(50f / 255f, 50f / 255f, 50f / 255f, 1f);

        // Helper methods at top

        private static GameObject CreateUIElementRoot(string name, Vector2 size)
        {
            GameObject child = new GameObject(name);
            RectTransform rectTransform = child.AddComponent<RectTransform>();
            rectTransform.sizeDelta = size;
            return child;
        }

        static GameObject CreateUIObject(string name, GameObject parent)
        {
            GameObject go = new GameObject(name);
            go.AddComponent<RectTransform>();
            SetParentAndAlign(go, parent);
            return go;
        }

        private static void SetDefaultTextValues(Text lbl)
        {
            // Set text values we want across UI elements in default controls.
            // Don't set values which are the same as the default values for the Text component,
            // since there's no point in that, and it's good to keep them as consistent as possible.
            lbl.color = s_TextColor;
        }

        private static void SetDefaultColorTransitionValues(Selectable slider)
        {
            ColorBlock colors = slider.colors;
            colors.highlightedColor = new Color(0.882f, 0.882f, 0.882f);
            colors.pressedColor = new Color(0.698f, 0.698f, 0.698f);
            colors.disabledColor = new Color(0.521f, 0.521f, 0.521f);
        }

        private static void SetParentAndAlign(GameObject child, GameObject parent)
        {
            if (parent == null)
                return;

            child.transform.SetParent(parent.transform, false);
            SetLayerRecursively(child, parent.layer);
        }

        private static void SetLayerRecursively(GameObject go, int layer)
        {
            go.layer = layer;
            Transform t = go.transform;
            for (int i = 0; i < t.childCount; i++)
                SetLayerRecursively(t.GetChild(i).gameObject, layer);
        }
        #endregion
        
        public static GameObject CreateListViewHorizontal(DefaultControls.Resources resources)
        {
            GameObject root = CreateUIElementRoot("ListView", new Vector2(200, 200));
            
            GameObject content = CreateUIObject("Content", root);

            RectTransform contentRT = content.GetComponent<RectTransform>();
            contentRT.anchorMin = new Vector2(0, 0.5f);
            contentRT.anchorMax = new Vector2(0, 0.5f);
            contentRT.sizeDelta = new Vector2(0, 200);
            contentRT.pivot = new Vector2(0, 0.5f);

            // Setup UI components.

            ListView scrollRect = root.AddComponent<ListView>();
            scrollRect.content = contentRT;
            scrollRect.viewport = null;
            scrollRect.horizontalScrollbar = null;
            scrollRect.verticalScrollbar = null;
            scrollRect.direction = LoopScrollRect.eDirection.kHorizontal;
            scrollRect.horizontal = true;
            scrollRect.vertical = false;
            scrollRect.horizontalScrollbarVisibility = LoopScrollRect.ScrollbarVisibility.Permanent;
            scrollRect.verticalScrollbarVisibility = LoopScrollRect.ScrollbarVisibility.Permanent;
            scrollRect.horizontalScrollbarSpacing = 0;
            scrollRect.verticalScrollbarSpacing = 0;
            
            root.AddComponent<RectMask2D>();

            HorizontalLayoutGroup layoutGroup = content.AddComponent<HorizontalLayoutGroup>();
            layoutGroup.childAlignment = TextAnchor.MiddleLeft;
            layoutGroup.childForceExpandWidth = false;
            layoutGroup.childForceExpandHeight = true;

            ContentSizeFitter sizeFitter = content.AddComponent<ContentSizeFitter>();
            sizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            sizeFitter.verticalFit = ContentSizeFitter.FitMode.Unconstrained;

            return root;
        }

        public static GameObject CreateListViewVertical(DefaultControls.Resources resources)
        {
            GameObject root = CreateUIElementRoot("ListView", new Vector2(200, 200));

            GameObject content = CreateUIObject("Content", root);

            RectTransform contentRT = content.GetComponent<RectTransform>();
            contentRT.anchorMin = new Vector2(0.5f, 1);
            contentRT.anchorMax = new Vector2(0.5f, 1);
            contentRT.sizeDelta = new Vector2(200, 0);
            contentRT.pivot = new Vector2(0.5f, 1);

            // Setup UI components.

            ListView scrollRect = root.AddComponent<ListView>();
            scrollRect.content = contentRT;
            scrollRect.viewport = null;
            scrollRect.horizontalScrollbar = null;
            scrollRect.verticalScrollbar = null;
            scrollRect.direction = LoopScrollRect.eDirection.kVertical;
            scrollRect.horizontal = false;
            scrollRect.vertical = true;
            scrollRect.horizontalScrollbarVisibility = LoopScrollRect.ScrollbarVisibility.Permanent;
            scrollRect.verticalScrollbarVisibility = LoopScrollRect.ScrollbarVisibility.Permanent;
            scrollRect.horizontalScrollbarSpacing = 0;
            scrollRect.verticalScrollbarSpacing = 0;

            root.AddComponent<RectMask2D>();

            VerticalLayoutGroup layoutGroup = content.AddComponent<VerticalLayoutGroup>();
            layoutGroup.childAlignment = TextAnchor.UpperCenter;
            layoutGroup.childForceExpandWidth = true;
            layoutGroup.childForceExpandHeight = false;

            ContentSizeFitter sizeFitter = content.AddComponent<ContentSizeFitter>();
            sizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            sizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

            return root;
        }
    }
}