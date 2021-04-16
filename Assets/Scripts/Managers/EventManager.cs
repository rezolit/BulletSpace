using UnityEngine;

namespace Managers
{
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
}
