using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfSheep.Sheep {
	public class SheepIsIdle : ISheepStateHandler {

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

		public void OnEnter () {
			TimeInState = 0;
		}

		public void OnEnter (ISheepStateHandler lastState) {
			this.OnEnter ();
		}

		public void OnUpdate () {
			// TODO: Replace with real logic
			TimeInState += Time.deltaTime;

			if (TimeInState >= m_Settings.TimeBeforeAnxious && m_Controller != null) {
				m_Controller.ChangeState (SheepController.SheepStates.IS_ANXIOUS);
			}
		}

		public void OnExit (ISheepStateHandler nextState) {

		}

		[System.Serializable]
		public class Settings {
			public float TimeBeforeAnxious = 4;
		}
	}
}
