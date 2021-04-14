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
	[RequireComponent(typeof(MovementComponent))]
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
			if (!GlobalPoints.Instance.IsInsideBorders(transform.position, 2.0f)) {
				EventManager.Instance.Death(gameObject.GetInstanceID());
			}
		}

		private void Death(int id)
		{
			if (id == gameObject.GetInstanceID()) {
				var movementComponent = GetComponent<MovementComponent>();
				if (movementComponent.Coroutine != null) {
					movementComponent.StopCoroutine(movementComponent.Coroutine);
				}

				EventManager.Instance.OnDeath -= Death;
				
				if (DebugManager.Instance.IsLogDeath) {
					Debug.Log("Death for object " + gameObject.name);
				}
					
				PoolManager.Instance.ReleaseObject(gameObject);
			}
		}
	

		#endregion
	}
}
