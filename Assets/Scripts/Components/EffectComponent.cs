using System.Collections.Generic;
using Effect;
using UnityEngine;

namespace Components
{
	public class EffectComponent : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		private List<EffectBase> activeEffects;

		#endregion

		#region Methods

		private void Update()
		{
			var newActiveEffects = new List<EffectBase>();
			foreach (EffectBase effect in activeEffects) {
				if (effect.isActive) {
					newActiveEffects.Add(effect);
				}
			}

			activeEffects = newActiveEffects;
		}

		public void ApplyEffect(EffectBase newEffect)
		{
			activeEffects.Add(newEffect);
			StartCoroutine(newEffect.EffectBehaviour(gameObject));
		}

		#endregion
	
	
	}
}
