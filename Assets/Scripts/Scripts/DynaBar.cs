using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Tamarrion {
    public class DynaBar : MonoBehaviour {
        public float TargetScale = 1.0f;
        public float CurrentScale = 1.0f;
        public float FallSpeed = 0.1f;
        RawImage DynBar;
        HPRect HPScaleScript;

        void Start() {
            DynBar = GetComponent<RawImage>();
            HPScaleScript = transform.parent.GetComponentInChildren<HPRect>();

            if (DynBar == null) {
                Debug.LogError("Failed to find component RawImage");
                gameObject.SetActive(false);
            }

            if (HPScaleScript == null) {
                Debug.LogError("Failed to find component of type " + HPScaleScript.GetType() + ". Object with " + GetType() + " must lay beside object with " + HPScaleScript.GetType());
                gameObject.SetActive(false);
            }

            UpdateCurrentScale();
            UpdateTargetScale();
        }

        void Update() {
            UpdateCurrentScale();
            UpdateTargetScale();

            float Diff = CurrentScale - TargetScale;
            if (Diff > 0.0f) {
                CurrentScale -= FallSpeed * Time.deltaTime;
                if (CurrentScale <= TargetScale) {
                    CurrentScale = TargetScale;
                }
            }

            UpdateDynBar();
        }

        void UpdateCurrentScale() {
            CurrentScale = DynBar.rectTransform.localScale.x;
        }

        void UpdateTargetScale() {
            TargetScale = HPScaleScript.CurrentPercent;
        }

        void UpdateDynBar() {
            DynBar.rectTransform.localScale = new Vector3(CurrentScale, 1, 1);
        }
    }
}