using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Tamarrion {
	public class Player : MonoBehaviour {
		public static Player player = null;

		//private GameObject _bossTarget;
		//public GameObject bossTarget
		//{
		//    get { return this._bossTarget; }
		//}
		//private CharacterController controller;
		private SpellManager2 spellManager;
		private PlayerMovement playerMovement;
		private Transform cameraFocusPoint;
		public PlayerStats playerStats;
		//private GameObject spawnPositionObject;
		private bool Alive = true;
		private GameObject currentCastingSpell;

		public bool InMenu = false;
		public bool m_locked_on_boss = false;
		public Transform LeftHand;

		[SerializeField]
		GameObject freeFlyCamera;

		public string progressStateName = "";

		[System.Serializable]
		class PlayerProgressData {
			public string progressStateName = "";
		}

		void Awake () {
			Load ();
			player = this;
		}

		void OnDisable () {
			Save ();
		}

		void Start () {
			spellManager = SpellManager2.Instance;
			playerStats = GetComponent<PlayerStats> ();
			playerMovement = GetComponent<PlayerMovement> ();

			if ( WingProgressionUndead.instance )
				WingProgressionUndead.instance.onInitDone += OnProgressionInit;

			cameraFocusPoint = transform.FindChild ("Focus point");

			if ( Application.loadedLevelName == "main_menu" ) {
				InMenu = true;
				playerMovement.AddMoveBlock ("main_menu_scene");
			}
		}

		void Update () {
			if ( InMenu || !Alive )
				return;

			if ( Input.GetKeyDown (KeyCode.P) ) {
				FreeFlyCamera camera = FindObjectOfType<FreeFlyCamera> ();
				if ( camera ) {
					Destroy (camera.gameObject);
					HUDController.hudController.EnableHUD ();
				}
				else {
					Instantiate (freeFlyCamera, player.transform.position, Quaternion.identity);
					HUDController.hudController.DisableHUD ();
				}
			}

			if ( Input.GetButtonDown ("RightStick_Press") ) {
				m_locked_on_boss = !m_locked_on_boss;

				CameraController cameraController = Camera.main.GetComponent<CameraController> ();

				if ( m_locked_on_boss ) {
					cameraController.LockOntoTarget (true);
					cameraController.SetLockTarget (Valac.instance.transform);
				}
				else {
					cameraController.LockOntoTarget (false);
				}
			}

			if ( Alive && playerStats.m_stat["health"] == 0 ) {
				Alive = false;
				//Debug.Log("Die");
				GodManager.Instance.deactivate_current_god ();
				if ( FSSkillUser.instance )
					FSSkillUser.instance.AddSkillBlock ("death");
				if ( Evade.instance )
					Evade.instance.AddEvadeBlock ("death");
				HUDController.hudController.ShowStatsScreen (false);
			}
		}

		public void OnIntroCameraFinish () {
			CameraController camera = Camera.main.GetComponent<CameraController> ();
			camera.enabled = true;
			camera.Target = cameraFocusPoint;
		}

		public void RemoveCastingSpell () {
			currentCastingSpell = null;
		}

		public bool GetAlive () {
			return Alive;
		}

		public static bool GameObjectIsPlayer (GameObject p_obj) {
			return p_obj.GetComponent<Player> ();
		}

		void OnProgressionInit () {
			if ( !WingProgressionBase.instance )
				return;

			WingProgressionBase.instance.SetCurrentWingProgression (progressStateName);
			WingProgressionBase.instance.UpdateWingState ();
			Transform result = WingProgressionBase.instance.GetProgTransformInCurrent ();

			if ( result ) {
				gameObject.transform.position = result.position;
				gameObject.transform.rotation = result.rotation;
			}
		}

		void SetProgressStateName (string p_progressStateName) {
			progressStateName = p_progressStateName;
		}

		void Save () {
			if ( progressStateName == "" ) {
				Debug.Log ("progress name set to nothing in player. no save was made.");
				return;
			}

			BinaryFormatter bff = new BinaryFormatter ();
			FileStream ffs = File.Create (Application.persistentDataPath + "/player_progress.dat");

			PlayerProgressData playerProgData = new PlayerProgressData ();
			playerProgData.progressStateName = progressStateName;

			bff.Serialize (ffs, playerProgData);
			ffs.Close ();
		}

		void Load () {
			if ( !File.Exists (Application.persistentDataPath + "/player_progress.dat") )
				return;

			BinaryFormatter bff = new BinaryFormatter ();
			FileStream ffs = File.Open (Application.persistentDataPath + "/player_progress.dat", FileMode.Open);

			PlayerProgressData playerProgData = (PlayerProgressData)bff.Deserialize (ffs);
			ffs.Close ();

			if ( playerProgData.progressStateName != "" )
				progressStateName = playerProgData.progressStateName;
			else
				Debug.Log ("progress name set to nothing in save file");
		}
	}
}