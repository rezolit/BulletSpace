using System.Collections.Generic;
using Enemy;
using Managers;
using UnityEngine;

[System.Serializable]
public struct SpawnInfo
{
	public PointType spawnPointType;
	public EnemyController enemyController;
}

[System.Serializable]
public struct EnemiesWave
{
	public List<SpawnInfo> enemies;
	public float spawnTime;
} 

[CreateAssetMenu(fileName = "New Level Data", menuName = "Level", order = 54)]
public class LevelData : ScriptableObject
{
	#region Fields

	[SerializeField]
	private string levelName;

	[SerializeField]
	private Sprite levelImage;

	[SerializeField]
	private List<EnemiesWave> enemiesWaves;

	#endregion

	#region Methods

	public string LevelName => levelName;

	public Sprite LevelImage => levelImage;

	public List<EnemiesWave> EnemiesWaves => enemiesWaves;

	#endregion

}
