using System;
using System.Collections.Generic;
using Emitter;
using Managers;
using UnityEngine;

namespace Player
{
	/// <summary>
	/// Player's combat logic (shooting)
	/// </summary>
	public class PlayerShootingBehaviour : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		private EmitterController emitterController;

		[SerializeField] [Tooltip("All allowed emitters for player")]
		private List<EmitterData> allowedEmitters;

		[SerializeField]
		private float timeToNextEmitter;

		private float _timer;

		private int currentEmitterNum;

		#endregion

		#region Methods

		private void Awake()
		{
			emitterController = transform.GetChild(0).GetComponent<EmitterController>();
			if (emitterController == null) {
				throw new Exception("Add allowed emitters to player");
			}
		}

		private void Start()
		{
			Init();

			EventManager.Instance.OnGameStart += Init;
		}

		private void Init()
		{
			currentEmitterNum = 0;
			_timer = timeToNextEmitter;
			emitterController.EmitterData = allowedEmitters[0];
		}

		private void Update()
		{
			if (GameManager.Instance.levelTimer >= _timer 
			    && currentEmitterNum < allowedEmitters.Count - 1) {
				emitterController.EmitterData = allowedEmitters[++currentEmitterNum];
			}
		}

		public void SetShootingMode(bool isShooting)
		{
			emitterController.isActive = isShooting;
		}

		#endregion
	}
}
