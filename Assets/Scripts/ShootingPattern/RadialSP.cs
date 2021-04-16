using Managers;
using Projectile;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace ShootingPattern
{
	[CreateAssetMenu(menuName = "Combat/Pattern/RadialSP")]
	public class RadialSP : BaseShootingPattern
	{
		#region Fields

		[Header("Projectiles")]
		[SerializeField] [Range(0, 10)]
		private int projectilesCount;
		
		[SerializeField] [Range(0.0f, 20.0f)]
		private float projectilesSpeed;

		[SerializeField] [Range(0.0f, 1.0f)]
		private float projectilesAcceleration;
		
		[SerializeField] [Range(0.0f, 10.0f)]
		private float projectilesMinSpeed;

		[Header("Angles")]
		[SerializeField] [Range(0.0f, 360.0f)]
		private float angleFrom;
	
		[SerializeField] [Range(0.0f, 360.0f)]
		private float angleTo;
		
		[Header("Arrays")]
		[SerializeField] [Range(1, 10)]
		private int arraysCount;

		[SerializeField] [Range(0.0f, 360.0f)]
		private float arraySpread;

		[Header("Spin")]
		[SerializeField] [Range(-10, 10)]
		private float spinSpeed;

		[SerializeField] [Range(0, 1)]
		private float directionChangeSpeed;
		
		#endregion
	
		public override void ShootingBehaviour(
			Transform emitterTransform,
			Projectile.Projectile projectilePrefab,
			DamageSourceType damageSource
		)
		{
			for (int i = 0; i < arraysCount; i++) {
				Projectile.Projectile[] projectiles = new Projectile.Projectile[projectilesCount];
				var startAngle = arraySpread * i;
				var deltaAngle = (angleTo - angleFrom) / (projectilesCount == 1 ? 1 : projectilesCount - 1);
				for (int j = 0; j < projectiles.Length; ++j) {
					var directionAngle = startAngle + j * deltaAngle;
					var modifiedAngle =
						Mathf.Deg2Rad * directionAngle +
						(Mathf.Sin(Time.time * directionChangeSpeed) * spinSpeed)
					;
					Vector3 directionVector = new Vector3(
						Mathf.Sin(modifiedAngle),
						Mathf.Cos(modifiedAngle),
						0
					);
					projectiles[j] = PoolManager.Instance.SpawnObject(projectilePrefab.gameObject,
						emitterTransform.position, Quaternion.identity).GetComponent<Projectile.Projectile>();
					projectiles[j].gameObject.SetActive(true);
					projectiles[j].speed = projectilesSpeed;
					projectiles[j].minSpeed = projectilesMinSpeed;
					projectiles[j].acceleration = projectilesAcceleration;
					projectiles[j].movementDirection = directionVector;
					projectiles[j].DamageSource = damageSource;
				}
			}
		}
	}
}
