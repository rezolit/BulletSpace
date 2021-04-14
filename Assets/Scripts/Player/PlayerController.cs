using System;
using Managers;
using UnityEngine;

namespace Player
{
	public class PlayerController : MonoBehaviour
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

				if (DebugManager.Instance.IsLogDeath) {
					Debug.Log("Death for " + gameObject.name);
				}
				
				Destroy(gameObject);
			}
			else {
				print("Enemy killed");
			}
		}
	}
}
