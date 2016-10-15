using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class HolyShieldEffect : MonoBehaviour {
        public GameObject OverHeadSpriteObject;
        public Material armorMaterial;
        public Material spriteMaterial;
        public float FadeTime = 1.5f;
        public string SpriteMaterialVarName = "_Opacity";
        public string ArmorMaterialVarName = "_ClipAmount";
        public float ArmorMaterialVarTargetValue = 10;

        private float Duration = 0;
        private bool EffectFadeIn = false;
        private bool EffectFadeOut = false;
        private float FadeTimeCurrent;
        private float VisibleOpacity;
        private GameObject SpriteInstance;

        void Start() {
            if (spriteMaterial) {
                VisibleOpacity = spriteMaterial.GetFloat(SpriteMaterialVarName);
            }
            if (armorMaterial) {
                armorMaterial.SetFloat(ArmorMaterialVarName, 0);
            }
        }

        void OnDisable() {
            if (spriteMaterial) {
                spriteMaterial.SetFloat(SpriteMaterialVarName, VisibleOpacity);
            }
        }

        void Update() {
            if (EffectFadeIn && FadeTimeCurrent > 0.001f) {
                FadeTimeCurrent -= Time.deltaTime;
                if (FadeTimeCurrent <= 0) {
                    FadeTimeCurrent = 0;
                    EffectFadeIn = false;
                }
                if (spriteMaterial)
                    spriteMaterial.SetFloat(SpriteMaterialVarName, Mathf.Lerp(0, VisibleOpacity, 1 - (FadeTimeCurrent / FadeTime)));
                if (armorMaterial)
                    armorMaterial.SetFloat(ArmorMaterialVarName, Mathf.Lerp(0, ArmorMaterialVarTargetValue, 1 - (FadeTimeCurrent / FadeTime)));

            }
            else if (EffectFadeOut && FadeTimeCurrent > 0.001f) {
                FadeTimeCurrent -= Time.deltaTime;
                if (FadeTimeCurrent <= 0) {
                    FadeTimeCurrent = 0;
                    Destroy(SpriteInstance);
                    EffectFadeOut = false;
                }
                if (spriteMaterial)
                    spriteMaterial.SetFloat(SpriteMaterialVarName, Mathf.Lerp(0, VisibleOpacity, (FadeTimeCurrent / FadeTime)));
                if (armorMaterial)
                    armorMaterial.SetFloat(ArmorMaterialVarName, Mathf.Lerp(0, ArmorMaterialVarTargetValue, (FadeTimeCurrent / FadeTime)));
            }

            if (Duration > 0) {
                Duration -= Time.deltaTime;
                if (Duration <= 0) {
                    Duration = 0;
                    StopEffect();
                }
            }
        }

        public void StartEffect() {
            FadeTimeCurrent = FadeTime;
            SpriteInstance = (GameObject)Instantiate(OverHeadSpriteObject, Player.player.gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            SpriteInstance.transform.SetParent(Player.player.gameObject.transform);
            EffectFadeIn = true;
            EffectFadeOut = false;
        }

        public void StopEffect() {
            FadeTimeCurrent = FadeTime;
            EffectFadeIn = false;
            EffectFadeOut = true;
        }

        public void SetDuration(float p_duration, bool p_affectedByFade = true) {
            Duration = p_duration;
            if (p_affectedByFade) {
                if (Duration > FadeTime)
                    Duration -= FadeTime;
                else {
                    Duration = 0;
                    StopEffect();
                }
            }
        }
    }
}