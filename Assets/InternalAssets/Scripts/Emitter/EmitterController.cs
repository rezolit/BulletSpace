using Managers;
using Projectile;
using UnityEngine;

namespace Emitter
{
	/// <summary>
	/// Class for all emitters
	/// </summary>
	[RequireComponent(typeof(SpriteRenderer))]
	public class EmitterController : MonoBehaviour
	{
		#region Fields

		[SerializeField]
		private float timeOffset;
		
		[SerializeField]
		private EmitterData emitterData;
		public EmitterData EmitterData {
			get => emitterData;
			set {
				emitterData = value;
				GetComponent<SpriteRenderer>().sprite = EmitterData.EmitterSprite;
			}
		}
		
		
		public bool isActive;

		private float _lastShootTime;

		[SerializeField]
		private DamageSourceType emitterDamageSource;

		#endregion

		#region Methods

		private void Start()
		{
			EventManager.Instance.OnGameStart += Init;
		}

		private void Init()
		{
			_lastShootTime = timeOffset;
		}

		private void Update()
		{
			if (isActive && _lastShootTime < GameManager.Instance.levelTimer - 1.0f / EmitterData.SpawnRate) {
				emitterData.Pattern.ShootingBehaviour(transform, emitterData.ProjectilePrefab, emitterDamageSource);
				_lastShootTime = GameManager.Instance.levelTimer;

				if (emitterDamageSource == DamageSourceType.Enemy) {
					EventManager.Instance.EnemyShoot();
				}

				if (emitterDamageSource == DamageSourceType.Player) {
					EventManager.Instance.PlayerShoot();
				}
			}
		}

		#endregion
	}
}
