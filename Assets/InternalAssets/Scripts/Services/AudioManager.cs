using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
	[SerializeField]
	private AudioSource musicSource;

	[SerializeField]
	private AudioSource effectsSource;

	[SerializeField]
	private AudioClip playerShootSound;
	
	[SerializeField]
	private AudioClip enemyShootSound;

	private void Start()
	{
		EventManager.Instance.OnPlayerShoot += PlayShootSound;
		EventManager.Instance.OnEnemyShoot += PlayEnemyShootSound;
	}

	private void PlayShootSound()
	{
		effectsSource.clip = playerShootSound;
		effectsSource.Play();
	}

	private void PlayEnemyShootSound()
	{
		effectsSource.clip = enemyShootSound;
		effectsSource.Play();
	}
	
	
	
}
