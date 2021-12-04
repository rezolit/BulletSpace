using System;
using UnityEngine;

namespace Managers
{
	public enum PointType
	{
		UpperLeft,
		UpperRight,
		UpperMid,
		UpperLeftMid,
		UpperRightMid
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

		public float enemiesOffset;
		public float projectilesOffset;

		#endregion

		#region Methods
	
		private void Awake()
		{
			try {
				SetPoint(out leftBorder, "LeftBorder");
				SetPoint(out rightBorder, "RightBorder");
				SetPoint(out upBorder, "UpBorder");
				SetPoint(out downBorder, "DownBorder");

				SetPoint(out upperLeft, "UpperLeft");
				SetPoint(out upperRight, "UpperRight");
				SetPoint(out upperMid, "UpperMid");
				SetPoint(out upperLeftMid, "UpperLeftMid");
				SetPoint(out upperRightMid, "UpperRightMid");
			}
			catch (Exception exception) {
				Debug.LogError(exception.Message);
			}
		}

		/// <summary>
		/// Search point by name (if not found, throw exception)
		/// </summary>
		void SetPoint(out Transform borderTransform, string borderName)
		{
			borderTransform = GameObject.Find(borderName).transform;
			if (borderTransform == null) {
				throw new Exception(borderName + " border not found");
			}
		}

		public Transform GetPointByEnum(PointType pointType)
		{
			return pointType switch {
				PointType.UpperLeft => upperLeft,
				PointType.UpperRight => upperRight,
				PointType.UpperMid => upperMid,
				PointType.UpperLeftMid => upperLeftMid,
				PointType.UpperRightMid => upperRightMid,
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
}