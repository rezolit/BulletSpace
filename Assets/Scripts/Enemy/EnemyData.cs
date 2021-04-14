using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/Enemy", order = 51)]
public class EnemyData : ScriptableObject
{
	#region Fields

	[SerializeField]
	private string enemyName;

	[SerializeField]
	private string description;

	#endregion

	#region Methods
	
	public string Description => description;

	public string EnemyName => enemyName;

	#endregion
}
