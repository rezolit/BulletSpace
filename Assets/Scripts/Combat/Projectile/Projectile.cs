using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
	public class Projectile : MonoBehaviour
	{
		#region Fields

		public Vector3 movementDirection;
		public float speed;
		public float angularSpeed;
		public float acceleration;
		public float angularAcceleraion;
		public bool isTargetAiming;
		public float jitterAmount;

		public ProjectileData projectileData;
		public float currentLifetime;

		#endregion

		#region Methods

		private void Start()
		{
			currentLifetime = 0.0f;
			GetComponent<SpriteRenderer>().sprite = projectileData.ProjectileSprite;
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

			if (transform.position.x > Borders.instance.rightBorder.position.x ||
			    transform.position.x < Borders.instance.leftBorder.position.x ||
			    transform.position.y > Borders.instance.upBorder.position.y ||
			    transform.position.y < Borders.instance.downBorder.position.y) {
				gameObject.SetActive(false);
			}
		}
		

		#endregion

	}
}
