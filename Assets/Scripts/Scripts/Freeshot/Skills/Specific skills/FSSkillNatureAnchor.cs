using UnityEngine;
using System.Collections;
using System;

namespace Tamarrion {
    public class FSSkillNatureAnchor : FSSkillArea {
        [Header("Nature Anchor")]
        public float ArrowMinDistance = 2f;
        public GameObject anchorObjectPrefab;
        public GameObject teleportEffect;
        public GameObject playerSwirlEffect;
        public GameObject arrowToTargetPrefab;
        GameObject anchorObjectInstance;
        GameObject arrowToTargetInstance;
        GameObject playerSwirlEffectInstance;
        bool noPlacementDefault;
        float cooldownDefault;
        int tributeBase;
        bool arrowVisible = false;

        int currentSecondDuration;
        TopgunTimer secondDurationTimer = new TopgunTimer();

        void Start() {
            noPlacementDefault = noPlacement;
            cooldownDefault = cooldown;
            cooldown = 0;
            currentSecondDuration = (int)duration;
            tributeBase = TributeGainNature;
        }

        public override void ApplySkillEffect() {
            if (anchorObjectPrefab && !anchorObjectInstance && duration >= 1f) {
                SpawnAnchor();
                ActivatePlayerSwirlEffect();
                SetVariablesToTeleportState();
                ResetSecondsTimerAndDisplayDuration();
            }
            else if (anchorObjectInstance) {
                TeleportToAnchor();
                RemovePlayerSwirlEffect();
                SpawnTeleportEffect();
                RemoveAnchor();
                SetVariablesToPlacementState();
            }
        }

        void ActivatePlayerSwirlEffect() {
            if (playerSwirlEffect && !playerSwirlEffectInstance) {
                playerSwirlEffectInstance = (GameObject)Instantiate(playerSwirlEffect, Player.player.transform.position + playerSwirlEffect.transform.position, playerSwirlEffect.transform.rotation);
                playerSwirlEffectInstance.transform.SetParent(Player.player.transform);
            }
        }

        void RemovePlayerSwirlEffect() {
            if (playerSwirlEffectInstance == null)
                return;

            Destroy(playerSwirlEffectInstance);
            playerSwirlEffectInstance = null;
        }

        void SetVariablesToPlacementState() {
            noPlacement = noPlacementDefault;
            cooldown = 0;
            currentSecondDuration = 0;
            TributeGainNature = 0;
        }

        void SetVariablesToTeleportState() {
            noPlacement = true;
            cooldown = cooldownDefault;
            currentSecondDuration = (int)duration;
            TributeGainNature = tributeBase;
        }

        void ResetSecondsTimerAndDisplayDuration() {
            secondDurationTimer.StartTimerBySeconds(1f);
            ErrorBar.instance.SpawnText(currentSecondDuration.ToString(), FSSkillManager.instance.ColorNature);
        }

        void Update() {
            if (anchorObjectInstance) {
                ArrowRangeCheck();

                secondDurationTimer.Update();
                if (secondDurationTimer.IsComplete) {
                    --currentSecondDuration;
                    if (currentSecondDuration == 0) {
                        RemoveAnchor();
                        RemovePlayerSwirlEffect();
                        SetVariablesToPlacementState();
                    }
                    else {
                        ResetSecondsTimerAndDisplayDuration();
                    }
                }
            }
        }

        void ArrowRangeCheck() {
            if (arrowVisible && (Player.player.transform.position - anchorObjectInstance.transform.position).magnitude < ArrowMinDistance) {
                arrowVisible = false;

                arrowToTargetInstance.GetComponent<ProjectorFacingPoint>().TurnOff();
            }
            else if (!arrowVisible && (Player.player.transform.position - anchorObjectInstance.transform.position).magnitude >= ArrowMinDistance) {
                arrowVisible = true;

                arrowToTargetInstance.GetComponent<ProjectorFacingPoint>().TurnOn();
            }
        }

        void TeleportToAnchor() {
            Player.player.transform.position = anchorObjectInstance.transform.position;
        }

        void SpawnTeleportEffect() {
            if (teleportEffect)
                Instantiate(teleportEffect, Player.player.transform.position + teleportEffect.transform.position, teleportEffect.transform.rotation);
        }

        void SpawnAnchor() {
            anchorObjectInstance = (GameObject)Instantiate(anchorObjectPrefab, spawnPosition, spawnRotation);
            arrowToTargetInstance = (GameObject)Instantiate(arrowToTargetPrefab, Vector3.zero, arrowToTargetPrefab.transform.rotation);
            arrowToTargetInstance.transform.SetParent(Player.player.transform);
            arrowToTargetInstance.GetComponent<ProjectorFacingPoint>().targetPoint = anchorObjectInstance.transform.position;
            arrowVisible = false;
        }

        void RemoveAnchor() {
            Destroy(anchorObjectInstance);
            anchorObjectInstance = null;

            Destroy(arrowToTargetInstance);
            arrowToTargetInstance = null;
        }

        public override void SkillEnd() {

        }
    }
}