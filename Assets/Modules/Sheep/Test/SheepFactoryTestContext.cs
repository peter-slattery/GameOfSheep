using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;
using GameOfSheep.Sheep;

namespace GameOfSheep.Sheep.Test {
	public class SheepFactoryTestContext : BaseIOCContext {

		[SerializeField]
		private SheepSystemSettings m_SheepSystemSettings;

		public override void Construct () {
			base.Construct ();
			SheepFactory sheepFactory = BindAndGetFactory <SheepFacade, SheepFactory>() as SheepFactory;
			sheepFactory.Construct (m_SheepSystemSettings);
		}
	}
}