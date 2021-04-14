using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : Singleton<EnemiesManager>
{
	#region Fields
	
	private int step;

	#endregion

	#region Methods

	private void Start()
	{
		step = 0;
	}

	private void Update()
	{
		if (step >= GameManager.Instance.GetCurrentLevel.EnemiesWaves.Count) return;
		
		var enemiesWave = GameManager.Instance.GetCurrentLevel.EnemiesWaves[step];
		if (enemiesWave.spawnTime <= GameManager.Instance.levelTimer) {
			foreach (var enemy in enemiesWave.enemies) {
				PoolManager.Instance.SpawnObject(enemy.enemy.gameObject,
					GlobalPoints.Instance.GetPointByEnum(enemy.spawnPointType).position,
					Quaternion.identity);
			}

			step++;
		}
	}

	#endregion
	
}
