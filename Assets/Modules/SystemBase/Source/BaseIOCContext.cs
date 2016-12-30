using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfSheep.SystemBase {
	public class BaseIOCContext : MonoBehaviour {

		// Relates the type of a facade to the type of factory which creates it.
		// This is used to lazily instantiate factories, which are stored in m_FactoryInstances
		private Dictionary<string, string> m_BoundFactories;

		// This is where instances of Factories are store, in relation to the type of the facade they create
		private Dictionary<string, FactoryBase> m_FactoryInstances;

		public virtual void Construct () {
			m_BoundFactories = new Dictionary<string, string> ();
			m_FactoryInstances = new Dictionary<string, FactoryBase> ();
		}

		public void BindFactory <T, U> () {

			string typeNameT = typeof(T).AssemblyQualifiedName;
			string typeNameU = typeof(U).AssemblyQualifiedName;
			
			if (m_BoundFactories.ContainsKey (typeNameT)) {
				Debug.Log ("Trying to Bind a second factory of type " + typeNameU + " for type " + typeNameT + ". Aborting.");
				return;
			}

			m_BoundFactories.Add (typeNameT, typeNameU);
		}

		public FactoryBase GetFactoryForType <T> () {
			string typeNameT = typeof(T).AssemblyQualifiedName;

			FactoryBase factory; 
			m_FactoryInstances.TryGetValue(typeNameT, out factory);

			if (factory != null) {
				return factory;
			}

			return CreateFactoryForType<T>();
		}

		public FactoryBase BindAndGetFactory<T, U> () {
			BindFactory <T, U> ();
			return GetFactoryForType<T> ();
		}

		FactoryBase CreateFactoryForType <T>() {
			string typeName = typeof(T).AssemblyQualifiedName;
			string boundName = "";
			m_BoundFactories.TryGetValue (typeName, out boundName);

			if (boundName == null) {
				Debug.Log ("Factory Binding for type " + typeof(T).Name + " not found. Aborting.");
				return null;
			}

			FactoryBase factory = System.Activator.CreateInstance(System.Type.GetType(boundName)) as FactoryBase;

			if (factory != null) {
				m_FactoryInstances.Add (typeName, factory);
			}

			return factory;
		}

		void Awake () {
			Construct ();
		}

	}
}