using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse : MonoBehaviour
{
	[SerializeField]
	private Camera cam;

	private void Update()
	{
		RotateToMouse();
	}

	private void RotateToMouse()
	{
		Vector2 mousePosition = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
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
}
