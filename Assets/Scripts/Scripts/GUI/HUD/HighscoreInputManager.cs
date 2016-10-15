using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
    public class HighscoreInputManager : MonoBehaviour {
        public static HighscoreInputManager instance;
        public Color SelectedColor = new Color();
        public Color UnselectedColor = new Color();
        public List<GameObject> LetterObjects = new List<GameObject>();
        public int CurrentIndexSelection;
        public CanvasGroup VictoryScreen;
        public Button DefaultButton;

        private CanvasGroup HighscoreCanvas;
        private bool nameGiven = false;

        void Awake() {
            instance = this;
        }

        void Start() {
            foreach (GameObject obj in LetterObjects) {
                obj.GetComponentInChildren<RawImage>().color = UnselectedColor;
            }
            if (LetterObjects.Count > 0)
                LetterObjects[0].GetComponentInChildren<RawImage>().color = SelectedColor;

            HighscoreCanvas = gameObject.GetComponent<CanvasGroup>();
            DeactivateMenuCanvas();
        }

        void Update() {

        }

        public void SetLetter(int p_index, string p_string, bool p_incrementSelected = true) {
            // Debug.Log("setting letter " + p_index + " to " + p_string);
            if (p_index < 0 || p_index > LetterObjects.Count - 1)
                return;

            LetterObjects[p_index].GetComponent<Text>().text = p_string;

            if (p_incrementSelected)
                SelectNext();
        }
        public void SetLetter(string p_string, bool p_incrementSelected = true) {
            SetLetter(CurrentIndexSelection, p_string, p_incrementSelected);
        }

        public void EraseCurrentSelection() {
            if (CurrentIndexSelection < 0 || CurrentIndexSelection > LetterObjects.Count - 1)
                return;

            LetterObjects[CurrentIndexSelection].GetComponent<Text>().text = "";

            if (CurrentIndexSelection > 0)
                SelectPrevious();
        }

        public void SelectNext() {
            if (CurrentIndexSelection >= LetterObjects.Count - 1)
                return;

            LetterObjects[CurrentIndexSelection].GetComponentInChildren<RawImage>().color = UnselectedColor;
            ++CurrentIndexSelection;
            LetterObjects[CurrentIndexSelection].GetComponentInChildren<RawImage>().color = SelectedColor;
        }

        public void SelectPrevious() {
            if (CurrentIndexSelection <= 0)
                return;

            LetterObjects[CurrentIndexSelection].GetComponentInChildren<RawImage>().color = UnselectedColor;
            --CurrentIndexSelection;
            LetterObjects[CurrentIndexSelection].GetComponentInChildren<RawImage>().color = SelectedColor;
        }

        public string GetName() {
            nameGiven = true;
            string ret = "";
            foreach (GameObject obj in LetterObjects) {
                ret += obj.GetComponent<Text>().text;
            }

            return ret;
        }

        public bool NameGiven() {
            return nameGiven;
        }

        public void OnHighscoreRegister() {
            FightStatsScreen.Instance.SendHighscore();
        }

        void ActivateVictoryScreen() {
            VictoryScreen.interactable = true;
            VictoryScreen.blocksRaycasts = true;
        }

        void DeactivateVictoryScreen() {
            VictoryScreen.interactable = false;
            VictoryScreen.blocksRaycasts = false;
        }

        public void ActivateMenuCanvas() {
            if (DefaultButton)
                DefaultButton.Select();
            HighscoreCanvas.alpha = 1;
            HighscoreCanvas.interactable = true;
            HighscoreCanvas.blocksRaycasts = true;
            DeactivateVictoryScreen();
        }

        public void DeactivateMenuCanvas() {
            HighscoreCanvas.alpha = 0;
            HighscoreCanvas.interactable = false;
            HighscoreCanvas.blocksRaycasts = false;
            ActivateVictoryScreen();
        }
    }
}