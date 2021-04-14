using UnityEngine;

namespace Managers
{
	public class DebugManager : Singleton<DebugManager>
	{

		#region Fields

		/// <summary>
		/// Should log damage to console
		/// </summary>
		[SerializeField]
		private bool isLogDamage;

		/// <summary>
		/// Should log death's to console
		/// </summary>
		/// <returns></returns>
		[SerializeField]
		private bool isLogDeath;

		/// <summary>
		/// Should log pool info to console
		/// </summary>
		/// <returns></returns>
		[SerializeField]
		private bool isLogPoolInfo;
		
		/// <summary>
		/// Should log enemies spawning info to console
		/// </summary>
		/// <returns></returns>
		[SerializeField]
		private bool isLogSpawnInfo;
		
		/// <summary>
		/// Should log info about Singleton's to console
		/// </summary>
		/// <returns></returns>
		[SerializeField]
		private bool isLogSingletonInfo;

		#endregion
		
		public bool IsLogDamage => isLogDamage;

		public bool IsLogDeath => isLogDeath;

		public bool IsLogPoolInfo => isLogPoolInfo;

		public bool IsLogSpawnInfo => isLogSpawnInfo;

		public bool IsLogSingletonInfo => isLogSingletonInfo;
		
		
	}
}
