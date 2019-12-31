//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2019 Hunter. All rights reserved.
//  ————————————————————————
//  ————————————————————————
//  Author:      Hunter
//  E-mail:      3493000@qq.com
using UnityEngine;
using UnityEngine.UI;

namespace Hunter
{
	public abstract class IUListItemView : MonoBehaviour
	{
		RectTransform rectTransform;

		public virtual Vector2 GetItemSize(int index)
		{
			if (null == rectTransform) 
			{
				rectTransform = transform as RectTransform;
			}
			return rectTransform.rect.size;
		}
	}
}
