using Managers;
using UnityEngine;

namespace Projectile
{
	/// <summary>
	/// Who is projectile's owner
	/// </summary>
	public enum DamageSourceType
	{
		Player,
		Enemy
	}

	public enum ProjectileType
	{
		Red,
		Green,
		Blue,
		Yellow
	}

	[RequireComponent(typeof(Animator))]
	public class Projectile : MonoBehaviour
	{
		#region Fields

		[HideInInspector]
		public Vector3 movementDirection;
		[HideInInspector]
		public float speed;
		[HideInInspector]
		public float minSpeed;
		[HideInInspector]
		public float angularSpeed;
		[HideInInspector]
		public float acceleration;
		[HideInInspector]
		public float angularAcceleraion;
		[HideInInspector]
		public bool isTargetAiming;
		[HideInInspector]
		public float jitterAmount;
		[HideInInspector]
		public float currentLifetime;
	
		public DamageSourceType DamageSource { get; set; }

		[SerializeField]
		private int damage;

		public int Damage => damage;

		[SerializeField]
		private ProjectileType projectileType;
		private static readonly int OnExplosion = Animator.StringToHash("OnExplosion");

		public ProjectileType ProjectileType => projectileType;

		#endregion

		#region Methods

		private void Start()
		{
			currentLifetime = 0.0f;
		}

		private void Update()
		{
			ProjectileBehaviour();
		}

		private void ProjectileBehaviour()
		{
			currentLifetime += Time.deltaTime;
			speed *= acceleration;
			if (speed <= minSpeed) {
				speed = minSpeed;
			}
			// TODO speed
			transform.position += movementDirection * (speed * GameManager.Instance.speedMultiplier * Time.deltaTime);

			if (!GlobalPoints.Instance.IsInsideBorders(transform.position, GlobalPoints.Instance.projectilesOffset)) {
				Deactivate();
			}
		}

		public void Explode()
		{
			var animator = GetComponent<Animator>();
			if (animator.runtimeAnimatorController != null) {
				animator.SetTrigger(OnExplosion);
			}
			else {
				Deactivate();
			}
		}

		public void Deactivate()
		{
			PoolManager.Instance.ReleaseObject(gameObject);
		}


		#endregion

	}
}