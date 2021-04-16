using Managers;
using MovementPatterns;
using UnityEngine;

namespace Components
{
	public class EnemyMovement : MovementComponent
	{
		[SerializeField]
		private BaseMovementPattern baseMovementPattern;

		public Coroutine Coroutine { get; set; }

		private void OnEnable()
		{
			// TODO speed
			Coroutine = StartCoroutine(
				baseMovementPattern.MovementBehaviour(
					transform,
					this
				)
			);
		}
	}
}
