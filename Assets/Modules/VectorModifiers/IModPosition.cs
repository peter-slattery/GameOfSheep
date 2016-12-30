using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IModPosition {

	// Contract to Return a PointNormalForward representing the input target position
	// modified to meet some criteria.
	public abstract PointNormalForward Evaluate (Vector3 target);
}
