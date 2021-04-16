using System.Collections;
using Managers;
using UnityEngine;

namespace Effect
{
	[CreateAssetMenu(menuName = "Effect/Global/TimeMultiplier", fileName = "New Effect", order = 56)]
	public class EffectTimeMultiplier : EffectBase
	{
		[SerializeField]
		private float multiplier;
	
		public override IEnumerator EffectBehaviour(GameObject target)
		{
			GameManager.Instance.speedMultiplier *= multiplier;
			isActive = false;
			yield break;
		}
	}
}
