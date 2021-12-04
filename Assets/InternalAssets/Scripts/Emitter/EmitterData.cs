using ShootingPattern;
using UnityEngine;

namespace Emitter
{
	[CreateAssetMenu(fileName = "New Emitter", menuName = "BulletHell/Combat/Emitter", order = 51)]
	public class EmitterData : ScriptableObject
	{
		#region Fields

		[Header("General information")]

		[SerializeField]
		private string emitterName;

		[SerializeField]
		private string description;

		[SerializeField]
		private Sprite emitterSprite;

		[SerializeField] [Range(0.1f, 100.0f)] [Tooltip("Amount of shots per second")]
		private float spawnRate;
	
		[SerializeField] [Tooltip("Should be set in Inspector")]
		private BaseShootingPattern pattern;
	
		[SerializeField] [Tooltip("For different types projectile's")]
		private Projectile.Projectile projectilePrefab;
	

		#endregion

		#region Methods (getters)

		public string EmitterName => emitterName;

		public string Description => description;

		public Sprite EmitterSprite => emitterSprite;

		public float SpawnRate => spawnRate;

		public BaseShootingPattern Pattern => pattern;

		public Projectile.Projectile ProjectilePrefab => projectilePrefab;
	
		#endregion

	}
}

