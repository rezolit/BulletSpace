using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace Player
{
	/// <summary>
	/// Player's combat logic (shooting and taking damage)
	/// </summary>
	public class PlayerCombatBehaviour : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		private Emitter emitter;

		[SerializeField] [Tooltip("All allowed emitters for player")]
		private List<EmitterData> emitterDatas;

		[SerializeField]
		private int maxHitPoints;

		private int _currentHitPoints;

		#endregion

		#region Methods

		private void Awake()
		{
			if (emitter == null) {
				emitter = transform.GetChild(0).GetComponent<Emitter>();
			}
			
			emitter.EmitterData = emitterDatas[0];
		}

		private void Start()
		{
			_currentHitPoints = maxHitPoints;
		}

		private void Update()
		{
			if (Time.time > 10.0f) {
				emitter.EmitterData = emitterDatas[1];
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			print(name + "'s HP: " + --_currentHitPoints);
		}

		public void SetShootingMode(bool isShooting)
		{
			emitter.isActive = isShooting;
		}

		#endregion
	}
}
