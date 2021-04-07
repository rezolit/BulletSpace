using UnityEngine;

namespace Combat
{
	enum Owner
	{
		player,
		enemy
	}
	
	[CreateAssetMenu(fileName = "New Projectile", menuName = "Combat/Projectile", order = 52)]
	public class ProjectileData : ScriptableObject
	{
		#region Fields

		[Header("General information")]
		[Space]
		
		[SerializeField]
		private string projectileName;

		[SerializeField]
		private Sprite projectileSprite;

		[SerializeField]
		private Owner owner;

		#endregion

		#region Methods (getters)

		public string ProjectileName => projectileName;

		public Sprite ProjectileSprite => projectileSprite;
		

		#endregion
	}
}
