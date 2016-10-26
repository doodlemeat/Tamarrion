using UnityEngine;
using System.Collections;
using UnityEditor;
using Tamarrion;

[CustomEditor(typeof(SpawnOrbFromUrn))]
public class SpawnOrbEditor : Editor {
	public override void OnInspectorGUI() {
		SpawnOrbFromUrn script = (SpawnOrbFromUrn) target;
		
		script.healthOrb = (GameObject) EditorGUILayout.ObjectField("Health Orb", script.healthOrb, typeof(GameObject), false);

		GUILayout.Label("Probability of spawning orb (0-100)%");
		string[] names = System.Enum.GetNames(typeof(Difficulty));
		for (int i = 0; i < names.Length; i++) {
			script.probability[i] = EditorGUILayout.FloatField(names[i], script.probability[i]);
		}
	}
}
