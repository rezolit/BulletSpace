using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

namespace Player
{
	public class PlayerWeaponBehaviour : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		private Weapon weaponSocket;

		[SerializeField]
		private WeaponData defaultWeaponData;
		
		[SerializeField]
		private WeaponData currentWeaponData;

		[HideInInspector]
		public bool isShooting;
		
		#endregion

		#region Methods

		private void Awake()
		{
			if (weaponSocket == null) {
				weaponSocket = transform.GetChild(0).GetComponent<Weapon>();
			}

			isShooting = false;
		}

		private void Update()
		{
			if (isShooting) {
				weaponSocket.Shoot(Vector3.up);
			}
		}

		private void ChangeWeapon(WeaponData newWeaponData)
		{
			weaponSocket.ChangeWeapon(newWeaponData);
		}

		public void Initialization()
		{
			weaponSocket.ChangeWeapon(defaultWeaponData);
		}

		#endregion
	}
}
