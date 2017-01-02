using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Sheep {
	public class SheepIsIdleCustomization : StateHandlerCustomizationBase {

		public SheepIsIdle.Settings Settings;

		public override System.Type GetStateHandlerType () {
			return typeof(SheepIsIdle);
		}

		public override StateHandlerBase Construct (IFacadeBase facade) {
			return new SheepIsIdle (facade, Settings);
		}
	}

	public class SheepIsIdle : StateHandlerBase {

		[System.Serializable]
		public new class Settings : StateHandlerBase.Settings{
			public float TimeBeforeAnxious = 4;
		}

		public SheepIsIdle (
			IFacadeBase facade,
			SheepIsIdle.Settings settings
		) : base (
			facade
		){

		}

		public override void OnEnter (StateHandlerBase lastState) {

		}

		public override void OnUpdate () {
		}

		public override void OnExit (StateHandlerBase nextState) {

		}

	}
}
