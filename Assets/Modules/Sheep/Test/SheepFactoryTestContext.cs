using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;
using GameOfSheep.Sheep;

// This Test Is Designed To Test That:
// - A sheep prefab can be placed in a scene and function without being created by a factory
// - A sheep can be instantiated via factory 
// 		- That this holds whether the BaseIOCContext has a reference to corret settings or not
// - Spawners can request an instance of their Facade be Created by a factory
// - Spawners don't throw errors when there is no BaseIOCContext

namespace GameOfSheep.Sheep.Test {
	public class SheepFactoryTestContext : BaseIOCContext {

		[SerializeField]
		private SheepSystemSettings m_SheepSystemSettings;

		public override void Construct () {
			base.Construct ();

			SheepFactory sheepFactory = BindAndGetFactory <SheepFacade, SheepFactory>() as SheepFactory;
			sheepFactory.Construct (m_SheepSystemSettings);

			Ready = true;
		}
	}
}