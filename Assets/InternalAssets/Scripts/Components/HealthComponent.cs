using System;
using System.Collections.Generic;
using Managers;
using Player;
using Projectile;
using UnityEngine;

namespace Components
{
	/// <summary>
	/// Class-component for all who can take damage
	/// </summary>
	public class HealthComponent : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		private int maxHitPoints;
		public int MaxHitPoints => maxHitPoints;
		
		[SerializeField]
		public int currentHitPoints;

		[SerializeField] [Tooltip("Who can damage this")]
		private List<DamageSourceType> getDamagedFrom;

		#endregion

		#region Methods

		private void Start()
		{
			EventManager.Instance.OnGameStart += Init;
		}

		private void OnEnable()
		{
			Init();
		}

		private void Init()
		{
			currentHitPoints = maxHitPoints;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			var projectile = other.GetComponent<Projectile.Projectile>();
			if (projectile != null) {
				if (getDamagedFrom.FindIndex((ownerType) => ownerType == projectile.DamageSource) >= 0) {
					EffectManager.Instance.ImposeShootEffect(gameObject, projectile);
					projectile.Explode();
				}
			}
		}

		public void GetDamaged(int damageValue)
		{
			if (DebugManager.Instance.IsLogDamage) {
				Debug.Log(gameObject.name + " damaged: " + damageValue);
			}
			if (gameObject.CompareTag("Player")) {
				if (currentHitPoints <= 0) {
					gameObject.GetComponent<PlayerController>().Death(gameObject.GetInstanceID());
				}
				EventManager.Instance.PlayerHealthChange(currentHitPoints, 
					Mathf.Clamp(currentHitPoints - damageValue, 0, maxHitPoints));
			}

			currentHitPoints -= (int)(damageValue);
			if (currentHitPoints <= 0) {
				EventManager.Instance.Death(gameObject.GetInstanceID());
				if (gameObject.tag == "Player") {
					GetComponent<PlayerController>().Death(gameObject.GetInstanceID());
				}
			}

		}

		#endregion

	}
}
