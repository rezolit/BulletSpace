using System.Collections.Generic;
using Components;
using Emitter;
using Managers;
using UnityEngine;

namespace Enemy
{
	/// <summary>
	/// General class-component for all enemies
	/// </summary>
	[RequireComponent(
		typeof(EnemyMovement),
		typeof(HealthComponent),
		typeof(EffectComponent))
	]
	public class EnemyController : MonoBehaviour
	{
		#region Fields
	
		[SerializeField]
		private EnemyData enemyData;

		private List<EmitterController>  _emitters;

		public EnemyData EnemyData {
			get => enemyData;
			set => enemyData = value;
		}

		#endregion

		#region Methods

		private void Awake()
		{
			_emitters = new List<EmitterController>();

			var childEmitters = gameObject.GetComponentsInChildren<EmitterController>();
			foreach (EmitterController emitter in childEmitters) {
				_emitters.Add(emitter);
			}
		}

		private void OnEnable()
		{
			foreach (EmitterController emitter in _emitters) {
				emitter.isActive = true;
			}
			
			EventManager.Instance.OnDeath += Death;
		}

		private void Update()
		{
			if (!GlobalPoints.Instance.IsInsideBorders(transform.position, GlobalPoints.Instance.enemiesOffset)) {
				EventManager.Instance.Death(gameObject.GetInstanceID());
			}
		}

		private void Death(int id)
		{
			if (id == gameObject.GetInstanceID()) {
				var movementComponent = GetComponent<EnemyMovement>();
				if (movementComponent.Coroutine != null) {
					movementComponent.StopCoroutine(movementComponent.Coroutine);
				}
				
				var effectComponent = GetComponent<EffectComponent>();
				if (effectComponent.Coroutines.Count != 0) {
					foreach (Coroutine coroutine in effectComponent.Coroutines) {
						if (coroutine != null) {
							effectComponent.StopCoroutine(coroutine);
						}
					}
					effectComponent.Coroutines.Clear();
				}

				EventManager.Instance.OnDeath -= Death;
				
				if (DebugManager.Instance.IsLogDeath) {
					Debug.Log("Death for object " + gameObject.name);
				}

				if (gameObject.tag == "Boss") {
					EventManager.Instance.BossKilled();
				}
				
				PoolManager.Instance.ReleaseObject(gameObject);
			}
		}
	

		#endregion
	}
}
