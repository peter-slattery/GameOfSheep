using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Sheep {
	
	public class SheepIsCalm : StateHandlerBase {
		/*
		[System.Serializable]
		public class Settings {
			public float TimeBeforeIdle = 4;
		}


		private SheepController m_Controller;
		private SheepIsCalm.Settings m_Settings;

		private float TimeInState;

		public SheepIsCalm (
			SheepController controller,
			SheepIsCalm.Settings settings = null
		) {
			m_Controller = controller;

			m_Settings = settings;
			if (m_Settings == null) {
				m_Settings = new Settings ();
			}
		}

		*/
		public override void OnEnter (StateHandlerBase nextState) {
			//TimeInState = 0;
		}

		public override void OnUpdate () {
			/*
			// TODO: Replace with real logic
			TimeInState += Time.deltaTime;

			if (TimeInState >= m_Settings.TimeBeforeIdle && m_Controller != null) {
				m_Controller.ChangeState (SheepController.SheepStates.IS_IDLE);
			}
			*/
		}

		public override void OnExit (StateHandlerBase nextState) {

		}
	}
}
