using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;
using GameOfSheep.Movement;

namespace GameOfSheep.Sheep {
	[CreateAssetMenu (menuName = "Sheep/States/SheepIsCalm")]
	public class SheepIsCalmCustomization : StateHandlerCustomizationBase {

		public SheepIsCalm.Settings Settings;

		public override System.Type GetStateHandlerType () {
			return typeof(SheepIsCalm);
		}

		public override StateHandlerBase Construct (IFacadeBase facade) {
			return new SheepIsCalm (facade, Settings);
		}
	}

	public class SheepIsCalm : StateHandlerBase {

		[System.Serializable]
		public class Settings {
			public float TimeBeforeIdle = 4;
		}

		public class Dependencies : StateHandlerBase.Dependencies {
			public SheepController Controller;
			public SheepModel Model;
		}

		public class CurrentFields : StateHandlerBase.CurrentFields {
			public float TimeInState;
		}

		[SerializeField]
		private SheepIsCalm.Settings m_Settings;

		private SheepIsCalm.Dependencies m_Dependencies;
		private SheepIsCalm.CurrentFields m_CurrentFields;

		public SheepIsCalm (
			IFacadeBase facade,
			SheepIsCalm.Settings settings
		) : base (
			facade
		){
			m_Settings = settings;
			m_Dependencies = new SheepIsCalm.Dependencies ();
			m_CurrentFields = new SheepIsCalm.CurrentFields ();

			SheepFacade sheepFac = (facade as SheepFacade);

			if (sheepFac) {
				m_Dependencies.Controller = sheepFac.Controller;
				m_Dependencies.Model = sheepFac.Model;
				ITargetsMovable movable = m_Dependencies.Model.Targets as ITargetsMovable;
				if (movable != null) {
					movable.MovementTarget = m_Dependencies.Model.Position + Vector3.forward;
				}
			}
		}

		public override void OnEnter (StateHandlerBase nextState) {
			m_CurrentFields.TimeInState = 0;

			m_Dependencies.Model.GetAnimator ().SetFloat ("Moving", 0.0f);

			Debug.Log ("Entering Calm");
		}

		public override void OnUpdate () {
			m_CurrentFields.TimeInState += Time.deltaTime;

			if (m_CurrentFields.TimeInState >= m_Settings.TimeBeforeIdle && m_Dependencies.Controller != null) {
				m_Dependencies.Controller.RequestChangeState <SheepIsAnxious> ();
			}
		}

		public override void OnExit (StateHandlerBase nextState) {

		}
	}
}

