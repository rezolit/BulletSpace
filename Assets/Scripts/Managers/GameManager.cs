using UnityEngine;


namespace Managers
{
	public class GameManager : Singleton<GameManager>
	{
		#region Fields

		[SerializeField]
		private LevelData[] levels;
	
		public int currentLevel;
		public int earnedPoints;
		public float levelTimer;
		public float damageMultiplier;
		public float speedMultiplier;

		#endregion

		#region Methods

		private void Start()
		{
			earnedPoints = 0;
			currentLevel = 0;
			damageMultiplier = 1.0f;
			speedMultiplier = 1.0f;
			SetupLevel(currentLevel);
		}

		private void Update()
		{
			levelTimer += Time.deltaTime;
		}

		private void SetupLevel(int levelNum)
		{
			Debug.Log("Level " + levelNum + " loaded");
			// SceneManager.LoadScene(levelNum);
		}

		public LevelData GetCurrentLevel => levels[currentLevel];

		#endregion

	}
}
