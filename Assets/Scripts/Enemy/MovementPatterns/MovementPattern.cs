using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementPattern : ScriptableObject, IMovementPattern
{
	public abstract void MovementBehaviour(Transform enemyTransform, float movementSpeed, float lifeTime);

}
