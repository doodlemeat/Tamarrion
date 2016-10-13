using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class God_Base : MyMonoBehaviour {
        public FSSkillElement element;
        public float Time = 10.0f;
        public string Name = "Unnamed God";
        public AudioClip _sound;
        public GameObject godPowerActivationEffect;
        public GameObject godPowerPersistantEffect;
        public float secondsBeforeDecayStart;
        public float decayAmountPerSecond;
        GameObject godPowerPersistantEffectInstance;

        protected virtual void Start() {
            if (PlayerAnimationEventHandler.Instance && _sound)
                PlayerAnimationEventHandler.Instance.OnGodActive(_sound);

            if (godPowerActivationEffect) {
                GameObject effectInstance = (GameObject)Instantiate(godPowerActivationEffect, Player.player.transform.position, godPowerActivationEffect.transform.rotation);
                effectInstance.transform.SetParent(Player.player.transform);
                effectInstance.transform.localPosition = godPowerActivationEffect.transform.position;
                if (effectInstance.GetComponent<ParticleSystem>())
                    effectInstance.GetComponent<ParticleSystem>().startColor = FSSkillManager.instance.GetColorByElement(element);
            }
            if (godPowerPersistantEffect) {
                godPowerPersistantEffectInstance = (GameObject)Instantiate(godPowerPersistantEffect, Player.player.transform.position, godPowerPersistantEffect.transform.rotation);
                godPowerPersistantEffectInstance.transform.SetParent(Player.player.transform);
                godPowerPersistantEffectInstance.transform.localPosition = godPowerPersistantEffect.transform.position;
            }

            if (GodPowerPlayerBodyMaterial.instance) {
                GodPowerPlayerBodyMaterial.instance.SetMaterialColor("_EmissiveRimColor", FSSkillManager.instance.GetColorByElement(element));
                GodPowerPlayerBodyMaterial.instance.SetMaterialFloat("_EmissiveRimPower", 5f);
            }
        }

        protected virtual void Update() {
        }

        public virtual void Deactivate() {
            if (godPowerPersistantEffectInstance) {
                Destroy(godPowerPersistantEffectInstance);
                godPowerPersistantEffectInstance = null;
            }

            if (GodPowerPlayerBodyMaterial.instance) {
                GodPowerPlayerBodyMaterial.instance.SetMaterialFloat("_EmissiveRimPower", 0f);
            }
        }

        public virtual string ThreeWordDescription() {
            return "Gives stuff";
        }
        public virtual string GodName() {
            return "Some name";
        }
        public virtual string ActiveEffectName() {
            return "Effect name";
        }
    }
}