using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class for all movement patterns.
/// 
/// </summary>
public abstract class MovementPattern : ScriptableObject
{
	/// <summary>
	/// Movement method that should call with StartCoroutine()
	/// </summary>
	/// <param name="transform">Transform that will be moved with method</param>
	/// <param name="movementSpeed"></param>
	/// <returns></returns>
	public abstract IEnumerator MovementBehaviour(Transform transform, float movementSpeed);
}
