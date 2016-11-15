using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class FSSkillCharge : FSSkillBase {
        [Header("Charge")]
        public AnimationCurve channelingSpeedCurve = new AnimationCurve();
        public AnimationCurve recoveringSpeedCurve = new AnimationCurve();
        public GameObject startEffect;
        public GameObject speedEffect;
        public GameObject collisionObject;
        GameObject startEffectInstance;
        GameObject m_speedEffectInstance;
        GameObject m_collisionObjectInstance;
        float ForceTime = 0.15f;
        Timer forceTimer = new Timer();

        public override void RecoverStart() {
            //if (PlayerMovement.instance)
            //    PlayerMovement.instance.forceDirection(PlayerMovement.instance.transform.forward);

            //Player.player.playerStats.Add_Modifier("Charge_Recover_MS", "movement_speed", 0, recoveringSpeedCurve.Evaluate(1 - FSSkillUser.m_recoverTimer.PercentComplete()));
        }

        public override void RecoverUpdate() {
            //if (Player.player)
            //{
            //    Player.player.playerStats.Remove_Modifier("Charge_Recover_MS");
            //    Player.player.playerStats.Add_Modifier("Charge_Recover_MS", "movement_speed", 0, recoveringSpeedCurve.Evaluate(1 - FSSkillUser.m_recoverTimer.PercentComplete()));
            //}
        }

        public override void RecoverEnd() {
            //if (PlayerMovement.instance)
            //    PlayerMovement.instance.forceDirection(Vector3.zero);

            //if (Evade.instance)
            //    Evade.instance.RemoveEvadeBlock("skill_charge");

            //Player.player.playerStats.Remove_Modifier("Charge_Recover_MS");
        }

        public override void ChannelStart() {
            if (Evade.instance) {
                Evade.instance.CancelEvade();
                Evade.instance.AddEvadeBlock("skill_charge");
            }

            if (PlayerMovement.instance)
                PlayerMovement.instance.forceDirection(PlayerMovement.instance.transform.forward);

            Player.player.playerStats.Add_Modifier("Charge_MS", "movement_speed", 0, channelingSpeedCurve.Evaluate(FSSkillUser.m_channelTimer.Progress()));

            SpawnStartEffect();
            SpawnCollisionObject();
            SpawnSpeedEffect();
            SetPlayerCollisionWithAllEnemies(false);
        }

        void SpawnStartEffect() {
            if (startEffect && startEffectInstance == null) {
                startEffectInstance = (GameObject)Instantiate(startEffect, Player.player.transform.position, Player.player.transform.rotation);
                startEffectInstance.transform.SetParent(Player.player.transform);
                startEffectInstance.transform.localPosition = startEffect.transform.position;
                startEffectInstance.transform.localRotation = startEffect.transform.rotation;
            }
        }

        void SpawnCollisionObject() {
            if (collisionObject) {
                m_collisionObjectInstance = (GameObject)Instantiate(collisionObject,
                    Player.player.transform.position + Vector3.up * 1.5f,
                    Player.player.transform.rotation * collisionObject.transform.rotation);
                m_collisionObjectInstance.transform.SetParent(Player.player.transform);
                m_collisionObjectInstance.GetComponent<FSObjectCharge>().PhysicalDamagePercentage = PhysicalDamagePercentage;
            }
        }

        void SpawnSpeedEffect() {
            if (speedEffect) {
                m_speedEffectInstance = (GameObject)Instantiate(speedEffect,
                    CameraController.instance.transform.position + CameraController.instance.transform.forward * 3,
                    CameraController.instance.transform.rotation * speedEffect.transform.rotation);
                m_speedEffectInstance.transform.SetParent(CameraController.instance.transform);
            }
        }

        public override void ChannelUpdate() {
            float curveEvaluation = channelingSpeedCurve.Evaluate(FSSkillUser.m_channelTimer.Progress());

            PlayerMovement.instance.RemoveMoveBlock("attack");

            Player.player.playerStats.Remove_Modifier("Charge_MS");
            Player.player.playerStats.Add_Modifier("Charge_MS", "movement_speed", 0, curveEvaluation);

            var rumble = CameraEffectManager.Instance.Create<Rumble>();
            rumble._speed = curveEvaluation * 2;
            rumble._Size = curveEvaluation * 20;
            rumble.Play();

            forceTimer.Update();
            if (forceTimer.IsFinished) {
                forceTimer.Start(ForceTime);
                ForcePusher.instance.SendForceFromObject(Player.player.gameObject, new Vector3(25, 0, 0), 0.1f, ForcePusher.Shape.Box, new Vector3(1f, 1f, 1f), new Vector3(0, 0.65f, 0), true);
            }
        }

        public override void ChannelEnd() {
            Player.player.playerStats.Remove_Modifier("Charge_MS");
            if (m_speedEffectInstance) {
                m_speedEffectInstance.transform.SetParent(null);
                m_speedEffectInstance = null;
            }

            if (m_collisionObjectInstance) {
                m_collisionObjectInstance.transform.SetParent(null);
                Destroy(m_collisionObjectInstance);
            }

            SetPlayerCollisionWithAllEnemies(true);

            if (PlayerMovement.instance)
                PlayerMovement.instance.forceDirection(Vector3.zero);

            if (Evade.instance)
                Evade.instance.RemoveEvadeBlock("skill_charge");

            Player.player.playerStats.Remove_Modifier("Charge_Recover_MS");

            //Destroy(startEffectInstance);
            startEffectInstance = null;
        }

        public override void ApplySkillEffect() {

        }

        public override void SkillEnd() {
            //Destroy(startEffectInstance);
            //startEffectInstance = null;
        }

        void SetPlayerCollisionWithAllEnemies(bool p_state) {
            foreach (Enemy_Base en in Enemy_List.Enemies) {
                foreach (Collider col in en.GetComponentsInChildren<Collider>()) {
                    CollisionIgnoranceManager.SetCollisionBetweenPlayerAndChosenCollider(col, p_state);
                }
            }
        }
    }
}