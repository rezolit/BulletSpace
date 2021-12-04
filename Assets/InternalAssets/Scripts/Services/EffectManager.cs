using System.Collections.Generic;
using Components;
using Effect;
using Projectile;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

namespace Managers
{
	public enum BonusType
	{
		Nothing,
		X2Damage,
		SlowTime,
		MeteorRain,
		SlowSpeed,
		SpeedUp,
		Drunk
	}
	
	
	public class EffectManager : Singleton<EffectManager>
	{
		#region Fields

		[SerializeField]
		private List<EffectBase> possibleGlobalEffect;

		[SerializeField]
		private EffectBase currentGlobalEffect;

		[SerializeField]
		private float timeBetweenNewEffects;

		[SerializeField]
		private EffectBase startEffect;
		
		[SerializeField]
		private List<EffectBase> possibleProjectileEffects;
		
		[SerializeField]
		private SerializedDictionary<ProjectileType, EffectBase> projectileEffects;

		private float _timer;
		
		#endregion

		#region Methods

		private List<EffectBase> PossibleGlobalEffects {
			get => possibleGlobalEffect;
			set => possibleGlobalEffect = value;
		}
		
		private void Start()
		{
			Init();

			EventManager.Instance.OnGameStart += Init;
		}

		private void Update()
		{
			_timer += Time.deltaTime;
			if (_timer >= timeBetweenNewEffects) {
				
				// GLOBAL EFFECT
				currentGlobalEffect = NewRandomGlobalEffect();
				ApplyNewEffect(GameManager.Instance.gameObject, currentGlobalEffect);
				
				//PROJECTILE EFFECTS
				var availableEffects = new List<EffectBase>();
				foreach (EffectBase effect in possibleProjectileEffects) {
					availableEffects.Add(effect);
				}

				EffectBase newRandomEffect = availableEffects[Random.Range(0, availableEffects.Count)];
				projectileEffects[ProjectileType.Red] = newRandomEffect;
				availableEffects.Remove(newRandomEffect);
				
				newRandomEffect = availableEffects[Random.Range(0, availableEffects.Count)];
				projectileEffects[ProjectileType.Green] = newRandomEffect;
				availableEffects.Remove(newRandomEffect);
				
				newRandomEffect = availableEffects[Random.Range(0, availableEffects.Count)];
				projectileEffects[ProjectileType.Blue] = newRandomEffect;
				availableEffects.Remove(newRandomEffect);
				
				EventManager.Instance.BonusesChangeNotify(
					projectileEffects[ProjectileType.Red].bonusType,
					projectileEffects[ProjectileType.Green].bonusType,
					projectileEffects[ProjectileType.Blue].bonusType,
					currentGlobalEffect.bonusType
				);

				_timer = 0.0f;
			}
		}

		private EffectBase NewRandomGlobalEffect()
		{
			if (PossibleGlobalEffects.Count <= 0) {
				Debug.LogError("Add Global effects to List in " + name);
			}

			EffectBase newEffect;
			do {
				newEffect = PossibleGlobalEffects[Random.Range(0, PossibleGlobalEffects.Count)];
			} while (newEffect == currentGlobalEffect);

			return newEffect;
		}

		// TODO избавиться от привязанности к GameManager и сделать глобальные эффекты универсальнее
		private void ApplyNewEffect(GameObject target, EffectBase effect)
		{
			if (target != GameManager.Instance.gameObject) {
				var effectComponent = target.GetComponent<EffectComponent>();
				if (effectComponent) {
					effectComponent.ApplyEffect(effect);
				}
			}
			else {
				StartCoroutine( effect.EffectBehaviour(GameManager.Instance.gameObject));
			}

			if (DebugManager.Instance.IsLogEffects) {
				Debug.Log("New effect: " + effect.name + " on target " + target.name);
			}
			
			effect.isActive = true;
		}

		public void ImposeShootEffect(GameObject target, Projectile.Projectile instigator)
		{
			target.GetComponent<HealthComponent>()?.
				GetDamaged((int)(instigator.Damage * GameManager.Instance.damageMultiplier));
			ApplyNewEffect(target, projectileEffects[instigator.ProjectileType]);
		}
		
		private void Init()
		{
			StopAllCoroutines();
			
			_timer = 0.0f;

			if (possibleProjectileEffects.Count == 0) {
				Debug.LogError("Add PossibleProjectileEffects in " + name);
			}

			projectileEffects = new SerializedDictionary<ProjectileType, EffectBase> {
				[ProjectileType.Red] = startEffect,
				[ProjectileType.Green] = startEffect,
				[ProjectileType.Blue] = startEffect,
				[ProjectileType.Yellow] = startEffect
			};

			currentGlobalEffect = startEffect;
			
			EventManager.Instance.BonusesChangeNotify(
				projectileEffects[ProjectileType.Red].bonusType,
				projectileEffects[ProjectileType.Green].bonusType,
				projectileEffects[ProjectileType.Blue].bonusType,
				currentGlobalEffect.bonusType
			);
		}

		#endregion
	}
}
