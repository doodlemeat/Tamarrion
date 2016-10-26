using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

namespace Tamarrion {
    public class FightStatsScreen : MonoBehaviour {
        public static FightStatsScreen Instance;
        public float ActivationDelay = 2;
        public Color ColorVictory = new Color(1, 1, 1, 1);
        public Color ColorDefeat = new Color(1, 1, 1, 1);
        public GameObject VictoryAnim;
        public GameObject DefeatAnim;

        private Text StatsText = null;
        //private Text TitleText = null;
        private Text Title2Text = null;
        private Text StatnamesText = null;
        private Text LootText = null;
        private GameObject ResetButtonObj = null;
        //private GameObject HighscoreButtonObj = null;
        private GameObject MainMenuButtonObj = null;
        private bool Activated = false;
        private bool Victory = true;
        private float ActivationDelayCurrent = 2;
        private GameObject MainMenu = null;
        private GameObject Reset = null;

        private float SavedStats_Time;
        private float SavedStats_DPS;
        private float SavedStats_DamageDealt;
        private float SavedStats_DamageTaken;
        private float SavedStats_HealingDone;

        float _timeTaken;

        void Awake() {
            Instance = this;
        }

        void Start() {
            ActivationDelayCurrent = ActivationDelay;
            InitChildren();
        }

        void Update() {
            if (ActivationDelayCurrent == 0)
                return;

            ActivationDelayCurrent -= Time.deltaTime;
            if (ActivationDelayCurrent <= 0) {
                ActivationDelayCurrent = 0;
                MainMenuButtonObj.GetComponent<Button>().interactable = true;
                if (!Victory) {
                    Button resetButtonScript = ResetButtonObj.GetComponent<Button>();
                    resetButtonScript.interactable = true;
                    resetButtonScript.Select();
                    MainMenuButtonObj.GetComponent<Button>().interactable = true;
                }
                else {
                    MainMenuButtonObj.GetComponent<Button>().Select();
                }
            }
        }

        void InitChildren() {
            MainMenu = transform.FindChild("MainMenuButton").gameObject;
            Reset = transform.FindChild("RestartButton").gameObject;
            StatsText = transform.FindChild("Statnumbers").gameObject.GetComponent<UnityEngine.UI.Text>();
            //TitleText = transform.FindChild("Title").gameObject.GetComponent<UnityEngine.UI.Text>();
            Title2Text = transform.FindChild("Title 2").gameObject.GetComponent<UnityEngine.UI.Text>();
            StatnamesText = transform.FindChild("Statnames").gameObject.GetComponent<UnityEngine.UI.Text>();
            LootText = transform.FindChild("Loot").gameObject.GetComponent<UnityEngine.UI.Text>();
            ResetButtonObj = transform.FindChild("Restart").gameObject;
            //HighscoreButtonObj = transform.FindChild("RegisterHighscore").gameObject;
            MainMenuButtonObj = transform.FindChild("MainMenu").gameObject;
            ResetButtonObj.GetComponent<Button>().interactable = false;
            MainMenuButtonObj.GetComponent<Button>().interactable = false;
        }

        void UpdateStats(bool p_victory) {
            StatsText.text = "";

            SavedStats_Time = FightStats.GetElapsedTime();
            SavedStats_DamageDealt = (int)Mathf.Ceil(FightStats.DamageDealt);
            SavedStats_DPS = (int)Mathf.Ceil(FightStats.DamageDealt / _timeTaken);
            SavedStats_DamageTaken = (int)Mathf.Ceil(FightStats.DamageTaken);
            SavedStats_HealingDone = (int)Mathf.Ceil(FightStats.HealingDone);

            //difficulty
            if (p_victory || DifficultyManager.current != Difficulty.Beginner)
                StatsText.text += DifficultyManager.current.ToString() + "\n";
            //boss health
            if (!p_victory)
                StatsText.text += (int)(Valac.instance.GetComponent<CombatStats>().GetPercentageHP() * 100) + "% (" + (int)Valac.instance.GetComponent<CombatStats>().m_stat["health"] + " health)\n";
            //time
            int hours = (int)(SavedStats_Time / 60.0f / 60.0f);
            int minutes = (int)(SavedStats_Time / 60.0f);
            int seconds = (int)(SavedStats_Time % 60.0f);
            if (hours > 0)
                StatsText.text += string.Format("{0:D1}h ", hours);
            if (minutes > 0)
                StatsText.text += string.Format("{0:D1}m ", minutes);
            StatsText.text += string.Format("{0:D1}s", seconds) + "\n";
            //damage done
            StatsText.text += (int)SavedStats_DamageDealt + "\n";
            //damage per second
            StatsText.text += (int)SavedStats_DPS + "\n";
            //damage taken
            StatsText.text += (int)SavedStats_DamageTaken + "\n";
            //healing done
            StatsText.text += (int)SavedStats_HealingDone;
        }

        public void SetVictory(bool p_victory) {
            Victory = p_victory;
            if (Activated)
                return;

            Player.player.InMenu = true;
            _timeTaken = FightStats.GetElapsedTime();
            Activated = true;
            InitChildren();

            if (p_victory) {
                FadeOnEnable fadeInScript = gameObject.GetComponent<FadeOnEnable>();
                fadeInScript.ChangeDelay(8);

                if (Valac.instance.DeathCameraTarget)
                    CameraController.instance.Target = Valac.instance.DeathCameraTarget.transform;
                else
                    CameraController.instance.Target = Valac.instance.gameObject.transform;

                CameraController.instance.Distance *= 1.5f;

                //TitleText.text = "VICTORY";
                //TitleText.color = ColorVictory;
                Title2Text.color = ColorVictory;
                transform.Find("Victory_Background").GetComponent<RawImage>().color = Color.white;
                StatnamesText.color = ColorVictory;
                VictoryAnim.SetActive(true);
                //			MainMenu.SetActive (true);
                StatnamesText.text = "Difficulty:\nTime:\nDamage dealt:\nDamage per second:\nDamage taken:\nHealing done:";
                LootText.color = ColorVictory;
                LootText.text = "Loot: ";
                //This drop table is bugged and drags a lot of other functionality down with it so it's gone for now.
                //if (Difficulty.Current_difficulty == Difficulty.difficulty.beginner)
                //    GetComponentInChildren<GiveLootOnKillingBoss>().GiveLoot(InventoryManager.inventoryManager.GetAvailableItemIndexByName("Lord Valac’s Ring"));
                //if (Difficulty.Current_difficulty == Difficulty.difficulty.normal)
                //    GetComponentInChildren<GiveLootOnKillingBoss>().GiveLoot(InventoryManager.inventoryManager.GetAvailableItemIndexByName("Lord Valac’s Greatsword"));
                //if (Difficulty.Current_difficulty == Difficulty.difficulty.brutal)
                //    GetComponentInChildren<GiveLootOnKillingBoss>().GiveLoot(InventoryManager.inventoryManager.GetAvailableItemIndexByName("Silver Ring"));
                ResetButtonObj.SetActive(false);
            }
            else {
                FadeOnEnable fadeInScript = gameObject.GetComponent<FadeOnEnable>();
                fadeInScript.ChangeDelay(2);

                //TitleText.text = "DEFEAT";
                //TitleText.color = ColorDefeat;
                Title2Text.color = ColorDefeat;
                transform.Find("Defeat_Background").GetComponent<RawImage>().color = Color.white;
                StatnamesText.color = ColorDefeat;
                DefeatAnim.SetActive(true);
                //			MainMenu.SetActive (true);
                //			Reset.SetActive (true);
                if (DifficultyManager.current != Difficulty.Beginner)
                    StatnamesText.text = "Difficulty:\nBoss health:\nTime:\nDamage dealt:\nDamage per second:\nDamage taken:\nHealing done:";
                else
                    StatnamesText.text = "Boss health:\nTime:\nDamage dealt:\nDamage per second:\nDamage taken:\nHealing done:";
                LootText.color = ColorDefeat;
                LootText.text = "";
                //HighscoreButtonObj.SetActive(false);
            }

            PauseMenu.instance.gameObject.SetActive(false);
            UpdateStats(p_victory);
        }

        public void SendHighscore() {
            JSONObject scoreObject = new JSONObject();
            scoreObject.AddField("name", HighscoreInputManager.instance.GetName());
            scoreObject.AddField("damageTaken", SavedStats_DamageTaken);
            scoreObject.AddField("damageDealt", SavedStats_DamageDealt);
            scoreObject.AddField("healingDone", SavedStats_HealingDone);
            scoreObject.AddField("time", SavedStats_Time);
            scoreObject.AddField("difficulty", (int)DifficultyManager.current);
        }

        public void SelectMainMenuButton() {

        }
    }
}