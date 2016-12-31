using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameOfSheep.SystemBase;

namespace GameOfSheep.Movement {
	
	public class TestInputHandler : MonoBehaviour {

		ITargetsMovable targets;
		public float speed;

		// Use this for initialization
		void Start () {
			targets = GetComponent<IFacadeBase> ().Targets as ITargetsMovable;
		}
		
		// Update is called once per frame
		void Update () {
			Vector3 targetOffset = Vector3.zero;

			if (Input.GetKey (KeyCode.UpArrow)) {
				targetOffset += Vector3.forward;	
			}else if (Input.GetKey (KeyCode.DownArrow)) {
				targetOffset += Vector3.forward * -1;
			}

			if (Input.GetKey (KeyCode.LeftArrow)) {
				targetOffset += Vector3.right * -1;
			}else if (Input.GetKey (KeyCode.RightArrow)) {
				targetOffset += Vector3.right;
			}

			targetOffset *= speed * Time.deltaTime;

			targets.MovementTarget = targetOffset + transform.position;
		}
	}
}
