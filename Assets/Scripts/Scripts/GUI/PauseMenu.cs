using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Tamarrion {
    public class PauseMenu : MonoBehaviour {
        public static PauseMenu instance;
        public Button DefaultButton;

        private CanvasGroup canvasGroup;
        private bool Active = false;

        void Awake() {
            instance = this;
        }

        void Start() {
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        void Update() {
            if (Input.GetButtonDown("StartButton")) {
                // ToggleActivation();
            }
        }

        public void ToggleActivation() {
            if (Active)
                Deactivate();
            else
                Activate();
        }

        void Activate() {
            Active = true;

            //if (DefaultButton)
            //    DefaultButton.Select();

            //MouseHider.instance.SetForceShow(true);

            //Player.player.InMenu = true;
            Time.timeScale = 0;
            //canvasGroup.alpha = 1;
            //canvasGroup.interactable = true;
            //canvasGroup.blocksRaycasts = true;
            //BossMusic.instance.PauseMusic();
        }

        void Deactivate() {
            Active = false;

            //MouseHider.instance.SetForceShow(false);

            Player.player.InMenu = false;
            Time.timeScale = 1;
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            BossMusic.instance.ResumeMusic();
        }

        void OnDisable() {
            Time.timeScale = 1;
        }
    }
}