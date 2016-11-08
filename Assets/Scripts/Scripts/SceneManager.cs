using UnityEngine;
using System.Collections;
using Tamarrion;
namespace Tamarrion {
	public class SceneManager : MyMonoBehaviour {
		public static SceneManager Instance = null;
		public bool LoadLevelOnStart = false;
		public string LevelName = "";
		bool paused = false;

		void Awake () {
			if ( Instance == null ) {
				Instance = this;
			}

			//AddListener<PauseEvent> (OnPause);
		}

		void OnDestroy () {
			//RemoveListener<PauseEvent> (OnPause);
		}

		/*void OnPause (PauseEvent e) {
			paused = e.paused;
		}*/

		public bool IsPaused () {
			return paused;
		}

		public bool IsNotPaused () {
			return !paused;
		}

		void Start () {
			if ( LoadLevelOnStart && LevelName != "" ) {
				Debug.Log ("loading scene (ON START): " + LevelName);
				LoadLevel (LevelName);
			}
		}

		public void LoadLevel (string p_levelName) {
			Debug.Log ("loading scene: " + p_levelName);
			Application.LoadLevelAsync (p_levelName);
		}

		public void RestartCurrentLevel () {
			LoadLevel (Application.loadedLevelName);
		}

		public static void Quit () {
			if ( Application.isEditor ) {
#if UNITY_EDITOR
				UnityEditor.EditorApplication.ExecuteMenuItem ("Edit/Play");
#endif
			}
			else
				Application.Quit ();
		}
	}
}