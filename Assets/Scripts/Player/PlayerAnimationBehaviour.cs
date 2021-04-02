using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	public class PlayerAnimationBehaviour : MonoBehaviour
	{
		[SerializeField]
		private Animator animator;

		private void Start()
		{
			animator = GetComponent<Animator>();
		}

		public void PlayShootAnimation()
		{
		}
	}
}