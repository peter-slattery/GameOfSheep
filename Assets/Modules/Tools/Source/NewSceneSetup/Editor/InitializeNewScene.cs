using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class InitializeNewScene{

	static InitializeNewScene () {
		//EditorSceneManager.sceneLoaded += OnSceneLoaded;
	}

	static void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
		if (!EditorSceneSetupUtil.IsSceneSetup ()) {
			Debug.Log ("Scene Not Setup");
			InitializeSceneWindow.OpenWindow (scene);
		}
	}

	public static void SetupScene (Scene scene, bool fullSetup = false) {
		SafeObjectAccessors.CreateOrFindGameObject ("[Editor] SceneSetupUtil").CreateOrFindComponent<EditorSceneSetupUtil>();

		if (fullSetup) {
			string[] structurePaths = AssetDatabase.FindAssets ("name: SceneStructure");
			foreach (string path in structurePaths) {
				SceneStructureSpecificationData data = AssetDatabase.LoadAssetAtPath<SceneStructureSpecificationData> (path);
				foreach (SceneStructureSpecificationData.SceneStructureObjectSpecificaton objectSpec in data.StructureObjects) {
					objectSpec.ConstructObject ();
				}
			}
		}
	}

}
