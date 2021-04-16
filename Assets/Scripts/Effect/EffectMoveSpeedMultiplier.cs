using System.Collections;
using Components;
using UnityEngine;

namespace Effect
{
	[CreateAssetMenu(menuName = "Effect/Projectile/MoveSpeedMultiplier", fileName = "New Effect", order = 55)]
	public class EffectMoveSpeedMultiplier : EffectBase
	{
		[SerializeField]
		private float multiplier;
	
		[SerializeField]
		private float duration;

		public override IEnumerator EffectBehaviour(GameObject target)
		{
			var moveComp = target.GetComponent<MovementComponent>();

			if (moveComp != null) {
				moveComp.MovementSpeed *= multiplier;
			}
		
			if (duration != 0) {
				yield return new WaitForSeconds(duration);
			}
			
			if (moveComp != null) {
				moveComp.MovementSpeed /= multiplier;
			}

			isActive = false;
			yield break;
		}
	}
}
