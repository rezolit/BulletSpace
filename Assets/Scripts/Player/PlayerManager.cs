using System;
using UnityEngine;


namespace Player
{
	public class PlayerManager : MonoBehaviour
	{
		private void Start()
		{
			if (EventManager.Instance == null) {
				print("null");
			}
			EventManager.Instance.OnDeath += Death;
		}

		private void Death(int id)
		{
			if (id == gameObject.GetInstanceID()) {
				EventManager.Instance.OnDeath -= Death;
				Destroy(gameObject);
			}
			else {
				print("Enemy killed");
			}
		}
	}
}
