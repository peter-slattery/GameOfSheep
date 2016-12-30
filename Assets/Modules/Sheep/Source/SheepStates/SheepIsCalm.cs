using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfSheep.Sheep {
	public class SheepIsCalm : ISheepStateHandler {

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

		public void OnEnter () {
			TimeInState = 0;
		}

		public void OnEnter (ISheepStateHandler nextState) {
			OnEnter ();
		}

		public void OnUpdate () {
			// TODO: Replace with real logic
			TimeInState += Time.deltaTime;

			if (TimeInState >= m_Settings.TimeBeforeIdle && m_Controller != null) {
				m_Controller.ChangeState (SheepController.SheepStates.IS_IDLE);
			}
		}

		public void OnExit (ISheepStateHandler nextState) {

		}

		[System.Serializable]
		public class Settings {
			public float TimeBeforeIdle = 4;
		}
	}
}
