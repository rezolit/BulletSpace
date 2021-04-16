using System;
using System.Collections;
using System.Collections.Generic;
using Components;
using Effect;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
	public class EffectManager : Singleton<EffectManager>
	{
		#region Fields

		[SerializeField]
		private List<EffectBase> globalGlobalEffects;

		[SerializeField]
		private float timeBetweenNewEffects;

		[SerializeField]
		private List<EffectBase> projectilesEffects;

		private float _timer;
		
		#endregion

		#region Methods
		
		public List<EffectBase> GlobalEffects {
			get => globalGlobalEffects;
			set => globalGlobalEffects = value;
		}
		
		private void Start()
		{
			_timer = 0.0f;
			
		}

		private void Update()
		{
			_timer += Time.deltaTime;
			if (_timer >= timeBetweenNewEffects) {
				ApplyNewEffect(GameManager.Instance.gameObject, RandomGlobalEffect());
				_timer = 0.0f;
			}
		}

		private EffectBase RandomGlobalEffect()
		{
			if (GlobalEffects.Count <= 0) {
				Debug.LogError("Add Global effects to List in " + gameObject.name);
			}
			var newEffect = GlobalEffects[Random.Range(0, GlobalEffects.Count - 1)];

			return newEffect;
		}

		// TODO избавиться от привязанности к GameManager и сделать глобальные эффекты универсальнее
		private void ApplyNewEffect(GameObject target, EffectBase effect)
		{
			var effectComp = target.GetComponent<EffectComponent>();

			if (target != GameManager.Instance.gameObject) {
				var effectComponent = target.GetComponent<EffectComponent>();
				if (effectComponent) {
					effectComponent.ApplyEffect(effect);
				}
			}
			else {
				StartCoroutine( effect.EffectBehaviour(GameManager.Instance.gameObject));
			}


			Debug.Log("New effect: " + effect.name + " on target " + target.name);
			effect.isActive = true;
		}

		public void ImposeShootEffect(GameObject target, Projectile.Projectile instigator)
		{
			target.GetComponent<HealthComponent>().
				GetDamaged((int)(instigator.Damage * GameManager.Instance.damageMultiplier));
			ApplyNewEffect(target, projectilesEffects[0]);
		}

		#endregion


	}
}
