using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfSheep.Sheep {

	public interface ISheepStateHandler {
		void OnEnter ();
		void OnEnter (ISheepStateHandler previousState);
		void OnUpdate ();
		void OnExit (ISheepStateHandler nextState);
	}

	public class SheepController {

		public enum SheepStates { IS_IDLE, IS_CALM, IS_ANXIOUS, LAST };

		public SheepStates CurrentState {
			get;
			private set;
		}

		private ISheepStateHandler m_CurrentStateHandler;

		private SheepStateFactory m_StateFactory;
		private SheepModel m_Model;

		public SheepController (
			SheepStateFactory stateFactory,
			SheepModel model
		) {
			// Set the properties initial value so that when we change state, it actually doesn't immediately return
			CurrentState = SheepStates.LAST;

			m_StateFactory = stateFactory;
			m_Model = model;

			ChangeState (SheepStates.IS_IDLE);
		}

		public void ChangeState (SheepStates state) {
			if (CurrentState == state)
				return;

			ISheepStateHandler nextState;

			nextState = m_StateFactory.Create (state, this, m_Model) as ISheepStateHandler;

			ISheepStateHandler lastState = m_CurrentStateHandler;

			CurrentState = state;
			m_CurrentStateHandler = nextState;

			if (lastState != null) {
				lastState.OnExit (m_CurrentStateHandler);
				m_CurrentStateHandler.OnEnter (lastState);
			} else {
				m_CurrentStateHandler.OnEnter ();
			}
		}

		public void OnUpdate () {
			m_CurrentStateHandler.OnUpdate ();
		}
	}
}