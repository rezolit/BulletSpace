using UnityEngine;

namespace Combat
{
	[CreateAssetMenu(fileName = "New Ability", menuName = "Combat/Ability", order = 53)]
	public class AbilityData : ScriptableObject
	{
		#region Fields

		[Header("General information")]
		[Space]
		
		[SerializeField]
		private string abilityName;

		[SerializeField]
		private string description;

		[SerializeField]
		private Sprite abilityIcon;
		
		[SerializeField]
		private Sprite abilityVFX;

		[SerializeField]
		private AudioClip abilitySound;

		[Header("Parameters")]
		[Space]

		[SerializeField] [Range(0.0f, 600.0f)] [Tooltip("Cooldown time in seconds")]
		private float cooldown;

		#endregion

		#region Methods (getters)

		public float Cooldown => cooldown;

		public AudioClip AbilitySound => abilitySound;

		public Sprite AbilityVFX => abilityVFX;

		public Sprite AbilityIcon => abilityIcon;

		public string Description => description;

		public string AbilityName => abilityName;
		
		#endregion
	}
}
