using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
	/// <summary>
	/// Legace class for pooling projectiles (replaced by PoolManager)
	/// </summary>
	public class ProjectilesPool : MonoBehaviour
	{
		#region Fields

		public static ProjectilesPool instance = null;
		public List<List<Projectile.Projectile>> projectiles;
		public List<Projectile.Projectile> projectilePrefabs;
	
		[SerializeField] [Range(1, 512)] [Tooltip("Amount of objects on Start")]
		private int amountToPool;

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

		public Projectile.Projectile GetProjectile(Projectile.Projectile projectilePrefab)
		{
			int index = projectilePrefabs.FindIndex((value) => value == projectilePrefab);
			Projectile.Projectile tmp;
		
			// If not found projectilePrefab in List's, create new List for current Prefabs
			if (index == -1) {
				projectiles.Add(new List<Projectile.Projectile>());
				projectilePrefabs.Add(projectilePrefab);
				for (int j = 0; j < amountToPool; j++) {
					tmp = Instantiate(projectilePrefab);
					tmp.gameObject.SetActive(false);
					projectiles[projectiles.Count - 1].Add(tmp);
				}

				return projectiles[projectiles.Count - 1][0];
			}
		
			// Pick projectile from existing List
			for (int i = 0; i < projectiles[index].Count; ++i) {
				if (!projectiles[index][i].gameObject.activeInHierarchy) {
					return projectiles[index][i];
				}
			}
		
			// If not enough free projectiles, create new
			tmp = Instantiate(projectilePrefab);
			tmp.gameObject.SetActive(false);
			projectiles[index].Add(tmp);
			return tmp;
		}

		private void Initialize()
		{
			projectiles = new List<List<Projectile.Projectile>>();
		
			for (int i = 0; i < projectilePrefabs.Count; ++i) {
				projectiles.Add(new List<Projectile.Projectile>());
				for (int j = 0; j < amountToPool; j++) {
					Projectile.Projectile tmp = Instantiate(projectilePrefabs[i]);
					tmp.gameObject.SetActive(false);
					projectiles[i].Add(tmp);
				}
			}
		
		}

		#endregion
	}
}
