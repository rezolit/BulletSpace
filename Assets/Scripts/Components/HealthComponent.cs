using System.Collections.Generic;
using Managers;
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

		private int _currentHitPoints;

		[SerializeField] [Tooltip("Who can damage this")]
		private List<DamageSourceType> getDamagedFrom;

		#endregion

		#region Methods

		private void Start()
		{
			_currentHitPoints = maxHitPoints;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			var projectile = other.GetComponent<Projectile.Projectile>();
			if (projectile != null) {
				if (getDamagedFrom.FindIndex((ownerType) => ownerType == projectile.DamageSource) != -1) {
					GetDamaged(projectile.Damage);
					projectile.Deactivate();
				}
			}
		}
	
		private void GetDamaged(int damageValue)
		{
			if (DebugManager.Instance.IsLogDamage) {
				Debug.Log(gameObject.name + " damaged: " + damageValue);
			}

			_currentHitPoints -= damageValue;
			if (_currentHitPoints <= 0) {
				EventManager.Instance.Death(gameObject.GetInstanceID());
			}
		}

		#endregion

	}
}
