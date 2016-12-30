using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.Movement;

namespace GameOfSheep.Sheep {
	public class SheepIsAnxious : ISheepStateHandler {

		private SheepController m_Controller;
		private SheepModel m_Model;

		private SheepIsAnxious.Settings m_Settings;

		private float TimeInState;
		private Vector3 StateGoal;

		public SheepIsAnxious (
			SheepController controller, 
			SheepModel model,
			SheepIsAnxious.Settings settings = null
		) {
			m_Controller = controller;
			m_Model = model;

			m_Settings = settings;
			if (m_Settings == null) {
				m_Settings = new Settings();
			}
		}

		public void OnEnter () {
			TimeInState = 0;

			if (m_Model.Targets is ITargetsMovable) {
				Vector2 inCircle = 10 * Random.insideUnitCircle;
				StateGoal = new Vector3 (inCircle.x, 0, inCircle.y);
			}
		}

		public void OnEnter (ISheepStateHandler nextState) {
			OnEnter ();
		}

		public void OnUpdate () {
			// TODO: Replace with real logic
			TimeInState += Time.deltaTime;

			if (TimeInState >= m_Settings.TimeBeforeCalm && m_Controller != null) {
				m_Controller.ChangeState (SheepController.SheepStates.IS_CALM);
				return;
			}

			if (m_Model.Targets is ITargetsMovable) {
				Vector3 towardsGoal = StateGoal - m_Model.Position;
				float distToGoal = towardsGoal.magnitude;

				Vector3 maxMovement = (towardsGoal.normalized * m_Settings.AxiousSpeed * Time.deltaTime);

				if (maxMovement.magnitude > distToGoal) {
					maxMovement = StateGoal;
				} else {
					maxMovement += m_Model.Position;
				}

				(m_Model.Targets as ITargetsMovable).MovementTarget = maxMovement;
			}
		}

		public void OnExit (ISheepStateHandler nextState) {

		}

		[System.Serializable]
		public class Settings {
			public float TimeBeforeCalm = 5.0f;
			public float AxiousSpeed = 2.0f;
		}
	}
}
