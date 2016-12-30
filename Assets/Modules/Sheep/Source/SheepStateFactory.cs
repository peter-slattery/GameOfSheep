using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Sheep {
	public class SheepStateFactory : FactoryBase{

		SheepSystemSettings m_Settings;

		public SheepStateFactory (SheepSystemSettings settings = null) {
			m_Settings = settings;
		}

		public override System.Object Create (params object[] arguments) {
			
			SheepController.SheepStates state = SheepController.SheepStates.IS_IDLE;
			SheepController controller = null;
			SheepModel model = null;

			for (int i = 0; i < arguments.Length; i++) {
				if (arguments [i] is SheepController.SheepStates) {
					state = (SheepController.SheepStates)(arguments [i]);
				} else if (arguments [i] is SheepController) {
					controller = arguments [i] as SheepController;
				} else if (arguments [i] is SheepModel) {
					model = arguments [i] as SheepModel;
				}
			}

			ISheepStateHandler StateHandler;

			switch (state) {
			case SheepController.SheepStates.IS_IDLE:
				StateHandler = new SheepIsIdle (controller, (m_Settings == null ? null : m_Settings.IdleSettings));
				break;
			case SheepController.SheepStates.IS_CALM:
				StateHandler = new SheepIsCalm (controller, (m_Settings == null ? null : m_Settings.CalmSettings));
				break;
			case SheepController.SheepStates.IS_ANXIOUS:
			default:
				StateHandler = new SheepIsAnxious(controller, model, (m_Settings == null ? null : m_Settings.AnxiousSettings));
				break;
			}

			return StateHandler;
		}
	}
}