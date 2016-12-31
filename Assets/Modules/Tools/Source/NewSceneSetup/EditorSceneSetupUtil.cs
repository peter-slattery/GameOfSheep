using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorSceneSetupUtil : MonoBehaviour {
	private static EditorSceneSetupUtil m_Instance;

	public static bool IsSceneSetup () {
		if (m_Instance != null)
			return true;

		m_Instance = FindObjectOfType<EditorSceneSetupUtil> ();

		return m_Instance != null;
	}

	void Awake () {
		if (Application.isPlaying) {
			Destroy (gameObject);
		}
	}
}
