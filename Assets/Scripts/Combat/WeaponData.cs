using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Combat
{
	[CreateAssetMenu(fileName = "New Weapon", menuName = "Combat/Weapon", order = 51)]
	public class WeaponData : ScriptableObject
	{
		#region Fields

		[Header("General information")]

		[SerializeField]
		private string weaponName;

		[SerializeField]
		private string description;

		[SerializeField]
		private Sprite weaponSprite;

		[SerializeField]
		private ProjectileData projectileData;

		[Header("Parameters")]

		[SerializeField] [Range(0.1f, 100.0f)] [Tooltip("Amount of projectiles per second")]
		private float attackSpeed;

		#endregion

		#region Methods (getters)

		public string WeaponName => weaponName;

		public string Description => description;

		public Sprite WeaponSprite => weaponSprite;

		public ProjectileData Projectile => projectileData;

		public float AttackSpeed => attackSpeed;
		
		#endregion
	
	}
}

