using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

public class FlockManager {

	private FlockManager.Settings _settings;

	[Inject]
	public void Init () {

	}

	public void RegisterFlocking (IFlocking entity) {

	}

	[System.Serializable]
	public class Settings {
		
	}
}
