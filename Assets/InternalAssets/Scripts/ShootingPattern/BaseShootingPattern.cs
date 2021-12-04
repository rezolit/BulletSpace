using Projectile;
using UnityEngine;

namespace ShootingPattern
{
	public  abstract class BaseShootingPattern : ScriptableObject
	{
		public abstract void ShootingBehaviour(
			Transform emitterTransform,
			Projectile.Projectile projectilePrefab,
			DamageSourceType damageSource
		);
	}
}

