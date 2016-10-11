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
		private SpellManager spellManager;
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
			spellManager = SpellManager.Instance;
			playerStats = GetComponent<PlayerStats> ();
			playerMovement = GetComponent<PlayerMovement> ();

			if ( WingProgressionUndead.instance )
				WingProgressionUndead.instance.onInitDone += OnProgressionInit;

			cameraFocusPoint = transform.FindChild ("Focus point");

			//if (Valac.instance)
			//    _bossTarget = Valac.instance.gameObject;

			if ( Application.loadedLevelName == "main_menu" ) {
				InMenu = true;
				playerMovement.AddMoveBlock ("main_menu_scene");
			}
		}

		void Update () {
			if ( InMenu || !Alive )
				return;

			if ( Input.GetKeyDown (KeyCode.P) ) {
				Tamarrion.FreeFlyCamera camera = FindObjectOfType<Tamarrion.FreeFlyCamera> ();
				if ( camera ) {
					Destroy (camera.gameObject);
					HUDController.hudController.EnableHUD ();
				}
				else {
					Instantiate (freeFlyCamera, player.transform.position, Quaternion.identity);
					HUDController.hudController.DisableHUD ();
				}
			}

			//if (Input.GetButtonDown("Spell A") || Input.GetKeyDown(KeyCode.Alpha1))
			//{
			//    useSpell(0);

			//    //Gender gender = Gender.Male;
			//    //Analytics.SetUserGender(gender);

			//    //int birthYear = 2014;
			//    //Analytics.SetUserBirthYear(birthYear);
			//}
			//else if (Input.GetButtonDown("Spell B") || Input.GetKeyDown(KeyCode.Alpha2))
			//{
			//    useSpell(1);
			//}
			//else if (Input.GetButtonDown("Spell X") || Input.GetKeyDown(KeyCode.Alpha3))
			//{
			//    useSpell(2);
			//}
			//else if (Input.GetButtonDown("Spell Y") || Input.GetKeyDown(KeyCode.Alpha4))
			//{
			//    useSpell(3);
			//}

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

			//if (Input.GetButton("Spell A") && Input.GetButton("Spell B") && Input.GetButton("Spell X") && Input.GetButton("Spell Y") && Input.GetButton("RightStick_Press"))
			//{
			//    FirstBoss.instance.GetComponent<Enemy_Stats>().DealDamage(999999);
			//}

			//if (Input.GetKeyDown(KeyCode.V))
			//{
			//    PlayerStats.instance.ComboPoints.Add(new ComboPoint(FSSkillElement.FS_Elem_Magic));
			//    PlayerStats.instance.ComboPoints.Add(new ComboPoint(FSSkillElement.FS_Elem_Magic));
			//}

			//if (Input.GetKeyDown(KeyCode.B))
			//{
			//    PlayerStats.instance.ComboPoints.Add(new ComboPoint(FSSkillElement.FS_Elem_War));
			//}

#if UNITY_EDITOR
			if ( (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) && Input.GetKeyDown (KeyCode.B) ) {
				if ( Valac.instance ) {
					CombatStats valacStats = Valac.instance.GetComponent<CombatStats> ();
					valacStats.DealDamage (valacStats.GetStatValue ("max_health") * 0.1f);
				}
			}
#endif

			processComboPoints ();
		}

		void processComboPoints () {
			/* Give player a god */
			//if (godManager != null)
			//    if (godManager.CurrentGod != null)
			//        return;

			////if (playerStats.ComboPoints.Count < 5)
			////    return;

			//if (godManager == null)
			//{
			//    //Debug.Log("God manager is null. Check if the god manager script lies in the player object as a component.");
			//    return;
			//}

			//if (!godManager.fetchGod(playerStats.ComboPoints[0]))
			//{
			//    //Debug.Log("Unable to select a god.");
			//    return;
			//}

			/* Give player bonuses */
			//for (int i = 1; i < 5; ++i)
			//{
			//    ComboPoint CP = playerStats.ComboPoints[i];
			//    bool HaveBonus = false;
			//    // Check what bonuses we already have so we don't duplicate a bonus
			//    for (int k = 0; k < godManager.ActiveBonuses.Count; ++k)
			//    {
			//        if (CP.element == godManager.ActiveBonuses[k].element)
			//        {
			//            HaveBonus = true;
			//            break;
			//        }
			//    }

			//    if (HaveBonus)
			//    {
			//        continue;
			//    }

			//    int Power = 0;
			//    float TimerTime = godManager.CurrentGod.Time;

			//    // Check how many bonuses there are and increase the Power of the bonus
			//    for (int k = 1; k < 5; ++k)
			//    {
			//        if (playerStats.ComboPoints[k].element == CP.element)
			//        {
			//            ++Power;
			//        }
			//    }

			//    // Find the right bonus and activate it
			//    for (int m = 0; m < godManager.Bonuses.Count; ++m)
			//    {
			//        if (godManager.Bonuses[m].element == CP.element)
			//        {
			//            Bonus_Base bonusObject = Instantiate(godManager.Bonuses[m]);
			//            bonusObject.transform.parent = godManager.transform;
			//            bonusObject.Activate(Power, TimerTime);
			//            godManager.ActiveBonuses.Add(bonusObject);
			//            break;
			//        }
			//    }
			//}
		}

		void useSpell (int p_slot) {
			GameObject spellObject = spellManager.GetSpellInSlot (p_slot);
			if ( !spellObject ) {
				return;
			}

			if ( currentCastingSpell == spellObject )
				return;

			SpellBase spell = spellObject.GetComponent<SpellBase> ();

			if ( !spell._canBeCastBeforeBoss && !Valac.instance.IsActive () ) {
				ErrorBar.instance.SpawnText ("No target");
				return;
			}

			if ( !GetComponent<PlayerMovement> ().RotationEnabled () && (gameObject.GetComponentInChildren<Animator> ().GetBool ("Attack") && !spell._castThroughAttack) ) {
				ErrorBar.instance.SpawnText ("Can not cast spells right now");
				return;
			}

			if ( !spell.isCool () ) {
				ErrorBar.instance.SpawnText ("Cooldown active");
				return;
			}

			if ( spell._castTime > 0.0f && playerMovement.IsMoving () ) {
				if ( !GodManager.Instance.CurrentGod || GodManager.Instance.CurrentGod.element != FSSkillElement.FS_Elem_Nature ) {
					ErrorBar.instance.SpawnText ("Must stand still");
					return;
				}
			}

			if ( spell._ranged ) {
				//if (!_bossTarget)
				//    return;

				//if (Vector3.Distance(transform.position, _bossTarget.transform.position) > spell._range + spellCollider.radius)
				//{
				//    ErrorBar.instance.SpawnText("Out of range");
				//    return;
				//}

				if ( spell._angleDependent ) {
					Vector3 LookDir = new Vector3 (Valac.instance.transform.position.x, transform.position.y, Valac.instance.transform.position.z);
					Quaternion direction = Quaternion.LookRotation (LookDir - transform.position);
					transform.rotation = direction;

					//raycast check
					float DistanceToBoss = Vector3.Distance (Player.player.gameObject.transform.position, Valac.instance.gameObject.transform.position);
					if ( DistanceToBoss > Valac.instance.gameObject.GetComponentInChildren<SphereCollider> ().radius ) {
						//RaycastHit hitInfo = new RaycastHit();
						//Ray ray = new Ray(transform.position + new Vector3(0, 2, 0), transform.forward);
						//bool hit = Physics.Raycast(ray, out hitInfo, spell._range);

						//if (hit && hitInfo.collider != spellCollider)
						//{
						//    ErrorBar.instance.SpawnText("Obstacle in the way");
						//    return;
						//}
					}
				}
			}

			if ( currentCastingSpell && currentCastingSpell != spellObject ) {
				currentCastingSpell.GetComponent<SpellBase> ().CancelSpell ();
			}

			currentCastingSpell = spellObject;
			spell.cast ();
			if ( spell._castTime > 0 )
				Player.player.GetComponentInChildren<CastHandEffect> ().SetSpellEffect ((int)spell.element);
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