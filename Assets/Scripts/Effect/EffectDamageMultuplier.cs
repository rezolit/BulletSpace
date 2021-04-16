using System.Collections;
using Components;
using Managers;
using UnityEngine;

namespace Effect
{
	[CreateAssetMenu(menuName = "Effect/Global/DamageMultiplier", fileName = "New Effect", order = 55)]
	public class EffectDamageMultuplier : EffectBase
	{
		[SerializeField]
		private float multiplier;
		
		public override IEnumerator EffectBehaviour(GameObject target)
		{
			Debug.Log("DamageEffect");
			GameManager.Instance.damageMultiplier *= multiplier;
			isActive = false;
			yield break;
		}
	}
}
