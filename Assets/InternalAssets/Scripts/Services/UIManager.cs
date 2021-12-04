using System.Collections.Generic;
using Effect;
using Managers;
using Projectile;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
	[Header("Helthbar")]
	[SerializeField]
	private Sprite fullHit;
	[SerializeField]
	private Sprite emptyHit;
	[SerializeField]
	private int maxHits;
	[SerializeField]
	private Image[] _images;

	[Header("Bonuses")]

	[Header("Slots")]
	[SerializeField]
	private Image bonuses;
	[SerializeField]
	private Image redBonus;
	[SerializeField]
	private Image greenBonus;
	[SerializeField]
	private Image blueBonus;
	[SerializeField]
	private Image globalBonus;

	[Header("Sprites")]
	[SerializeField]
	private Sprite X2Damage;
	[SerializeField]
	private Sprite slowTime;
	[SerializeField]
	private Sprite meteorRain;
	[Space]
	[SerializeField]
	private Sprite slowSpeed;
	[SerializeField]
	private Sprite drunk;
	[SerializeField]
	private Sprite speedUp;
	[Space]
	[SerializeField]
	private Sprite nothing;
	
	[SerializeField]
	private SerializedDictionary<BonusType, Sprite> bonusesSprites;

	[Header("Menu, button")]
	[SerializeField]
	private Button startButton;
	[SerializeField]
	private Button continueButton;
	[SerializeField]
	private Button exitButton;
	[SerializeField]
	private Button restartButton;
	[SerializeField]
	private Image pauseText;

	[SerializeField]
	private Image deathText;

	[SerializeField]
	private Image guideText;

	[SerializeField]
	private Image congratulationText;
	
	private void Start()
	{
		bonusesSprites = new SerializedDictionary<BonusType, Sprite> {
			[BonusType.Drunk] = drunk,
			[BonusType.MeteorRain] = meteorRain,
			[BonusType.SlowSpeed] = slowSpeed,
			[BonusType.SlowTime] = slowTime,
			[BonusType.SpeedUp] = speedUp,
			[BonusType.X2Damage] = X2Damage,
			[BonusType.Nothing] = nothing
		};
		
		EventManager.Instance.OnPlayerHealthChange += ChangeHealth;
		EventManager.Instance.OnBonusesChange += ChangeBonuses;
		EventManager.Instance.OnGamePause += ShowPauseMenu;
		EventManager.Instance.OnGameContinue += HidePauseMenu;
		EventManager.Instance.OnMainMenu += ShowMainMenu;
		EventManager.Instance.OnPlayerDeath += ShowDeathMenu;
		EventManager.Instance.OnBossKilled += ShowFinalScreen;

		HidePauseMenu();
	}

	private void ChangeHealth(int oldVal, int newVal) {
		for (int i = 0; i < _images.Length; i++) {
			_images[i].sprite = i < newVal ? fullHit : emptyHit;
			_images[i].enabled = i < maxHits ? true : false;
		}	
	}

	private void ShowDeathMenu()
	{
		deathText.enabled = true;
		restartButton.image.enabled = true;
		
	}

	private void ShowFinalScreen()
	{
		restartButton.image.enabled = true;
		congratulationText.enabled = true;
	}

	private void ShowMainMenu()
	{
		startButton.image.enabled = true;
		guideText.enabled = true;
		
		pauseText.enabled = false;
		continueButton.image.enabled = false;
		restartButton.image.enabled = false;
		exitButton.image.enabled = false;
		
		bonuses.enabled = false;
		blueBonus.enabled = false;
		redBonus.enabled = false;
		greenBonus.enabled = false;
		globalBonus.enabled = false;
		
		deathText.enabled = false;
		congratulationText.enabled = false;
		
		
		foreach (Image hpImage in _images) {
			hpImage.enabled = false;
		}
	}

	private void ShowPauseMenu()
	{
		startButton.image.enabled = false;
		pauseText.enabled = true;
		continueButton.image.enabled = true;
		restartButton.image.enabled = true;
		exitButton.image.enabled = true;
		
		deathText.enabled = false;
		guideText.enabled = false;
		
		congratulationText.enabled = false;
	}
	
	private void HidePauseMenu()
	{
		startButton.image.enabled = false;
		pauseText.enabled = false;
		continueButton.image.enabled = false;
		restartButton.image.enabled = false;
		exitButton.image.enabled = false;
		
		deathText.enabled = false;
		guideText.enabled = false;
		congratulationText.enabled = false;
	}

	public void StartGame()
	{
		EventManager.Instance.ChangeGameState(GameState.Start);	
		bonuses.enabled = true;
		blueBonus.enabled = true;
		redBonus.enabled = true;
		greenBonus.enabled = true;
		globalBonus.enabled = true;
		foreach (Image hpImage in _images) {
			hpImage.enabled = true;
		}
		deathText.enabled = false;
		guideText.enabled = false;
		congratulationText.enabled = false;
	}

	public void ContinueGame()
	{
		EventManager.Instance.ChangeGameState(GameState.Continue);	
	}

	public void RestartGame()
	{
		EventManager.Instance.ChangeGameState(GameState.Start);
	}

	public void ExitGame()
	{
		EventManager.Instance.ChangeGameState(GameState.Exit);
	}
	
	private void ChangeBonuses(
		BonusType redBonus,
		BonusType greenBonus,
		BonusType blueBonus,
		BonusType globalBonus
	)
	{
		this.redBonus.sprite = bonusesSprites[redBonus];
		this.greenBonus.sprite = bonusesSprites[greenBonus];
		this.blueBonus.sprite = bonusesSprites[blueBonus];
		this.globalBonus.sprite = bonusesSprites[globalBonus];

	}
}
