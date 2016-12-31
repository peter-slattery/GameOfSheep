using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Editor Utility/Scene Structure Specification")]
public class SceneStructureSpecificationData : ScriptableObject {

	[System.Serializable]
	public class SceneStructureObjectSpecificaton {
		public string Name;
		public MonoBehaviour[] Components;
		public SceneStructureObjectSpecificaton[] Children;

		public GameObject ConstructObject () {
			GameObject reference = SafeObjectAccessors.CreateOrFindGameObject(Name);
			foreach (MonoBehaviour c in Components) {
				reference.AddComponent (c.GetType());
			}
			foreach (SceneStructureObjectSpecificaton child in Children) {
				child.ConstructObject ().transform.SetParent (reference.transform);
			}
			return reference;
		}
	}

	public SceneStructureObjectSpecificaton[] StructureObjects;
}
