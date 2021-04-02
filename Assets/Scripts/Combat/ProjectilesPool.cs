using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
	/// <summary>
	/// Singleton class that handles and process all the projectiles
	/// </summary>
	public class ProjectilesPool : MonoBehaviour
	{
		#region Fields

		public static ProjectilesPool instance = null;

		[SerializeField]
		private GameObject projectilePrefab;

		private List<GameObject> _projectiles;

		private bool isEnoughProjectilesInPool = false;

		#endregion

		#region Methods

		void Awake()
		{
			if (instance == null) {
				instance = this;
			}
			else if (instance == this) {
				Destroy(gameObject);
			}
			DontDestroyOnLoad(gameObject);
		}

		private void Start()
		{
			Initialize();
		}

		public GameObject GetProjectile()
		{
			if (_projectiles.Count > 0) {
				for (int i = 0; i < _projectiles.Count; i++) {
					if (!_projectiles[i].activeInHierarchy) {
						return _projectiles[i];
					}
				}
			}

			if (!isEnoughProjectilesInPool) {
				GameObject newProjectile = Instantiate(projectilePrefab);
				newProjectile.SetActive(false);
				_projectiles.Add(newProjectile);
				return newProjectile;
			}

			return null;
		}

		public void SpawnProjectile(ProjectileData projectileData, Vector3 position, Vector3 direction)
		{
			GameObject newProjectile = Instantiate(
				projectilePrefab,
				position,
				Quaternion.Euler(direction), transform
			);
			newProjectile.GetComponent<Projectile>().Initialize(projectileData, direction);
		}

		private void Initialize()
		{
			_projectiles = new List<GameObject>();
		}

		#endregion
	}
}
