using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Movement {
	public class GroundBasedMovement : MonoBehaviour {

		private bool m_Constructed = false;

		ITargetsMovable m_Targets;

		public void Construct () {
			if (m_Constructed)
				return;
			
			TargetsBase targets = GetComponent<IFacadeBase> ().Targets;
			if (targets is ITargetsMovable) {
				m_Targets = targets as ITargetsMovable;
			}

			m_Constructed = true;
		}

		// Use this for initialization
		void Start () {
			Construct ();
		}
		
		// Update is called once per frame
		void Update () {
			transform.position = m_Targets.MovementTarget;	
		}
	}
}