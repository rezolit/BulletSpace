using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Combat
{
	[CreateAssetMenu(fileName = "New Emitter", menuName = "Combat/Emitter", order = 51)]
	public class EmitterData : ScriptableObject
	{
		#region Fields

		[Header("General information")]

		[SerializeField]
		private string emitterName;

		[SerializeField]
		private string description;

		[SerializeField]
		private Sprite emitterSprite;

		[SerializeField] [Range(0.1f, 100.0f)] [Tooltip("Amount of shots per second")]
		private float spawnRate;
		
		[SerializeField] [Tooltip("Should be set in Inspector")]
		private ShootingPattern pattern;

		#endregion

		#region Methods (getters)

		public string EmitterName => emitterName;

		public string Description => description;

		public Sprite EmitterSprite => emitterSprite;

		public float SpawnRate => spawnRate;

		public ShootingPattern Pattern => pattern;

		#endregion
	
	}
}

