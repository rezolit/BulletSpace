using System.Collections;
using Player;
using UnityEngine;

namespace Effect
{
	[CreateAssetMenu(menuName = "BulletHell/Effect/Projectile/Drunk", fileName = "PEffect_Drunk", order = 58)]
	public class PEffectDrunk : EffectBase
	{
		[SerializeField]
		private float duration;
		
		public override IEnumerator EffectBehaviour(GameObject target)
		{
			var playerMovementBehaviour = target.GetComponent<PlayerMovementBehaviour>();

			if (playerMovementBehaviour == null) {
				Debug.Log("This targer can't be drunk: " + name);
				yield break;
			}

			playerMovementBehaviour.ToggleIsDrunk(true);

			yield return new WaitForSeconds(duration);

			playerMovementBehaviour.ToggleIsDrunk(false);

			yield break;
		}
	}
}
