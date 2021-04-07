using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	#region Fields
	
	[SerializeField]
	private EnemyData enemyData;

	private List<Emitter>  emitters;

	public EnemyData EnemyData {
		get => enemyData;
		set {
			enemyData = value;
			GetComponent<SpriteRenderer>().sprite = enemyData.Sprite;
		}
	}

	private int	  _maxHitPoints;
	private int   _currentHitPoints;
	private float _lifeTime;

	#endregion

	#region Methods

	private void Awake()
	{
		emitters = new List<Emitter>();

		var childEmitters = gameObject.GetComponentsInChildren<Emitter>();
		foreach (Emitter emitter in childEmitters) {
			emitters.Add(emitter);
		}
	}

	private void Start()
	{
		_currentHitPoints = _maxHitPoints;
		_lifeTime = 0.0f;
		GetComponent<SpriteRenderer>().sprite = enemyData.Sprite;

		// TODO activating emitters
		foreach (Emitter emitter in emitters) {
			emitter.isActive = true;
		}
	}

	private void Update()
	{
		_lifeTime += Time.deltaTime;
		enemyData.MovementPattern.MovementBehaviour(transform, enemyData.MovementSpeed, _lifeTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		print(name + "'s HP: " + --_currentHitPoints);
	}

	#endregion
}
