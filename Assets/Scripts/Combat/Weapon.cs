using System;
using UnityEngine;

namespace Combat
{
	public class Weapon : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		private WeaponData weaponData;

		private float _lastShootTime;

		#endregion

		#region Methods

		public void Shoot(Vector3 direction)
		{
			if (_lastShootTime < (Time.time - 1.0f / weaponData.AttackSpeed)) {
				ProjectilesPool.instance.SpawnProjectile(weaponData.Projectile, transform.position, direction);
				_lastShootTime = Time.time;
			}
		}

		public void UseSpecialAbility()
		{
			print("Special");
		}

		public void ChangeWeapon(WeaponData newWeaponData)
		{
			weaponData = newWeaponData;
			GetComponent<SpriteRenderer>().sprite = weaponData.WeaponSprite;
			_lastShootTime = -100.0f;
		}

		#endregion
	}
}
