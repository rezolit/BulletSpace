using System;
using System.Collections.Generic;
using Emitter;
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

		#endregion

		#region Methods

		private void Awake()
		{
			emitterController = transform.GetChild(0).GetComponent<EmitterController>();
			if (emitterController == null) {
				throw new Exception("Add allowed emitters to player");
			}
			emitterController.EmitterData = allowedEmitters[0];
		}

		public void SetShootingMode(bool isShooting)
		{
			emitterController.isActive = isShooting;
		}

		#endregion
	}
}
