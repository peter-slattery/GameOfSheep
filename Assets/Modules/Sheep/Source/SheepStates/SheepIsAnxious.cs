using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;
using GameOfSheep.Movement;

namespace GameOfSheep.Sheep {
	[CreateAssetMenu (menuName = "Sheep/States/SheepIsAnxious")]
	public class SheepIsAnxious : StateHandlerBase {

		[System.Serializable]
		public new class Settings : StateHandlerBase.Settings {
			public float TimeBeforeCalm = 5.0f;
			public float AxiousSpeed = 2.0f;
		}

		new class Dependencies : StateHandlerBase.Dependencies {
			public SheepController Controller;
			public SheepModel Model;
			public ITargetsMovable Movable;
		}

		new class CurrentFields : StateHandlerBase.CurrentFields {
			public float TimeInState;
			public Vector3 StateGoal;
		}

		[SerializeField]
		private SheepIsAnxious.Settings m_Settings;

		private SheepIsAnxious.Dependencies m_Dependencies;
		private SheepIsAnxious.CurrentFields m_CurrentFields;

		public override void Construct (
			IFacadeBase facade
		) {
			base.Construct (facade);

			m_Dependencies = new SheepIsAnxious.Dependencies ();
			m_CurrentFields = new SheepIsAnxious.CurrentFields ();

			SheepFacade sheepFac = (facade as SheepFacade);

			if (sheepFac) {
				m_Dependencies.Controller = sheepFac.Controller;
				m_Dependencies.Model = sheepFac.Model;
				m_Dependencies.Movable = (sheepFac.Model.Targets as ITargetsMovable);
			}
		}

		public override void OnEnter (StateHandlerBase nextState = null) {
			m_CurrentFields.TimeInState = 0;

			if (m_Dependencies.Model.Targets is ITargetsMovable) {
				Vector2 inCircle = 10 * Random.insideUnitCircle;
				m_CurrentFields.StateGoal = new Vector3 (inCircle.x, 0, inCircle.y);
			}
		}

		public override void OnUpdate () {
			m_CurrentFields.TimeInState += Time.deltaTime;

			if (m_CurrentFields.TimeInState >= m_Settings.TimeBeforeCalm && m_Dependencies.Controller != null) {
				m_Dependencies.Controller.RequestChangeState <SheepIsCalm>();
				return;
			}

			SetMovementTarget ();
		}

		public override void OnExit (StateHandlerBase nextState) {

		}

		private void SetMovementTarget() {
			if (m_Dependencies.Movable == null)
				return;

			Vector3 towardsGoal = m_CurrentFields.StateGoal - m_Dependencies.Model.Position;
			float distToGoal = towardsGoal.magnitude;

			Vector3 maxMovement = (towardsGoal.normalized * m_Settings.AxiousSpeed * Time.deltaTime);

			if (maxMovement.magnitude > distToGoal) {
				maxMovement = m_CurrentFields.StateGoal;
			} else {
				maxMovement += m_Dependencies.Model.Position;
			}

			m_Dependencies.Movable.MovementTarget = maxMovement;
		}
	}
}
