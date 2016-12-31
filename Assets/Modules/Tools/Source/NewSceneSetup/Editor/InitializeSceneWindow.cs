using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InitializeSceneWindow : EditorWindow{

	public UnityEngine.SceneManagement.Scene sceneToInitialize;

	public static InitializeSceneWindow OpenWindow (UnityEngine.SceneManagement.Scene scene) {
		InitializeSceneWindow window = EditorWindow.GetWindow<InitializeSceneWindow> (true, "Initialize Scene", true);
		window.sceneToInitialize = scene;
		return window;
	}

	void OnGUI () {
		EditorGUILayout.HelpBox ("Initialize the Scene?", MessageType.Info);

		Rect buttonGroup = EditorGUILayout.BeginHorizontal ();

		if (GUILayout.Button ("Initialize")) {
			InitializeNewScene.SetupScene (sceneToInitialize, true);
			Close ();
		}
		if (GUILayout.Button ("Skip")) {
			InitializeNewScene.SetupScene (sceneToInitialize, false);
			Close ();
		}

		EditorGUILayout.EndHorizontal ();
	}

	void OnDestroy () {

	}
}
