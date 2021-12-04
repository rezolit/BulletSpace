using System;
using Managers;
using MovementPatterns;
using UnityEngine;
using UnityEngine.UIElements;

namespace Components
{
	public class EnemyMovement : MovementComponent
	{
		[SerializeField]
		private BaseMovementPattern baseMovementPattern;

		public Coroutine Coroutine { get; private set; }

		private void Start()
		{
			Init();

			EventManager.Instance.OnGameStart += Init;
		}

		private void Init()
		{
			StopAllCoroutines();
			if (gameObject.activeSelf) {
				Coroutine = StartCoroutine(
					baseMovementPattern.MovementBehaviour(
						transform,
						this
					)
				);
			}
		}

		private void OnEnable()
		{
			Coroutine = StartCoroutine(
				baseMovementPattern.MovementBehaviour(
					transform,
					this
				)
			);
		}
	}
}
