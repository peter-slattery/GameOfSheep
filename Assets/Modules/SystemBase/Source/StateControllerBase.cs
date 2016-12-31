using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfSheep.SystemBase {
	[System.Serializable]
	public class PotentialStatesContainer {
		public List<StateHandlerBase> States;
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

			if (!CheckHasPotentialState <T>())
				return;

			StateHandlerBase lastState = m_CurrentStateHandler;
			m_CurrentStateHandler = ScriptableObject.CreateInstance<T>() as StateHandlerBase;
			m_CurrentStateHandler.Construct(m_Facade);

			if (lastState) {
				lastState.OnExit (m_CurrentStateHandler);
			}

			m_CurrentStateHandler.OnEnter (lastState);
		}

		public void RequestChangeState (StateHandlerBase state) {
			if (m_CurrentStateHandler != null && m_CurrentStateHandler.GetType() == state.GetType ())
				return;

			if (!CheckHasPotentialState(state))
				return;

			StateHandlerBase lastState = m_CurrentStateHandler;
			m_CurrentStateHandler = Object.Instantiate(state) as StateHandlerBase;
			m_CurrentStateHandler.Construct (m_Facade);

			if (lastState) {
				lastState.OnExit (m_CurrentStateHandler);
			}

			m_CurrentStateHandler.OnEnter (lastState);
		}

		bool CheckHasPotentialState <T> () {
			if (m_Potential != null)
				return false;
			
			foreach (StateHandlerBase pState in m_Potential.States) {
				if (pState is T) {
					return true;
				}
			}
			return false;
		}

		bool CheckHasPotentialState (StateHandlerBase state) {
			if (m_Potential == null)
				return false;
			
			foreach (StateHandlerBase pState in m_Potential.States) {
				if (pState.GetType() == state.GetType()) {
					return true;
				}
			}
			return false;
		}

		public virtual void OnUpdate() {}
	}
}
