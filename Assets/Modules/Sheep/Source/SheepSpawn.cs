using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Sheep {
	public class SheepSpawn : SpawnBase<SheepFacade>{

		public override void Construct () {
			base.Construct ();
			Spawn ();
		}

		public void Spawn () {
			SheepFacade facade = base.Spawn (transform);
		}
	}
}