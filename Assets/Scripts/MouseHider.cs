using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class MouseHider : MyMonoBehaviour {
        public Texture2D CursorTexture;
        public Vector2 Offset = new Vector2(0, 0);
        private bool showCursor;

        private void Start() {
            HideCursor();
            AddListener<IngameMenuOpenEvent>(OnIngameMenuOpen);
            AddListener<IngameMenuCloseEvent>(OnIngameMenuClose);
        }

        void OnDestroy() {
            RemoveListener<IngameMenuOpenEvent>(OnIngameMenuOpen);
            RemoveListener<IngameMenuCloseEvent>(OnIngameMenuClose);
        }

        private void OnIngameMenuOpen(IngameMenuOpenEvent e) {
            ShowCursor();
        }

        private void OnIngameMenuClose(IngameMenuCloseEvent e) {
            HideCursor();
        }

        void Update() {
            if (Application.isEditor) {
                if (!showCursor) {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }

        private void ShowCursor() {
            if (CursorTexture)
                Cursor.SetCursor(CursorTexture, Offset, CursorMode.Auto);

            showCursor = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        private void HideCursor() {
            if (CursorTexture)
                Cursor.SetCursor(null, Offset, CursorMode.Auto);

            showCursor = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
