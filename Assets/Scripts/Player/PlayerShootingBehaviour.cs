using System;
using System.Collections.Generic;
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
		private Emitter emitter;

		[SerializeField] [Tooltip("All allowed emitters for player")]
		private List<EmitterData> allowedEmitters;

		#endregion

		#region Methods

		private void Awake()
		{
			emitter = transform.GetChild(0).GetComponent<Emitter>();
			if (emitter == null) {
				throw new Exception("Add allowed emitters to player");
			}
			emitter.EmitterData = allowedEmitters[0];
		}

		public void SetShootingMode(bool isShooting)
		{
			emitter.isActive = isShooting;
		}

		#endregion
	}
}
