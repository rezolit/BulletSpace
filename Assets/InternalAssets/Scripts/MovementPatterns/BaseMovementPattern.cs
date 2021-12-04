using System.Collections;
using Components;
using UnityEngine;

namespace MovementPatterns
{
	/// <summary>
	/// Abstract class for all movement patterns.
	/// 
	/// </summary>
	public abstract class BaseMovementPattern : ScriptableObject
	{
		/// <summary>
		/// Movement method that should call with StartCoroutine()
		/// </summary>
		/// <param name="transform">Transform that will be moved with method</param>
		/// <param name="movementComponent">Movement component of target</param>
		/// <returns></returns>
		public abstract IEnumerator MovementBehaviour(Transform transform, MovementComponent movementComponent);
	}
}
