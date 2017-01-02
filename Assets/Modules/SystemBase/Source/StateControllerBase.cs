using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfSheep.SystemBase {
	[System.Serializable]
	public class PotentialStatesContainer {
		public List<StateHandlerCustomizationBase> States;
	}

	public class StateControllerBase {

		protected IFacadeBase m_Facade;

		protected PotentialStatesContainer m_Potential;

		protected StateHandlerBase m_CurrentStateHandler;

		public StateControllerBase (
			IFacadeBase facade,
			PotentialStatesContainer potentialStates
		){
			m_Facade = facade;	
			m_Potential = potentialStates;
		}

		public void RequestChangeState <T>() where T : StateHandlerBase {
			if (m_CurrentStateHandler != null && m_CurrentStateHandler is T)
				return;

			int stateIndex = CheckHasPotentialState <T> ();
			if (stateIndex == -1)
				return;

			StateHandlerBase lastState = m_CurrentStateHandler;
			m_CurrentStateHandler = m_Potential.States[stateIndex].Construct(m_Facade);

			if (lastState != null) {
				lastState.OnExit (m_CurrentStateHandler);
			}

			m_CurrentStateHandler.OnEnter (lastState);
		}

		public void RequestChangeState (System.Type state) {
			if (m_CurrentStateHandler != null && m_CurrentStateHandler.GetType() == state)
				return;

			int stateIndex = CheckHasPotentialState (state);
			if (stateIndex == -1)
				return;
			

			StateHandlerBase lastState = m_CurrentStateHandler;
			m_CurrentStateHandler = m_Potential.States [stateIndex].Construct (m_Facade);

			if (lastState != null) {
				lastState.OnExit (m_CurrentStateHandler);
			}

			m_CurrentStateHandler.OnEnter (lastState);
		}

		int CheckHasPotentialState <T> () {
			if (m_Potential == null)
				return -1;
			
			for (int i=0; i<m_Potential.States.Count; i++){
				if (m_Potential.States[i].GetStateHandlerType() == typeof(T)) {
					return i;
				}
			}
			return -1;
		}

		int CheckHasPotentialState (System.Type state) {
			if (m_Potential == null)
				return -1;
			
			for (int i=0; i<m_Potential.States.Count; i++){
				if (m_Potential.States[i].GetStateHandlerType() == state) {
					return i;
				}
			}
			return -1;
		}

		public virtual void OnUpdate() {}
	}
}
