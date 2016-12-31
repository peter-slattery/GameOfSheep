using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfSheep.SystemBase {
	public class SpawnBase<T> : MonoBehaviour where T : IFacadeBase {

		private BaseIOCContext m_RegisteredTo;
		private FactoryBase m_TFactory;

		private bool m_Ready = false;
		public bool Ready { get { return m_Ready; } }

		public virtual void Construct () {
			Register ();
		}

		void Register () {
			BaseIOCContext[] contexts = FindObjectsOfType<BaseIOCContext> ();

			foreach (BaseIOCContext c in contexts) {
				if (!c.Ready)
					continue;
				
				FactoryBase TFactory = c.GetFactoryForType<T> ();
				if (TFactory != null) {
					m_TFactory = TFactory;
					m_Ready = true;
					break;
				}
			}
		}

		void Start () {
			Construct ();
		}

		public virtual T Spawn (params object[] arguments) {
			if (m_TFactory == null)
				Register ();

			if (!Ready) {
				Debug.Log ("Spawner " + gameObject.name + " trying to spawn before ready. Aborting.");
				return default(T);
			}
			
			return (T)m_TFactory.Create (arguments);
		}
	}
}