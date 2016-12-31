using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Movement {
	public class TestFacade : MonoBehaviour, IFacadeBase {

		private TestModel m_Model;

		public TestModel Model { get { return m_Model; } }
		public TargetsBase Targets { get { return Model.Targets; } }

		public void Construct () {
			m_Model = new TestModel ();
		}

		void Awake () {
			Construct ();
		}
	}
}