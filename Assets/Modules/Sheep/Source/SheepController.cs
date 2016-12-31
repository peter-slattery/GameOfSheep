using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Sheep {

	public class SheepController : StateControllerBase {

		private SheepModel m_Model;

		public SheepController (
			IFacadeBase facade,
			SheepSystemSettings settings,
			SheepModel model
		) : base (
			facade,
			(settings == null ? null : settings.PotentialStates)
		){
			m_Model = model;
		}

		public void Initialize() {
			//TODO: Request initial state
			if (m_Potential.States != null &&
				m_Potential.States.Count > 0) 
			{
				RequestChangeState (m_Potential.States [0]);
			}
		}

		public override void OnUpdate () {
			if(m_CurrentStateHandler)
				m_CurrentStateHandler.OnUpdate ();
		}
	}
}