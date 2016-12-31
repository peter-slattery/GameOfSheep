using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SafeObjectAccessors {
	// Use: Safe method of getting a reference to a game object in the scene.
	//		
	public static GameObject CreateOrFindGameObject (string name) {
		GameObject retVal = GameObject.Find (name);
		if (retVal == null)
			retVal = new GameObject (name);
		return retVal;
	}

	// Use: Safe method of getting a reference to a component. 
	public static T CreateOrFindComponent<T> (this GameObject searchOn) where T : MonoBehaviour{
		T component = searchOn.GetComponent<T> ();
		if (component == null)
			component = searchOn.AddComponent<T> ();
		return component;
	}
}