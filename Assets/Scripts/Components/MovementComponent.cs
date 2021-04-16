using Managers;
using MovementPatterns;
using UnityEngine;

namespace Components
{
	public abstract class MovementComponent : MonoBehaviour
	{
		[SerializeField]
		private float movementSpeed;

		public float MovementSpeed {
			get => movementSpeed * GameManager.Instance.speedMultiplier;
			set => movementSpeed = value;
		}
	}
}
