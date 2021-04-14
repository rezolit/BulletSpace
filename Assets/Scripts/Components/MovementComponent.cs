using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
	[SerializeField]
	private float movementSpeed;

	[SerializeField]
	private MovementPattern movementPattern;

	public Coroutine Coroutine { get; set; }

	private void Start()
	{
		Coroutine = StartCoroutine(movementPattern.MovementBehaviour(transform, movementSpeed));
	}
}
