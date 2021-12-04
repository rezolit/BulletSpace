using System;
using System.Collections.Generic;
using Effect;
using Managers;
using UnityEngine;

namespace Components
{
	public class EffectComponent : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		private List<EffectBase> activeEffects;
		
		public List<Coroutine> Coroutines { get; private set; }

		#endregion

		#region Methods

		private void Start()
		{
			Init();

			EventManager.Instance.OnGameStart += Init;
		}

		private void Init()
		{
			StopAllCoroutines();
			Coroutines.Clear();
		}

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

		private void OnEnable()
		{
			Coroutines = new List<Coroutine>();
		}

		public void ApplyEffect(EffectBase newEffect)
		{
			if (gameObject.activeSelf) {
				activeEffects.Add(newEffect);
				Coroutines.Add(StartCoroutine(newEffect.EffectBehaviour(gameObject)));
			}
		}

		#endregion
	
	
	}
}
