using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfSheep.SystemBase {
	public abstract class StateHandlerBase : ScriptableObject {

		protected IFacadeBase m_Facade;

		public virtual void Construct (IFacadeBase facade) {
			m_Facade = facade;
		}

		public abstract void OnEnter (StateHandlerBase lastState = null);
		public abstract void OnUpdate ();
		public abstract void OnExit (StateHandlerBase nextState = null);

		[System.Serializable]
		public class Settings {}
		public class Dependencies {}
		public class CurrentFields {}
	}
}
