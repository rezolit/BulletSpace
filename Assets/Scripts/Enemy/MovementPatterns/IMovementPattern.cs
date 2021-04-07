using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementPattern
{
	public void MovementBehaviour(Transform enemyTransform, float movementSpeed, float lifeTime);
}
