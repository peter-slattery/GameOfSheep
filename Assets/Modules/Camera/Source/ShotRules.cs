using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRules : MonoBehaviour {

	Camera cam;

	[SerializeField]
	Vector3 targetScreenPosition = Vector2.one * .5f;

	[SerializeField]
	GameObject target;

	void Awake () {
		cam = GetComponentInChildren<Camera> ();
		cam.transform.localPosition = Vector3.zero;
		cam.transform.localRotation = Quaternion.identity;
		Debug.Log (targetScreenPosition);
	}

	void Update () {
		
		//Vector3 screenPoint = cam.WorldToScreenPoint (target.transform.position);

		// Used to lerp
		//float dist = Vector3.Distance (screenPoint, targetScreenPosition);

		//Ray toTarget = new Ray (cam.transform.position,
	}


}
