using System.Collections;
using Components;
using PathCreation;
using UnityEngine;

namespace MovementPatterns
{
	[CreateAssetMenu(fileName = "New MovementPattern", menuName = "BulletHell/MovementPattern/ArcMoveMP", order = 53)]
	public class ArcMoveMP : BaseMovementPattern
	{
		[SerializeField]
		private PathCreator pathCreator;

		public override IEnumerator MovementBehaviour(Transform transform, MovementComponent movementComponent)
		{
			float distance = 0.0f;
			
			while (transform.position != pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1)) {
				yield return null;
				distance += Time.deltaTime * movementComponent.MovementSpeed;
				transform.position = pathCreator.path.GetPointAtDistance(distance, EndOfPathInstruction.Stop);
			}
		}
	}
}
