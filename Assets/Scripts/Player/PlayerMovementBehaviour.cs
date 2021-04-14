using Managers;
using UnityEngine;

namespace Player
{
	public class PlayerMovementBehaviour : MonoBehaviour
	{

		#region Fields

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

		#region Methods

		private void Update()
		{
			// Movement logic
			Transform playerTransform = transform;
			playerTransform.Translate(
				movementDirection * 
				(movementSpeed * (isSlowedDown ? slowSpeedModifier : 1.0f) 
				* Time.deltaTime)
			);
			_desiredPlayerPosition = playerTransform.position;

			if (_desiredPlayerPosition.x > GlobalPoints.Instance.rightBorder.position.x) {
				_desiredPlayerPosition = new Vector3(GlobalPoints.Instance.rightBorder.position.x, _desiredPlayerPosition.y,
					_desiredPlayerPosition.z);
			}
			else if (transform.position.x < GlobalPoints.Instance.leftBorder.position.x) {
				_desiredPlayerPosition = new Vector3(GlobalPoints.Instance.leftBorder.position.x, _desiredPlayerPosition.y,
					_desiredPlayerPosition.z);
			}
			
			if (transform.position.y > GlobalPoints.Instance.upBorder.position.y) {
				_desiredPlayerPosition = new Vector3(_desiredPlayerPosition.x, GlobalPoints.Instance.upBorder.position.y,
					_desiredPlayerPosition.z);
			}
			else if (transform.position.y < GlobalPoints.Instance.downBorder.position.y) {
				_desiredPlayerPosition = new Vector3(_desiredPlayerPosition.x, GlobalPoints.Instance.downBorder.position.y,
					_desiredPlayerPosition.z);
			}

			transform.position = _desiredPlayerPosition;
		}

		#endregion

	}
}
