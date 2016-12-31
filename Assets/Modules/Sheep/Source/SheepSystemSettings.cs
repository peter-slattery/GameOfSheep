using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Sheep {
	[CreateAssetMenu (menuName="Systems/Sheep/Sheep System Settings")]
	public class SheepSystemSettings : ScriptableObject {
		public SheepFactory.Settings FactorySettings;
		public PotentialStatesContainer PotentialStates;
	}
}