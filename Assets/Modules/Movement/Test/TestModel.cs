using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Movement {
	public class TestModel : ModelBase {

		public TestModel () {
			this.Targets = new TestTargets ();
		}
	}

	public class TestTargets : TargetsBase, ITargetsMovable {
		public Vector3 MovementTarget {
			get;
			set;
		}

		public Vector3 LastFramePosition {
			get;
			set;
		}
	}
}