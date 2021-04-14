using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// General class-component for all enemies
/// </summary>
[RequireComponent(typeof(MovementComponent))]
public class Enemy : MonoBehaviour
{
	#region Fields
	
	[SerializeField]
	private EnemyData enemyData;

	private List<Emitter>  _emitters;

	public EnemyData EnemyData {
		get => enemyData;
		set => enemyData = value;
	}

	#endregion

	#region Methods

	private void Awake()
	{
		_emitters = new List<Emitter>();

		var childEmitters = gameObject.GetComponentsInChildren<Emitter>();
		foreach (Emitter emitter in childEmitters) {
			_emitters.Add(emitter);
		}
	}

	private void Start()
	{
		foreach (Emitter emitter in _emitters) {
			emitter.isActive = true;
		}
		
		EventManager.Instance.OnDeath += Death;
	}

	private void Update()
	{
		if (!GlobalPoints.Instance.IsInsideBorders(transform.position, 2.0f)) {
			EventManager.Instance.Death(gameObject.GetInstanceID());
		}
	}

	private void Death(int id)
	{
		if (id == gameObject.GetInstanceID()) {
			var movementComponent = GetComponent<MovementComponent>();
			movementComponent.StopCoroutine(movementComponent.Coroutine);
			EventManager.Instance.OnDeath -= Death;
			PoolManager.Instance.ReleaseObject(gameObject);
		}
	}
	

	#endregion
}
