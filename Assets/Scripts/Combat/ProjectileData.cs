using UnityEngine;

namespace Combat
{
	[CreateAssetMenu(fileName = "New Projectile", menuName = "Combat/Projectile", order = 52)]
	public class ProjectileData : ScriptableObject
	{
		#region Fields

		[Header("General information")]
		[Space]
		
		[SerializeField]
		private string projectileName;

		[SerializeField]
		private string description;

		[SerializeField]
		private Sprite projectileSprite;

		[Header("Parameters")]
		[Space]

		[SerializeField] [Range(0.1f, 100.0f)] [Tooltip("Initial speed when spawned")]
		private float startSpeed;
		
		[SerializeField] [Range(0.1f, 10.0f)] [Tooltip("Speed change over time")]
		private float acceleration;

		[SerializeField] [Range(0.0f, 100.0f)] [Tooltip("Projectile lifetime in seconds")]
		private float lifeTime;

		[SerializeField] [Range(0.01f, 1.0f)] [Tooltip("Collision radius")]
		private float radius;

		#endregion

		#region Methods (getters)

		public string ProjectileName => projectileName;

		public string Description => description;

		public Sprite ProjectileSprite => projectileSprite;

		public float StartSpeed => startSpeed;

		public float Acceleration => acceleration;

		public float LifeTime => lifeTime;

		public float Radius => radius;

		#endregion
	}
}
