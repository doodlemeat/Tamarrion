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

        void Awake() {
            Load();
            player = this;
        }

        void OnDisable() {
            Save();
        }

        void Start() {
            playerStats = GetComponent<PlayerStats>();
            playerMovement = GetComponent<PlayerMovement>();

            if (WingProgressionUndead.instance)
                WingProgressionUndead.instance.onInitDone += OnProgressionInit;

            cameraFocusPoint = transform.FindChild("Focus point");

            //if (Valac.instance)
            //    _bossTarget = Valac.instance.gameObject;

            if (Application.loadedLevelName == "main_menu") {
                InMenu = true;
                playerMovement.AddMoveBlock("main_menu_scene");
            }
        }

        void Update() {
            if (InMenu || !Alive)
                return;

            if (Input.GetKeyDown(KeyCode.P)) {
                Tamarrion.FreeFlyCamera camera = FindObjectOfType<Tamarrion.FreeFlyCamera>();
                if (camera) {
                    Destroy(camera.gameObject);
                    HUDController.hudController.EnableHUD();
                }
                else {
                    Instantiate(freeFlyCamera, player.transform.position, Quaternion.identity);
                    HUDController.hudController.DisableHUD();
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

            if (Input.GetButtonDown("RightStick_Press")) {
                m_locked_on_boss = !m_locked_on_boss;

                CameraController cameraController = Camera.main.GetComponent<CameraController>();

                if (m_locked_on_boss) {
                    cameraController.LockOntoTarget(true);
                    cameraController.SetLockTarget(Valac.instance.transform);
                }
                else {
                    cameraController.LockOntoTarget(false);
                }
            }

            if (Alive && playerStats.m_stat["health"] == 0) {
                Alive = false;
                //Debug.Log("Die");
                GodManager.Instance.deactivate_current_god();
                if (FSSkillUser.instance)
                    FSSkillUser.instance.AddSkillBlock("death");
                if (Evade.instance)
                    Evade.instance.AddEvadeBlock("death");
                HUDController.hudController.ShowStatsScreen(false);
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
            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKeyDown(KeyCode.B)) {
                if (Valac.instance) {
                    CombatStats valacStats = Valac.instance.GetComponent<CombatStats>();
                    valacStats.DealDamage(valacStats.GetStatValue("max_health") * 0.1f);
                }
            }
#endif

            processComboPoints();
        }

        // Moves the character in the given direction
        public void Move(Vector3 direction) {
            playerMovement.Controller.Move(direction * Time.deltaTime);
        }

        void processComboPoints() {
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

        public void OnIntroCameraFinish() {
            CameraController camera = Camera.main.GetComponent<CameraController>();
            camera.enabled = true;
            camera.Target = cameraFocusPoint;
        }

        public void RemoveCastingSpell() {
            currentCastingSpell = null;
        }

        public bool GetAlive() {
            return Alive;
        }

        public static bool GameObjectIsPlayer(GameObject p_obj) {
            return p_obj.GetComponent<Player>();
        }

        void OnProgressionInit() {
            if (!WingProgressionBase.instance)
                return;

            WingProgressionBase.instance.SetCurrentWingProgression(progressStateName);
            WingProgressionBase.instance.UpdateWingState();
            Transform result = WingProgressionBase.instance.GetProgTransformInCurrent();

            if (result) {
                gameObject.transform.position = result.position;
                gameObject.transform.rotation = result.rotation;
            }
        }

        void SetProgressStateName(string p_progressStateName) {
            progressStateName = p_progressStateName;
        }

        void Save() {
            if (progressStateName == "") {
                Debug.Log("progress name set to nothing in player. no save was made.");
                return;
            }

            BinaryFormatter bff = new BinaryFormatter();
            FileStream ffs = File.Create(Application.persistentDataPath + "/player_progress.dat");

            PlayerProgressData playerProgData = new PlayerProgressData();
            playerProgData.progressStateName = progressStateName;

            bff.Serialize(ffs, playerProgData);
            ffs.Close();
        }

        void Load() {
            if (!File.Exists(Application.persistentDataPath + "/player_progress.dat"))
                return;

            BinaryFormatter bff = new BinaryFormatter();
            FileStream ffs = File.Open(Application.persistentDataPath + "/player_progress.dat", FileMode.Open);

            PlayerProgressData playerProgData = (PlayerProgressData)bff.Deserialize(ffs);
            ffs.Close();

            if (playerProgData.progressStateName != "")
                progressStateName = playerProgData.progressStateName;
            else
                Debug.Log("progress name set to nothing in save file");
        }
    }
}