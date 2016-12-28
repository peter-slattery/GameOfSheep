using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IFlocking{

	// Use: Given <data> returns an optimal position for entity within the flock
	public Vector3 EvaluateFlockForEntity () {
		return Vector3.forward;
	}

	[System.Serializable]
	public class Settings {
		float Attraction;
		float Distance;
		float Direction;
	}
}
