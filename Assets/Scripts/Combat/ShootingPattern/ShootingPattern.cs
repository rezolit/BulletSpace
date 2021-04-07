using UnityEngine;

namespace Combat
{
	public  abstract class ShootingPattern : ScriptableObject, IShootingPattern
	{
		public abstract void ShootingBehaviour(Transform emitterTransform, float lifeTime);
	}
}
