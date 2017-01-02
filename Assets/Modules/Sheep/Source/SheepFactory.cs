using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.Movement;
using GameOfSheep.SystemBase;

namespace GameOfSheep.Sheep {
	public class SheepFactory : FactoryBase {

		private SheepSystemSettings m_Settings;

		public SheepFactory () {
		}

		public void Construct (SheepSystemSettings settings){
			m_Settings = settings;
		}

		public override System.Object Create (params object[] arguments) {

			GameObject sheep = new GameObject ("Sheep");

			GameObject sheepVisuals; 

			if (m_Settings != null) {
				sheepVisuals = GameObject.Instantiate<GameObject> (m_Settings.FactorySettings.SheepVisualPrefab);
			}else{
				sheepVisuals = GameObject.CreatePrimitive (PrimitiveType.Cube);
			}

			sheepVisuals.transform.SetParent (sheep.transform);
			sheepVisuals.transform.localPosition = Vector3.zero;
			sheepVisuals.transform.localRotation = Quaternion.Euler (0, 90, 0);

			for (int i = 0; i < arguments.Length; i++) {
				if (arguments [i] is Transform) {
					Transform setTo = arguments [i] as Transform;
					sheep.transform.position = setTo.position;
					sheep.transform.rotation = setTo.rotation;
					sheep.transform.localScale = setTo.localScale;
				}
			}

			SheepFacade facade = sheep.AddComponent<SheepFacade> ();
			facade.Construct (m_Settings);

			GroundBasedMovement gbm = sheep.AddComponent<GroundBasedMovement> ();
			gbm.Construct ();
			FaceTowardsTarget ftt = sheep.AddComponent<FaceTowardsTarget> ();
			ftt.Construct ();

			return facade;
		}

		[System.Serializable]
		public class Settings {
			public GameObject SheepVisualPrefab;
		}
	}
}