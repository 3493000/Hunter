//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Core;

namespace Hunter
{
    public static class TweenHelper
    {
        public static Tweener DoText(this Text label, string context, float speed)
        {
            if (label == null || string.IsNullOrEmpty(context))
            {
                return null;
            }
            float duration = context.Length * speed;

            label.text = "";

            int index = 0;
            DOGetter<int> getter = () =>
            {
                return index;
            };

            DOSetter<int> setter = (x) =>
            {
                index = x;
                label.text = context.Substring(0, x);
            };

            return DOTween.To(getter, setter, context.Length, duration);
        }

        public static Tweener DoDelay(float duration)
        {
            int index = 0;
            DOGetter<int> getter = () =>
            {
                return index;
            };

            DOSetter<int> setter = (x) =>
            {
                index = x;
            };

            return DOTween.To(getter, setter, 1, duration);
        }

		public static Tweener DoSpriteScale(Image image,Run<bool> callback,bool bWin)
		{
			if (image == null)
			{
				return null;
			}

			return image.transform.DOScale(Vector3.one,0.8f).OnComplete(()=>{
				image.transform.DOScale(Vector3.zero,0.8f).SetDelay(2f).OnComplete(()=>{
					if(callback != null)
						callback(bWin);
				});
			});
		}

        public static Sequence DoScale(Transform target, float dstValue, float duration, int loop = -1)
        {
            Vector3 originScale = target.transform.localScale;

            return DOTween.Sequence()
                .Append(target.transform.DOScale(dstValue, duration * 0.5f).SetEase(Ease.InSine))
                .Append(target.transform.DOScale(originScale, duration * 0.5f).SetEase(Ease.OutSine))
                .SetLoops(loop);
        }

        public static Sequence RotateAnim(GameObject obj, Sequence tweener)
        {
            tweener.Kill();
            tweener = DOTween.Sequence();
            //obj.transform.localScale = Vector3.one;

            //tweener.Append(obj.transform.DOScale(1f, 1f));
            //tweener.Append(obj.transform.DOScale(0.85f, 0.4f));
            //tweener.Append(obj.transform.DOScale(1, 0.4f));
            //tweener.Append(obj.transform.DOScale(0.85f, 0.4f));
            //tweener.Append(obj.transform.DOScale(1, 0.4f));
            //tweener.Append(obj.transform.DOScale(0.85f, 0.4f));
            //tweener.Append(obj.transform.DOScale(1, 0.4f));
            tweener.Append(obj.transform.DOLocalRotate(new Vector3(0, 0, 10), 0.2f, RotateMode.Fast));
            tweener.Append(obj.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f, RotateMode.Fast));
            tweener.Append(obj.transform.DOLocalRotate(new Vector3(0, 0, 10), 0.2f, RotateMode.Fast));
            tweener.Append(obj.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.2f, RotateMode.Fast));
            tweener.Append(obj.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast));
            tweener.Append(obj.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.3f, RotateMode.Fast));
            tweener.SetLoops(-1);
            return tweener;
        }

        public static void ScaleButtonAnim(GameObject obj, Sequence tweener)
        {
            obj.transform.GetComponent<RectTransform>().localScale = Vector3.one;
            tweener.Append(obj.transform.GetComponent<RectTransform>().DOScale(0.9f, 0.13f));
            tweener.Append(obj.transform.GetComponent<RectTransform>().DOScale(1, 0.13f));
            tweener.SetLoops(1);
        }

        public static Sequence ScaleShakeAnim(GameObject obj, Sequence tweener)
        {
            tweener.Kill();
            tweener = DOTween.Sequence();
            obj.transform.GetComponent<RectTransform>().localScale = Vector3.one;
            tweener.Append(obj.transform.GetComponent<RectTransform>().DOScale(1.3f, 0.39f));
            tweener.Append(obj.transform.GetComponent<RectTransform>().DOScale(1, 0.13f));
            tweener.SetLoops(-1);
            return tweener;
        }
    }
}
