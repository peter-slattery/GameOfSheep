using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.SystemBase.Test{
	public class TestIOCContext : BaseIOCContext {
		public override void Construct () {
			Debug.Log ("Child Construct Called");
			base.Construct ();
		}
	}
}