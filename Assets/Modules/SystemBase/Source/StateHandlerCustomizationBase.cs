using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfSheep.SystemBase {
	public abstract class StateHandlerCustomizationBase : ScriptableObject{
		public abstract System.Type GetStateHandlerType();

		public abstract StateHandlerBase Construct (IFacadeBase facade);
	}

	public abstract class StateHandlerBase {
		[System.Serializable]
		public class Settings {}
		public class Dependencies {}
		public class CurrentFields {}

		protected IFacadeBase m_Facade;

		public StateHandlerBase (
			IFacadeBase facade
		) {
			m_Facade = facade;
		}

		public abstract void OnEnter (StateHandlerBase lastState = null);
		public abstract void OnUpdate ();
		public abstract void OnExit (StateHandlerBase nextState = null);
	}
}
