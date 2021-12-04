using Managers;
using Projectile;
using UnityEngine;

namespace ShootingPattern
{
	/// <summary>
	/// Shooting in a straight line pattern
	/// </summary>
	[CreateAssetMenu(menuName = "BulletHell/Combat/Pattern/ForwardSP")]
	public class ForwardSP : BaseShootingPattern
	{
		#region Fields

		[SerializeField]
		private int projectilesCount;

		[SerializeField]
		private float projectilesSpeed;

		[SerializeField]
		private float projectilesAcceleration;

		[SerializeField] [Tooltip("How wide the line of fire will be")]
		private float sourceWidth;

		#endregion
		

		public override void ShootingBehaviour(
			Transform emitterTransform,
			Projectile.Projectile projectilePrefab,
			DamageSourceType damageSource
		)
		{
			Projectile.Projectile[] projectiles = new Projectile.Projectile[projectilesCount];
			for (int i = 0; i < projectiles.Length; ++i) {
				projectiles[i] = PoolManager.Instance.SpawnObject(projectilePrefab.gameObject,
					emitterTransform.position, emitterTransform.rotation).GetComponent<Projectile.Projectile>();
				projectiles[i].gameObject.SetActive(true);
				projectiles[i].speed = projectilesSpeed;
				projectiles[i].acceleration = projectilesAcceleration;
				projectiles[i].movementDirection = emitterTransform.up;
			}

			var startPosition = emitterTransform.position - new Vector3(sourceWidth / 2.0f, 0.0f, 0.0f);

			for (int i = 0; i < projectilesCount; i++) {
				projectiles[i].transform.position = startPosition + new Vector3(
						(sourceWidth / (projectilesCount - 1 == 0 ? 1 : projectilesCount - 1)) * i,
						0.0f,
						0.0f
					);
				projectiles[i].DamageSource = damageSource;
			}
		}
	}
}