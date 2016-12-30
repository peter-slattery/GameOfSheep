using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A data class, used to return information about a various point in the world.
// Note: There is no guarauntee that any of the values will actually be set, except for point.
public class PointNormalForward {
	public Vector3 point;
	public Vector3 normal;
	public Vector3 forward;

	public PointNormalForward () {
		this.point = Vector3.zero;
		this.normal = Vector3.up;
		this.forward = Vector3.forward;
	}

	public PointNormalForward(Vector3 point, Vector3 normal, Vector3 forward){
		this.point = point;
		this.normal = normal;
		this.forward = forward;
	}
}
