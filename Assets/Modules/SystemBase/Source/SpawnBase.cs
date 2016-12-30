using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfSheep.SystemBase {
	public class SpawnBase<T> : MonoBehaviour where T : IFacadeBase {

		private FactoryBase m_TFactory;

		public virtual void Construct () {
			Register ();
		}

		void Register () {
			BaseIOCContext[] contexts = FindObjectsOfType<BaseIOCContext> ();

			foreach (BaseIOCContext c in contexts) {
				FactoryBase TFactory = c.GetFactoryForType<T> ();
				if (TFactory != null) {
					m_TFactory = TFactory;
					break;
				}
			}
		}

		void Start () {
			Construct ();
		}

		public virtual T Spawn (params object[] arguments) {
			return (T)m_TFactory.Create (arguments);
		}
	}
}