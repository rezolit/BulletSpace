using UnityEngine;

namespace Managers
{
	public class EnemiesManager : Singleton<EnemiesManager>
	{
		#region Fields
	
		private int _step;

		#endregion

		#region Methods

		private void Start()
		{
			_step = 0;
		}

		private void Update()
		{
			if (_step >= GameManager.Instance.GetCurrentLevel.EnemiesWaves.Count) return;
		
			var enemiesWave = GameManager.Instance.GetCurrentLevel.EnemiesWaves[_step];
			if (enemiesWave.spawnTime <= GameManager.Instance.levelTimer) {
				foreach (var enemy in enemiesWave.enemies) {
					PoolManager.Instance.SpawnObject(enemy.enemyController.gameObject,
						GlobalPoints.Instance.GetPointByEnum(enemy.spawnPointType).position,
						Quaternion.identity);
					if (DebugManager.Instance.IsLogSpawnInfo) {
						Debug.Log("Spawned new enemy " + enemy.enemyController.name);
					}
				}

				_step++;
			}
		}

		#endregion
	
	}
}
