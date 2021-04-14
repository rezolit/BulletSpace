using System.Collections;
using UnityEngine;

namespace MovementPatterns
{
	[CreateAssetMenu(fileName = "New MovementPattern", menuName = "MovementPattern/ForwardMP", order = 52)]
	public class ForwardMoveMP : BaseMovementPattern
	{
		public override IEnumerator MovementBehaviour(Transform transform, float movementSpeed)
		{
			while (true) {
				yield return null;
				transform.position += Vector3.down * movementSpeed;
			}
		}
	}
}
