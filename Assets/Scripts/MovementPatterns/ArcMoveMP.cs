using System.Collections;
using UnityEngine;
using PathCreation;

[CreateAssetMenu(fileName = "New MovementPattern", menuName = "MovementPattern/ArcMoveMP", order = 53)]
public class ArcMoveMP : MovementPattern
{
	[SerializeField]
	private PathCreator pathCreator;

	public override IEnumerator MovementBehaviour(Transform transform, float movementSpeed)
	{
		float lifeTime = 0;

		while (transform.position != pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1)) {
			yield return null;
			lifeTime += Time.deltaTime;
			transform.position = pathCreator.path.GetPointAtDistance(lifeTime * movementSpeed, EndOfPathInstruction.Stop);
		}

		yield break;
	}
}
