using System.Collections;
using Managers;
using UnityEngine;

namespace Effect
{
	public abstract class EffectBase : ScriptableObject
	{
		public bool isActive;

		public Sprite effectIcon;

		public BonusType bonusType;

		public abstract IEnumerator EffectBehaviour(GameObject target);
	}
}
