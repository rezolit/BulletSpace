using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton for pooling all objects
/// </summary>
public class PoolManager : Singleton<PoolManager>
{
	#region Fields

	[Tooltip("Should log to console pool info")]
    public bool logStatus;
    
    [Tooltip("Root Transform for all objects in pool")]
    public Transform root;

	private Dictionary<GameObject, ObjectPool<GameObject>> _prefabLookup;
	private Dictionary<GameObject, ObjectPool<GameObject>> _instanceLookup;
	
	private bool _dirtyFlag;

	#endregion

	#region Methods

	private void Awake () 
	{
		_prefabLookup = new Dictionary<GameObject, ObjectPool<GameObject>>();
		_instanceLookup = new Dictionary<GameObject, ObjectPool<GameObject>>();
	}

	private void Update()
	{
		if(logStatus && _dirtyFlag)
		{
			PrintStatus();
			_dirtyFlag = false;
		}
	}

	public void WarmPool(GameObject prefab, int size)
	{
		if(_prefabLookup.ContainsKey(prefab))
		{
			throw new Exception("Pool for prefab " + prefab.name + " has already been created");
		}
		var pool = new ObjectPool<GameObject>(() => { return InstantiatePrefab(prefab); }, size);
		_prefabLookup[prefab] = pool;

		_dirtyFlag = true;
	}

	public GameObject SpawnObject(GameObject prefab)
	{
		return SpawnObject(prefab, Vector3.zero, Quaternion.identity);
	}

	public GameObject SpawnObject(GameObject prefab, Vector3 position, Quaternion rotation)
	{
		if (!_prefabLookup.ContainsKey(prefab))
		{
			WarmPool(prefab, 1);
		}

		var pool = _prefabLookup[prefab];

		var clone = pool.GetItem();
		clone.transform.position = position;
		clone.transform.rotation = rotation;
		clone.SetActive(true);

		_instanceLookup.Add(clone, pool);
		_dirtyFlag = true;
		return clone;
	}

	public void ReleaseObject(GameObject clone)
	{
		clone.SetActive(false);

		if(_instanceLookup.ContainsKey(clone))
		{
			_instanceLookup[clone].ReleaseItem(clone);
			_instanceLookup.Remove(clone);
			_dirtyFlag = true;
		}
		else
		{
			Debug.LogWarning("No pool contains the object: " + clone.name);
		}
	}
	
	private GameObject InstantiatePrefab(GameObject prefab)
	{
		var go = Instantiate(prefab);
		if (root != null) go.transform.parent = root;
		return go;
	}

	private void PrintStatus()
	{
		foreach (KeyValuePair<GameObject, ObjectPool<GameObject>> keyVal in _prefabLookup)
		{
			Debug.Log(string.Format("Object Pool for Prefab: {0} In Use: {1} Total {2}",
				keyVal.Key.name, keyVal.Value.CountUsedItems, keyVal.Value.Count));
		}
	}

	#endregion
	
}
