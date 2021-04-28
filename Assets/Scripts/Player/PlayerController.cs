using System;
using Components;
using Managers;
using UnityEngine;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField]
		private HealthComponent healthComponent;

		private void Start()
		{
			healthComponent = GetComponent<HealthComponent>();
			Init();
			
			EventManager.Instance.OnDeath += Death;
			EventManager.Instance.OnGameStart += Init;
		}

		private void Init()
		{
			gameObject.SetActive(true);
			EventManager.Instance.PlayerHealthChange(healthComponent.MaxHitPoints, 
				Mathf.Clamp(healthComponent.MaxHitPoints, 0, healthComponent.MaxHitPoints));
		}

		public void Death(int id)
		{
			if (id == gameObject.GetInstanceID()) {	
				
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
					Debug.Log("Death for " + gameObject.name);
				}
				EventManager.Instance.PlayerDeath();
				gameObject.SetActive(false);
			}
			else {
				// Enemy killed logic
			}
		}
	}
}
