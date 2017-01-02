using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Movement {
	
	public interface ITargetsMovable {
		Vector3 MovementTarget { get; set; }
		Vector3 LastFramePosition { get; set; }
	}

	public class Movement : MonoBehaviour {

		ITargetsMovable m_TargetContainer;

		public void Construct (TargetsBase targets) {
			if (targets is ITargetsMovable) {
				m_TargetContainer = targets as ITargetsMovable;
			} else {
				Destroy (this);
			}
		}
	}
}