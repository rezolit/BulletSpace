using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Representation of Pool of objects.
///  </summary>
public class ObjectPool<T>
{

	#region Fields

	private List<ObjectPoolContainer<T>> list;
	private Dictionary<T, ObjectPoolContainer<T>> lookup;
	private Func<T> factoryFunction;
	private int lastIndex = 0;

	#endregion

	#region Methods
	
	/// <param name="factoryFunction">Function for objects creating (instantiating)</param>
	/// <param name="initialSize">Size on setup (desirable ~128)</param>
	public ObjectPool(Func<T> factoryFunction, int initialSize)
	{
		this.factoryFunction = factoryFunction;

		list = new List<ObjectPoolContainer<T>>(initialSize);
		lookup = new Dictionary<T, ObjectPoolContainer<T>>(initialSize);

		Warm(initialSize);
	}

	/// <summary>
	/// Objects initialization on setup
	/// </summary>
	private void Warm(int capacity)
	{
		for (int i = 0; i < capacity; i++)
		{
			CreateContainer();
		}
	}

	private ObjectPoolContainer<T> CreateContainer()
	{
		var container = new ObjectPoolContainer<T> { Item = factoryFunction() };
		list.Add(container);
		return container;
	}

	public T GetItem()
	{
		ObjectPoolContainer<T> container = null;
		for (int i = 0; i < list.Count; i++)
		{
			lastIndex++;
			if (lastIndex > list.Count - 1) lastIndex = 0;
				
			if (list[lastIndex].Used)
			{
				continue;
			}
			else
			{
				container = list[lastIndex];
				break;
			}
		}

		if (container == null)
		{
			container = CreateContainer();
		}

		container.Consume();
		lookup.Add(container.Item, container);
		return container.Item;
	}

	public void ReleaseItem(object item)
	{
		ReleaseItem((T) item);
	}

	public void ReleaseItem(T item)
	{
		if (lookup.ContainsKey(item))
		{
			var container = lookup[item];
			container.Release();
			lookup.Remove(item);
		}
		else
		{
			Debug.LogWarning("This object pool does not contain the item provided: " + item);
		}
	}

	public int Count => list.Count;

	public int CountUsedItems => lookup.Count;

	#endregion
}
