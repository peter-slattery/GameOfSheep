using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;
using GameOfSheep.Movement;

namespace GameOfSheep.Sheep {
	public class SheepFacade : MonoBehaviour, IFacadeBase {

		private bool m_Constructed = false;

		private SheepModel m_Model;
		private SheepController m_Controller;
		private SheepStateFactory m_StateFactory;

		private SheepSystemSettings m_Settings;

		public TargetsBase Targets { get { return m_Model.Targets; } }

		public void Construct (SheepSystemSettings settings = null) {
			if (m_Constructed)
				return;
			
			m_Settings = settings;
			
			m_Model = new SheepModel (GetComponent<Transform>());
			m_StateFactory = new SheepStateFactory (m_Settings);
			m_Controller = new SheepController (m_StateFactory, m_Model);

			m_Constructed = true;
		}

		public void Initialize () {

		}

		void Awake () {
			Construct ();
		}

		void Start () {
			Initialize ();
		}

		void Update () {
			m_Controller.OnUpdate ();
		}
	}
}