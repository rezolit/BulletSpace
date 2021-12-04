using System;
using UnityEngine;

namespace Managers
{
	public enum GameState
	{
		Start,
		GameOver,
		Pause,
		Continue,
		Exit,
		MainMenu
	}
	
	public class EventManager : Singleton<EventManager>
	{
		#region Fields
		
		public delegate void DeathMethod(int id);
		public delegate void HealthChange(int oldVal, int newVal);
		public delegate void GameStateChange();

		public event GameStateChange OnGameStart;
		public event GameStateChange OnMainMenu;
		public event GameStateChange OnGameOver;
		public event GameStateChange OnGamePause;
		public event GameStateChange OnGameContinue;
		public event GameStateChange OnGameExit;
		public event GameStateChange OnPlayerDeath;

		public event GameStateChange OnPlayerShoot;
		public event GameStateChange OnEnemyShoot;

		public event GameStateChange OnBossKilled;
		public event DeathMethod OnDeath;
		public event HealthChange OnPlayerHealthChange;
		
		public delegate void BonusesChange(
			BonusType redBonus,
			BonusType greenBonus,
			BonusType blueBonus,
			BonusType globalBonus
		);

		public event BonusesChange OnBonusesChange;

		#endregion

		#region Methods

		public void Death(int id)
		{
			OnDeath?.Invoke(id);
		}

		public void ChangeGameState(GameState gameState)
		{
			Debug.Log(gameState);
			switch (gameState) {
				case GameState.Start:
					OnGameStart?.Invoke();
					break;
				case GameState.GameOver:
					OnGameOver?.Invoke();
					break;
				case GameState.Pause:
					OnGamePause?.Invoke();
					break;
				case GameState.Continue:
					OnGameContinue?.Invoke();
					break;
				case GameState.Exit:
					OnGameExit?.Invoke();
					break;
				case GameState.MainMenu:
					OnMainMenu?.Invoke();
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
			}
		}

		public void PlayerDeath()
		{
			OnPlayerDeath?.Invoke();
		}

		public void PlayerShoot()
		{
			OnPlayerShoot?.Invoke();
		}
		
		public void EnemyShoot()
		{
			OnEnemyShoot?.Invoke();
		}

		public void BossKilled()
		{
			OnBossKilled?.Invoke();
		}
		

		public void PlayerHealthChange(int oldVal, int newVal)
		{
			OnPlayerHealthChange?.Invoke(oldVal, newVal);
		}
		
		public void BonusesChangeNotify(
			BonusType redBonus,
			BonusType greenBonus,
			BonusType blueBonus,
			BonusType globalBonus)
		{
			OnBonusesChange?.Invoke(redBonus, greenBonus, blueBonus, globalBonus);
		}
	
		#endregion

	}
}
