using MovementPatterns;
using UnityEngine;

namespace Components
{
	public class MovementComponent : MonoBehaviour
	{
		[SerializeField]
		private float movementSpeed;

		[SerializeField]
		private BaseMovementPattern baseMovementPattern;

		public Coroutine Coroutine { get; set; }

		private void OnEnable()
		{
			Coroutine = StartCoroutine(baseMovementPattern.MovementBehaviour(transform, movementSpeed));
		}
	}
}
