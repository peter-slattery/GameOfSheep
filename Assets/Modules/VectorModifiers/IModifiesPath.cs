using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IModifiesPath {

	// Contract to Return a PointNormalForward representing the input target position
	// modified to meet some criteria which takes into accoun the path along which an object
	// would travel from start.
	public abstract PointNormalForward Evaluate (Vector3 start, Vector3 target);

}
