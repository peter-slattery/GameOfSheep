using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Movement {
	public class FaceTowardsTarget : MonoBehaviour {

		private bool m_Constructed = false;

		ITargetsMovable m_Targets;

		public void Construct () {
			if (m_Constructed)
				return;

			IFacadeBase facade = GetComponent<IFacadeBase> ();
			if (facade != null) {
				TargetsBase targets = facade.Targets;
				if (targets is ITargetsMovable) {
					m_Targets = targets as ITargetsMovable;

					m_Targets.MovementTarget = transform.position;
				}
			}

			m_Constructed = true;
		}

		void Start () {
			Construct();
		}

		void Update () {
			if (m_Targets != null) {
				Vector3 lookDir = m_Targets.MovementTarget - m_Targets.LastFramePosition;
				if (lookDir != Vector3.zero) {
					transform.rotation = Quaternion.LookRotation (lookDir);
				}
			}
		}
	}
}
