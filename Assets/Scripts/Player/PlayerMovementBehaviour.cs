using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	public class PlayerMovementBehaviour : MonoBehaviour
	{
		//---------------------------------------------------

		#region Variables

		[SerializeField]
		private float movementSpeed;

		[SerializeField] [Range(0.0f, 1.0f)]
		private float slowSpeedModifier;

		[SerializeField]
		private Transform rightBorder;

		[SerializeField]
		private Transform leftBorder;

		[SerializeField]
		private Transform upBorder;

		[SerializeField]
		private Transform downBorder;

		private Vector3 _desiredPlayerPosition;

		[HideInInspector]
		public Vector3 movementDirection;
		
		[HideInInspector]
		public bool    isSlowedDown;
		

		#endregion

		//---------------------------------------------------

		#region MonoBehaviour functions

		private void Start()
		{
			SetBorder(leftBorder, "LeftBorder");
			SetBorder(rightBorder, "RightBorder");
			SetBorder(upBorder, "UpBorder");
			SetBorder(downBorder, "DownBorder");
		}

		private void Update()
		{
			// Movement logic
			transform.Translate(
				movementDirection * 
				(movementSpeed * (isSlowedDown ? slowSpeedModifier : 1.0f) 
				* Time.deltaTime)
			);
			_desiredPlayerPosition = transform.position;

			if (_desiredPlayerPosition.x > rightBorder.position.x) {
				_desiredPlayerPosition = new Vector3(rightBorder.position.x, _desiredPlayerPosition.y,
					_desiredPlayerPosition.z);
			}
			else if (transform.position.x < leftBorder.position.x) {
				_desiredPlayerPosition = new Vector3(leftBorder.position.x, _desiredPlayerPosition.y,
					_desiredPlayerPosition.z);
			}
			
			if (transform.position.y > upBorder.position.y) {
				_desiredPlayerPosition = new Vector3(_desiredPlayerPosition.x, upBorder.position.y,
					_desiredPlayerPosition.z);
			}
			else if (transform.position.y < downBorder.position.y) {
				_desiredPlayerPosition = new Vector3(_desiredPlayerPosition.x, downBorder.position.y,
					_desiredPlayerPosition.z);
			}

			transform.position = _desiredPlayerPosition;
		}

		#endregion
		
		//---------------------------------------------------
		
		#region Methods

		void SetBorder(Transform borderTransform, string borderName)
		{
			if (borderTransform == null) {
				borderTransform = GameObject.Find(borderName).transform;
			}
		}

		#endregion
		
	}
}
