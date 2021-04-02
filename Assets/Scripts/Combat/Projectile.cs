using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
	public class Projectile : MonoBehaviour
	{
		#region Fields

		private Vector3 _movementDirection;
		private float _currentSpeed;

		public ProjectileData projectileData;
		public float currentLifetime;

		#endregion

		#region Methods

		private void Update()
		{
			ProjectileBehaviour();
		}

		public void ProjectileBehaviour()
		{
			currentLifetime += Time.deltaTime;
			_currentSpeed *= projectileData.Acceleration;
			transform.position += _movementDirection * (_currentSpeed * Time.deltaTime);

			if (currentLifetime > projectileData.LifeTime) {
				Destroy(this);
			}
		}

		public void Initialize(ProjectileData projData, Vector3 movDir)
		{
			projectileData = projData;
			_movementDirection = movDir;
			
			currentLifetime = 0.0f;
			_currentSpeed = projectileData.StartSpeed;
			GetComponent<SpriteRenderer>().sprite = projectileData.ProjectileSprite;
			GetComponent<CircleCollider2D>().radius = projectileData.Radius;
		}

		#endregion

	}
}
