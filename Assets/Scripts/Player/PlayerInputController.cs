using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
	public class PlayerInputController : MonoBehaviour
	{
		#region Variables
		[SerializeField]
		private UnityEngine.InputSystem.PlayerInput playerInput;

		[SerializeField]
		private PlayerAnimationBehaviour playerAnimationBehaviour;

		[SerializeField]
		private PlayerMovementBehaviour playerMovementBehaviour;

		[SerializeField]
		private PlayerCombatBehaviour playerCombatBehaviour;

		#endregion Variables
		
		#region Methods
		
		private void Awake()
		{
			playerInput = GetComponent<UnityEngine.InputSystem.PlayerInput>();
			playerAnimationBehaviour = GetComponent<PlayerAnimationBehaviour>();
			playerMovementBehaviour = GetComponent<PlayerMovementBehaviour>();
			playerCombatBehaviour = GetComponent<PlayerCombatBehaviour>();
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
				playerCombatBehaviour.SetShootingMode(true);
			} 
			else if (ctx.canceled) {
				playerCombatBehaviour.SetShootingMode(false);
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
