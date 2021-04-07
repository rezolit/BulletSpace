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

		private Vector3 _desiredPlayerPosition;

		[HideInInspector]
		public Vector3 movementDirection;
		
		[HideInInspector]
		public bool    isSlowedDown;
		

		#endregion

		//---------------------------------------------------

		#region Methods

		private void Update()
		{
			// Movement logic
			transform.Translate(
				movementDirection * 
				(movementSpeed * (isSlowedDown ? slowSpeedModifier : 1.0f) 
				* Time.deltaTime)
			);
			_desiredPlayerPosition = transform.position;

			if (_desiredPlayerPosition.x > Borders.instance.rightBorder.position.x) {
				_desiredPlayerPosition = new Vector3(Borders.instance.rightBorder.position.x, _desiredPlayerPosition.y,
					_desiredPlayerPosition.z);
			}
			else if (transform.position.x < Borders.instance.leftBorder.position.x) {
				_desiredPlayerPosition = new Vector3(Borders.instance.leftBorder.position.x, _desiredPlayerPosition.y,
					_desiredPlayerPosition.z);
			}
			
			if (transform.position.y > Borders.instance.upBorder.position.y) {
				_desiredPlayerPosition = new Vector3(_desiredPlayerPosition.x, Borders.instance.upBorder.position.y,
					_desiredPlayerPosition.z);
			}
			else if (transform.position.y < Borders.instance.downBorder.position.y) {
				_desiredPlayerPosition = new Vector3(_desiredPlayerPosition.x, Borders.instance.downBorder.position.y,
					_desiredPlayerPosition.z);
			}

			transform.position = _desiredPlayerPosition;
		}

		#endregion

	}
}
