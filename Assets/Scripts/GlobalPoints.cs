using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum PointType
{
	upperLeft,
	upperRight,
	upperMid,
	upperLeftMid,
	upperRightMid
}

/// <summary>
/// Singleton Point's handler (SpawnPoints, Borders etc)
/// </summary>
public class GlobalPoints : Singleton<GlobalPoints>
{
	#region Fields
	
	public Transform leftBorder;
	public Transform rightBorder;
	public Transform upBorder;
	public Transform downBorder;

	public Transform upperLeft;
	public Transform upperRight;
	public Transform upperMid;
	public Transform upperLeftMid;
	public Transform upperRightMid;

	#endregion

	#region Methods
	
	private void Awake()
	{
		try {
			SetPoint(leftBorder, "LeftBorder");
			SetPoint(rightBorder, "RightBorder");
			SetPoint(upBorder, "UpBorder");
			SetPoint(downBorder, "DownBorder");

			SetPoint(upperLeft, "UpperLeft");
			SetPoint(upperRight, "UpperRight");
			SetPoint(upperMid, "UpperMid");
			SetPoint(upperLeftMid, "UpperLeftMid");
			SetPoint(upperRightMid, "UpperRightMid");
		}
		catch (Exception exception) {
			print(exception.Message);
		}
	}

	/// <summary>
	/// Search point by name (if not found, throw exception)
	/// </summary>
	void SetPoint(Transform borderTransform, string borderName)
	{
		borderTransform = GameObject.Find(borderName).transform;
		if (borderTransform == null) {
			throw new Exception(borderName + " border not found");
		}
	}

	public Transform GetPointByEnum(PointType pointType)
	{
		return pointType switch {
			PointType.upperLeft => upperLeft,
			PointType.upperRight => upperRight,
			PointType.upperMid => upperMid,
			PointType.upperLeftMid => upperLeftMid,
			PointType.upperRightMid => upperRightMid,
			_ => throw new ArgumentOutOfRangeException(nameof(pointType), pointType, null)
		};
	} 

	/// <summary>
	/// Check is position inside Borders with
	/// additional offset correction
	/// </summary>
	/// <param name="position"></param>
	/// <param name="additionalOffset">
	/// adds to each border value
	/// (useful for spawning enemies a little abroud so that they are not removed)
	/// </param>
	/// <returns></returns>
	public bool IsInsideBorders(Vector3 position, float additionalOffset = 0)
	{
		return position.x < rightBorder.position.x + additionalOffset &&
		       position.x > leftBorder.position.x - additionalOffset &&
		       position.y < upBorder.position.y + additionalOffset &&
		       position.y > downBorder.position.y - additionalOffset;
	}
    
	#endregion
}
