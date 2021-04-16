using System;
using System.Collections;
using UnityEngine;

namespace Effect
{
	public abstract class EffectBase : ScriptableObject
	{
		public bool isActive;

		public Sprite effectIcon;

		public abstract IEnumerator EffectBehaviour(GameObject target);
	}
}
