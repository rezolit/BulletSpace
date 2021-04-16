using Components;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
	public class PlayerMovementBehaviour : MovementComponent
	{

		#region Fields

		[SerializeField]
		private bool lookAtMouse;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private bool canMove;

		[SerializeField] [Range(0.0f, 1.0f)]
		private float slowSpeedModifier;
		
		private Vector2 _desiredPlayerPosition;
		private Vector3 _movementDirection;

		[HideInInspector]
		public bool    isSlowedDown;
		

		#endregion

		#region Methods
		
		public Vector3 MovementDirection {
			get => _movementDirection;
			set => _movementDirection = value;
		}

		private void Start()
		{
			if (!_camera) {
				_camera = Camera.main;
			}
		}

		private void Update()
		{
			if (canMove) {
				Move();
			}

			if (lookAtMouse) {
				RotateToMouse();
			}
		}

		private void Move()
		{
			// TODO speed
			_desiredPlayerPosition =
				(Vector2)(transform.position +
				          _movementDirection * 
							(MovementSpeed *
							 (isSlowedDown ? slowSpeedModifier : 1.0f) *
							 Time.deltaTime)
				);
			
			if (_desiredPlayerPosition.x > GlobalPoints.Instance.rightBorder.position.x) {
				_desiredPlayerPosition = 
					new Vector3(GlobalPoints.Instance.rightBorder.position.x, _desiredPlayerPosition.y);
			}
			else if (_desiredPlayerPosition.x < GlobalPoints.Instance.leftBorder.position.x) {
				_desiredPlayerPosition =
					new Vector3(GlobalPoints.Instance.leftBorder.position.x, _desiredPlayerPosition.y);
			}
			
			if (_desiredPlayerPosition.y > GlobalPoints.Instance.upBorder.position.y) {
				_desiredPlayerPosition =
					new Vector3(_desiredPlayerPosition.x, GlobalPoints.Instance.upBorder.position.y);
			}
			else if (_desiredPlayerPosition.y < GlobalPoints.Instance.downBorder.position.y) {
				_desiredPlayerPosition =
					new Vector3(_desiredPlayerPosition.x, GlobalPoints.Instance.downBorder.position.y);
			}

			transform.position = _desiredPlayerPosition;
		}
		
		private void RotateToMouse()
		{
			Vector2 mousePosition = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
			Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
 
			Vector2 directionVector = new Vector2(
				mousePosition.x - playerPosition.x,
				mousePosition.y - playerPosition.y) * Mathf.Rad2Deg;
 
			Quaternion aimRotation = Quaternion.Euler(
				new Vector3(
					0,
					0,
					Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg -90
				)
			);
 
			transform.rotation = aimRotation;
		}

		#endregion

	}
}
