using System;
using Components;
using Player;
using UnityEngine;

namespace Enemy
{
	[RequireComponent(typeof(CircleCollider2D))]
	public class EnemySuicide : MonoBehaviour
	{
		[SerializeField]
		private int damage;

		private void OnCollisionEnter2D(Collision2D other)
		{
			var player = other.gameObject.GetComponent<PlayerController>();
			if (player != null) {
				player.GetComponent<HealthComponent>().GetDamaged(damage);
			}
			gameObject.GetComponent<HealthComponent>().GetDamaged(1000);
		}
	}
}
