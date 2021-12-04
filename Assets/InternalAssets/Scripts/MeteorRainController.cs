using System.Collections.Generic;
using Emitter;
using Managers;
using UnityEngine;

public class MeteorRainController : MonoBehaviour
{
	[SerializeField]
	private List<EmitterController> _emitters;

	private void Start()
	{
		if (_emitters.Count == 0) {
			foreach (var emitter in GetComponentsInChildren<EmitterController>()) {
				_emitters.Add(emitter);
			}
		}
	}

	private void Update()
	{
		foreach (EmitterController emitter in _emitters) {
			emitter.isActive = GameManager.Instance.isMeteorRainActive;
		}
	}
	
}
