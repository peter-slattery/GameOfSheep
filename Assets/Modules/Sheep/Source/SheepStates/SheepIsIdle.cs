using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Sheep {
	public class SheepIsIdle : StateHandlerBase {

		[System.Serializable]
		public new class Settings : StateHandlerBase.Settings{
			public float TimeBeforeAnxious = 4;
		}

		/*
		private SheepController m_Controller;
		private SheepIsIdle.Settings m_Settings;

		private float TimeInState;

		public SheepIsIdle (
			SheepController controller,
			SheepIsIdle.Settings settings = null
		) {
			m_Controller = controller;

			m_Settings = settings;
			if (m_Settings == null) {
				m_Settings = new Settings ();
			}
		}
		*/

		public override void OnEnter (StateHandlerBase lastState) {
			// TimeInState = 0;
		}

		public override void OnUpdate () {
			/*
			// TODO: Replace with real logic
			TimeInState += Time.deltaTime;

			if (TimeInState >= m_Settings.TimeBeforeAnxious && m_Controller != null) {
				m_Controller.ChangeState (SheepController.SheepStates.IS_ANXIOUS);
			}
			*/
		}

		public override void OnExit (StateHandlerBase nextState) {

		}


	}
}
