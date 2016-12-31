using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Sheep {
	public class SheepSpawn : SpawnBase<SheepFacade>{

		bool hasSpawned = false;

		public override void Construct () {
			base.Construct ();
		}

		void Update () {
			if (!hasSpawned) {
				hasSpawned = Spawn ();
			}
		}

		public bool Spawn () {
			SheepFacade facade = base.Spawn (transform);
			return facade != null;
		}
	}
}