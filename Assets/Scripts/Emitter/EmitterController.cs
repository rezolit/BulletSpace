using Projectile;
using UnityEngine;

namespace Emitter
{
	/// <summary>
	/// Class for all emitters
	/// </summary>
	public class EmitterController : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		private EmitterData emitterData;
		public EmitterData EmitterData {
			get => emitterData;
			set {
				emitterData = value;
				GetComponent<SpriteRenderer>().sprite = EmitterData.EmitterSprite;
			}
		}

		[HideInInspector]
		public bool isActive;

		private float _lastShootTime;

		[SerializeField]
		private DamageSourceType emitterDamageSource;

		#endregion

		#region Methods

		private void Start()
		{
			_lastShootTime = 0.0f;
		}

		private void Update()
		{
			if (isActive && _lastShootTime < Time.time - 1.0f / EmitterData.SpawnRate) {
				emitterData.Pattern.ShootingBehaviour(transform, emitterData.ProjectilePrefab, emitterDamageSource);
				_lastShootTime = Time.time;
			}
		}

		#endregion
	}
}
