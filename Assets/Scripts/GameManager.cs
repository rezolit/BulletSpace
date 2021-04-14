using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GameManager : Singleton<GameManager>
{
	#region Fields

	[SerializeField]
	private LevelData[] levels;
	
	public int currentLevel;
	public int earnedPoints;
	public float levelTimer;

	#endregion

	#region Methods

	private void Start()
	{
		earnedPoints = 0;
		currentLevel = 0;
	}

	private void Update()
	{
		levelTimer += Time.deltaTime;
	}

	private void SetupLevel(int levelNum)
	{
		// SceneManager.LoadScene(levelNum);
	}

	public LevelData GetCurrentLevel => levels[currentLevel];

	#endregion

}
