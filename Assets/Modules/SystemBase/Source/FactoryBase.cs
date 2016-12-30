using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfSheep.SystemBase {
	public abstract class FactoryBase{
		public abstract System.Object Create (params object[] arguments);
	}
}