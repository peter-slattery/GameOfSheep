using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfSheep.Sheep {
	[CreateAssetMenu (menuName="Systems/Sheep/Sheep System Settings")]
	public class SheepSystemSettings : ScriptableObject {
		public SheepFactory.Settings FactorySettings;
		public SheepIsAnxious.Settings AnxiousSettings;
		public SheepIsCalm.Settings CalmSettings;
		public SheepIsIdle.Settings IdleSettings;
	}
}