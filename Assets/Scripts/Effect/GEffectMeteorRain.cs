using System.Collections;
using Managers;
using UnityEngine;

namespace Effect
{
	[CreateAssetMenu(menuName = "BulletHell/Effect/Global/MeteorRain", fileName = "New Effect", order = 57)]
	public class GEffectMeteorRain : EffectBase
	{
		[SerializeField]
		private float duration;
	
		public override IEnumerator EffectBehaviour(GameObject target)
		{
			GameManager.Instance.isMeteorRainActive = true;
			
			yield return new WaitForSeconds(duration);
			
			GameManager.Instance.isMeteorRainActive = false;
		}
	}
}
