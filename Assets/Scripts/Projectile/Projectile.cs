using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Who is projectile's owner
/// </summary>
public enum OwnerType
{
	Player,
	Enemy
}

public class Projectile : MonoBehaviour
{
	#region Fields

	[HideInInspector]
	public Vector3 movementDirection;
	[HideInInspector]
	public float speed;
	[HideInInspector]
	public float angularSpeed;
	[HideInInspector]
	public float acceleration;
	[HideInInspector]
	public float angularAcceleraion;
	[HideInInspector]
	public bool isTargetAiming;
	[HideInInspector]
	public float jitterAmount;
	[HideInInspector]
	public float currentLifetime;
	
	public OwnerType Owner { get; set; }

	[SerializeField]
	private int damage;

	public int Damage => damage;

	#endregion

	#region Methods

	private void Start()
	{
		currentLifetime = 0.0f;
	}

	private void Update()
	{
		ProjectileBehaviour();
	}

	private void ProjectileBehaviour()
	{
		currentLifetime += Time.deltaTime;
		speed *= acceleration;
		transform.position += movementDirection * (speed * Time.deltaTime);

		if (!GlobalPoints.Instance.IsInsideBorders(transform.position, 2.0f)) {
			Deactivate();
		}
	}

	public void Deactivate()
	{
		PoolManager.Instance.ReleaseObject(gameObject);
	}


	#endregion

	}
