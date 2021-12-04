using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UIElements;

public class ClockArrow : MonoBehaviour
{
	private Vector3 rotation;

	private float timer;

	private void Start()
	{
		Init();

		EventManager.Instance.OnGameStart += Init;
	}

	private void Init()
	{
		rotation = new Vector3(0.0f, 0.0f, 0.0f);
		timer = 0.0f;
	}

	private void Update()
	{
		if (timer + 1.0f < GameManager.Instance.levelTimer) {
			rotation.z = 6.0f * (GameManager.Instance.levelTimer % 60);
			transform.rotation = Quaternion.Euler(-rotation);
			timer = GameManager.Instance.levelTimer;
		}
	}
}
