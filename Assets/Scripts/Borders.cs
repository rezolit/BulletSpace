using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// Singleton Border's handler
/// </summary>
public class Borders : MonoBehaviour
{
	#region Fields
	
	public static Borders instance = null;
	public Transform leftBorder;
	public Transform rightBorder;
	public Transform upBorder;
	public Transform downBorder;

	#endregion

	#region Methods
	
	private void Awake()
	{
		if (instance == null) {
			instance = this;
		}
		else if (instance == this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		
		SetBorder(leftBorder, "LeftBorder");
		SetBorder(rightBorder, "RightBorder");
		SetBorder(upBorder, "UpBorder");
		SetBorder(downBorder, "DownBorder");
	}

	void SetBorder(Transform borderTransform, string borderName)
	{
		borderTransform = GameObject.Find(borderName).transform;
		if (borderTransform == null) {
			throw new Exception(borderName + " border not found");
		}
	}
    
	#endregion
}
