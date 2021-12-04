using UnityEngine;
using UnityEngine.SceneManagement;


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
		public bool isMeteorRainActive;
		public bool isGamePaused;

		#endregion

		#region Methods

		private void Start()
		{
			Init();
			EventManager.Instance.ChangeGameState(GameState.MainMenu);
			PauseGame();
			
			EventManager.Instance.OnGameStart += Init;
			EventManager.Instance.OnGamePause += PauseGame;
			EventManager.Instance.OnGameContinue += ContinueGame;
			EventManager.Instance.OnGameExit += ExitGame;
			EventManager.Instance.OnPlayerDeath += StopGame;
			EventManager.Instance.OnBossKilled += EndGame;
		}

		private void Init()
		{
			StopAllCoroutines();
			
			levelTimer = 0.0f;
			
			earnedPoints = 0;
			currentLevel = 0;
			damageMultiplier = 1.0f;
			speedMultiplier = 1.0f;
			SetupLevel(currentLevel);
			isGamePaused = false;
			isMeteorRainActive = false;
			EventManager.Instance.ChangeGameState(GameState.Continue);
		}

		private void Update()
		{
			levelTimer += Time.deltaTime * speedMultiplier;
		}

		private void EndGame()
		{
			StopGame();
		}

		private void StopGame()
		{
			Time.timeScale = 0.0f;
			isGamePaused = true;
		}

		private void SetupLevel(int levelNum)
		{
			Debug.Log("Level " + levelNum + " loaded");
		}

		private void PauseGame()
		{
			if (isGamePaused) {
				EventManager.Instance.ChangeGameState(GameState.Continue);
				Time.timeScale = 1.0f;
				isGamePaused = false;
			}
			else {
				Time.timeScale = 0.0f;
				isGamePaused = true;
			}
		}
		
		private void ContinueGame()
		{
			Time.timeScale = 1.0f;
			isGamePaused = false;
		}

		private void ExitGame()
		{
			
		}

		public LevelData GetCurrentLevel => levels[currentLevel];

		#endregion

	}
}
