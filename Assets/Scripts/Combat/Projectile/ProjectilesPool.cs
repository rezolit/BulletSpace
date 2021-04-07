using System;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
	/// <summary>
	/// Singleton pooling-pattern class
	/// </summary>
	public class ProjectilesPool : MonoBehaviour
	{
		#region Fields

		public static ProjectilesPool instance = null;
		public List<Projectile> pooledObjects;
		public Projectile objectToPool;
		
		[SerializeField] [Range(1, 4096)] [Tooltip("Amount of objects on Start")]
		private int amountToPool;

		#endregion

		#region Methods

		void Awake()
		{
			if (instance == null) {
				instance = this;
			}
			else if (instance == this) {
				Destroy(gameObject);
			}
			DontDestroyOnLoad(gameObject);
		}

		private void Start()
		{
			Initialize();
		}

		public Projectile GetPooledObject()
		{
			for (int i = 0; i < pooledObjects.Count; ++i) {
				if (!pooledObjects[i].gameObject.activeInHierarchy) {
					return pooledObjects[i];
				}
			}
			

			Projectile tmp = Instantiate(objectToPool);
			tmp.gameObject.SetActive(false);
			pooledObjects.Add(tmp);
			return tmp;

		}

		private void Initialize()
		{
			pooledObjects = new List<Projectile>();
			for (int i = 0; i < amountToPool; i++) {
				Projectile tmp = Instantiate(objectToPool);
				tmp.gameObject.SetActive(false);
				pooledObjects.Add(tmp);
			}
		}

		#endregion
	}
}
