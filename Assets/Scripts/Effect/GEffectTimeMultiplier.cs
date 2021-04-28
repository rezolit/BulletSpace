using System.Collections;
using Managers;
using UnityEngine;

namespace Effect
{
	
	[CreateAssetMenu(menuName = "BulletHell/Effect/Global/TimeMultiplier", fileName = "New Effect", order = 56)]
	public class GEffectTimeMultiplier : EffectBase
	{
		[SerializeField]
		private float multiplier;
		
		[SerializeField]
		private float duration;
	
		public override IEnumerator EffectBehaviour(GameObject target)
		{
			if (DebugManager.Instance.IsLogEffects) {
				Debug.Log("TimeMultEffect");
			}
			
			GameManager.Instance.speedMultiplier *= multiplier;
			
			yield return new WaitForSeconds(duration);
			
			GameManager.Instance.speedMultiplier /= multiplier;
			isActive = false;
			yield break;
		}
	}
}
