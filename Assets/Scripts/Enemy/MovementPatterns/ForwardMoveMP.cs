using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MovementPattern", menuName = "Enemy/ForwardMP", order = 52)]
public class ForwardMoveMP : MovementPattern
{
	public override void MovementBehaviour(Transform enemyTransform, float movementSpeed, float lifeTime)
	{
		enemyTransform.position += Vector3.down * (movementSpeed * Time.deltaTime);
	}
}
