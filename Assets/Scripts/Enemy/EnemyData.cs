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
	
	[SerializeField]
	private Sprite sprite;
	
	[Header("Parameters")]
	
	[SerializeField]
	private int hitPoints;

	[SerializeField]
	private float movementSpeed;

	[SerializeField]
	private MovementPattern movementPattern;

	#endregion

	#region Methods

	public int HitPoints => hitPoints;

	public string Description => description;

	public string EnemyName => enemyName;

	public Sprite Sprite => sprite;

	public float MovementSpeed => movementSpeed;

	public MovementPattern MovementPattern => movementPattern;

	#endregion
}
