using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Tamarrion {
    public class SceneChangeButton : MonoBehaviour {
        public string SceneName = "";
        public bool ReloadSame = false;

        void Start() {
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => { ChangeScene(); });
        }

        void ChangeScene() {
            GodManager.Instance.deactivate_current_god();
            if (GetComponent<UnityEngine.UI.Button>())
                GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();

            if (!ReloadSame)
                Application.LoadLevelAsync(SceneName);
            else
                Application.LoadLevelAsync(Application.loadedLevelName);
        }
    }
}