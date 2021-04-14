using UnityEngine;

public  abstract class ShootingPattern : ScriptableObject
{
	public abstract void ShootingBehaviour(
		Transform emitterTransform,
		Projectile projectilePrefab,
		OwnerType owner
	);
}

