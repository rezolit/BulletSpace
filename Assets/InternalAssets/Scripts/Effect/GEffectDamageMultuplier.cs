using System.Collections;
using Components;
using Managers;
using UnityEngine;

namespace Effect
{
	[CreateAssetMenu(menuName = "BulletHell/Effect/Global/DamageMultiplier", fileName = "New Effect", order = 55)]
	public class GEffectDamageMultuplier : EffectBase
	{
		[SerializeField]
		private float multiplier;

		[SerializeField]
		private float duration;
		
		public override IEnumerator EffectBehaviour(GameObject target)
		{
			if (DebugManager.Instance.IsLogEffects) {
				Debug.Log("DamageEffect");
			}
			
			GameManager.Instance.damageMultiplier = 2;
			
			yield return new WaitForSeconds(duration);
			
			GameManager.Instance.damageMultiplier = 1;
			isActive = false;
			yield break;
		}
	}
}
