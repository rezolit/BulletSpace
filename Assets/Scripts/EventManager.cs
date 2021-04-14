using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
	#region Fields
	
	public delegate void DeathMethod(int id);

	public event DeathMethod OnDeath;

	#endregion

	#region Methods

	public void Death(int id)
	{
		OnDeath?.Invoke(id);
	}
	
	#endregion

}
