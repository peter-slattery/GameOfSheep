using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;
using GameOfSheep.Movement;

namespace GameOfSheep.Sheep {
	public class SheepModel : ModelBase {

		private Transform m_SheepTransform;

		public SheepModel (
			Transform sheepTransform
		) {
			// Dependency Injection
			this.Targets = new SheepTargets ();
			m_SheepTransform = sheepTransform;

			// Initialization
			(Targets as ITargetsMovable).MovementTarget = Position;
		}

		public Vector3 Position {
			get {
				if (m_SheepTransform != null)
					return m_SheepTransform.position;
				return Vector3.zero;
			}
		}
	}

	public class SheepTargets : TargetsBase, ITargetsMovable {
		public Vector3 MovementTarget { 
			get;
			set;
		}
	}
}