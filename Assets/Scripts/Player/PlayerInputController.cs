using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
	public class PlayerInputController : MonoBehaviour
	{
		#region Fields
		
		[SerializeField]
		private PlayerInput playerInput;

		[SerializeField]
		private PlayerAnimationBehaviour playerAnimationBehaviour;

		[SerializeField]
		private PlayerMovementBehaviour playerMovementBehaviour;

		[SerializeField]
		private PlayerShootingBehaviour playerShootingBehaviour;

		#endregion Variables
		
		#region Methods
		
		private void Awake()
		{
			playerInput = GetComponent<PlayerInput>();
			playerAnimationBehaviour = GetComponent<PlayerAnimationBehaviour>();
			playerMovementBehaviour = GetComponent<PlayerMovementBehaviour>();
			playerShootingBehaviour = GetComponent<PlayerShootingBehaviour>();
		}

		#endregion
		
		#region Callbacks

		public void OnMovement(InputAction.CallbackContext ctx)
		{
			Vector2 inputMovement = ctx.ReadValue<Vector2>();
			playerMovementBehaviour.movementDirection = new Vector3(inputMovement.x, inputMovement.y, 0.0f);
		}

		public void OnSlowDown(InputAction.CallbackContext ctx)
		{
			if (ctx.started) {
				playerMovementBehaviour.isSlowedDown = true;
			}
			else if (ctx.canceled) {
				playerMovementBehaviour.isSlowedDown = false;
			}
		}

		public void OnShoot(InputAction.CallbackContext ctx)
		{
			if (ctx.started) {
				playerShootingBehaviour.SetShootingMode(true);
			} 
			else if (ctx.canceled) {
				playerShootingBehaviour.SetShootingMode(false);
			}
		}

		public void OnPause(InputAction.CallbackContext ctx)
		{
			if (ctx.started) {
				print("Pause");
			}
		}

		#endregion
	}
}
