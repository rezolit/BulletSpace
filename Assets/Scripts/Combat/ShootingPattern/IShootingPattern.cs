using UnityEngine;

namespace Combat
{
	public interface IShootingPattern
	{
		void ShootingBehaviour(Transform emitterTransform, float lifeTime);
	}
}
