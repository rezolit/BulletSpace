using System.Collections;
using UnityEngine;

namespace Effect
{
	[CreateAssetMenu(menuName = "BulletHell/Effect/Projectile/Nothing", fileName = "New Effect", order = 55)]
	public class PEffectNothing : EffectBase
	{
		public override IEnumerator EffectBehaviour(GameObject target)
		{
			yield break;
		}
	}
}
