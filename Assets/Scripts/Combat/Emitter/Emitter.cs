using System;
using UnityEngine;
using UnityEngineInternal;

namespace Combat
{
	/// <summary>
	/// Class for all emitters
	/// </summary>
	public class Emitter : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		private EmitterData _emitterData;

		[SerializeField]
		public EmitterData EmitterData {
			get => _emitterData;
			set {
				_emitterData = value;
				GetComponent<SpriteRenderer>().sprite = EmitterData.EmitterSprite;
			}
		}

		[HideInInspector]
		public bool isActive;

		private float _lastShootTime;
		private float _lifeTime;

		#endregion

		#region Methods

		private void Start()
		{
			_lastShootTime = 0.0f;
			_lifeTime = 0.0f;
		}

		private void Update()
		{
			_lifeTime += Time.deltaTime;
			if (isActive && _lastShootTime < Time.time - 1.0f / EmitterData.SpawnRate) {
				_emitterData.Pattern.ShootingBehaviour(transform, _lifeTime);
				_lastShootTime = Time.time;
			}
		}

		#endregion
	}
}
