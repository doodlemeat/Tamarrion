﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
    public class FSSkillUser : MonoBehaviour {
        public static FSSkillUser instance;

        public Player player;
        public PlayerMovement playerMovement;
        public Animator playerAnimator;
        public CameraController cameraController;
        public Projector m_skillProjector;
        public Projector m_chargeProjector;

        public static List<GameObject> m_enemyList;

        static public Timer m_castingTimer = new Timer();
        static public Timer m_performTimer = new Timer();
        static public Timer m_recoverTimer = new Timer();
        static public Timer m_channelTimer = new Timer();

        FSSkillBase m_currentSkill;

        FSSkillPlacing currentPlacingMethod = FSSkillPlacing.FS_Placing_FromPlayer;
        public float fromPlayerRange = 2.5f;
        static bool m_SkillInUse = false;
        Vector3 m_castingStartPosition;

        public List<string> skillBlockers = new List<string>();

        void Awake() {
            instance = this;
        }

        void Start() {
            HideSkillShape();
        }

        void Update() {
            UpdateInputs();
            UpdateCurrentSkill();

            if (m_currentSkill != null
                && SkillStateShouldShowProjector(m_currentSkill.GetCurrentState())
                && currentPlacingMethod == FSSkillPlacing.FS_Placing_FreePlace) {
                UpdatePositionToPlacing();
            }
        }

        void UpdateInputs() {
            if (SkillUserEnabled()) {
                if (Input.GetButtonDown("Spell 1"))
                    SetCurrentSkill(SkillManager.GetSkillInSlot(0));
                else if (Input.GetButtonDown("Spell 2"))
                    SetCurrentSkill(SkillManager.GetSkillInSlot(1));
                else if (Input.GetButtonDown("Spell 3"))
                    SetCurrentSkill(SkillManager.GetSkillInSlot(2));
                else if (Input.GetButtonDown("Spell 4"))
                    SetCurrentSkill(SkillManager.GetSkillInSlot(3));
                else if (Input.GetButtonDown("Spell 5"))
                    SetCurrentSkill(SkillManager.GetSkillInSlot(4));

                if (Input.GetButtonDown("Attack")) {
                    if (m_currentSkill != null && m_currentSkill.GetCurrentState() == FSSkillStates.FS_State_Inactive)
                        StartCastingSkill();
                }

                if (Input.GetButtonDown("Cancel Spell") && CurrentSkillIsActive()) {
                    TryToCancelCurrentSpell();
                }
            }
        }

        void TryToCancelCurrentSpell() {
            if (!m_currentSkill)
                return;

            if (m_currentSkill.GetCurrentState() == FSSkillStates.FS_State_Inactive || m_currentSkill.GetCurrentState() == FSSkillStates.FS_State_Casting)
                CancelCurrentSkill();
            else if (m_currentSkill.CanBeCanceled && m_currentSkill.GetCurrentState() == FSSkillStates.FS_State_Channeling)
                m_channelTimer.Finish();
        }

        void UpdateCurrentSkill() {
            if (m_currentSkill == null)
                return;

            if (m_currentSkill.GetCurrentState() == FSSkillStates.FS_State_Casting) {
                if (m_currentSkill.CastTime > 0 && m_currentSkill.CastCancelOnMove && (player.transform.position - m_castingStartPosition).magnitude > 0.1f) {
                    if (ErrorBar.instance)
                        ErrorBar.instance.SpawnText("Must stand still");
                    m_castingTimer.Finish();
                    CancelCurrentSkill();
                    return;
                }

                m_castingTimer.Update();
                if (m_castingTimer.IsFinished) {
                    FinishCastingSkill();
                    m_currentSkill.AdvanceState();
                    StartPerformingSkill();
                }
            }
            if (m_currentSkill.GetCurrentState() == FSSkillStates.FS_State_Perform) {
                m_currentSkill.PerformUpdate();
                m_performTimer.Update();
                if (m_performTimer.IsFinished) {
                    FinishPerformingSkill();
                    if (m_currentSkill.isChanneling)
                        StartChannelingSkill();
                    else
                        StartRecoveringFromSkill();
                }
            }
            if (m_currentSkill.GetCurrentState() == FSSkillStates.FS_State_Channeling) {
                m_currentSkill.ChannelUpdate();
                m_channelTimer.Update();
                if (m_channelTimer.IsFinished) {
                    FinishChannelingSkill();
                    StartRecoveringFromSkill();
                }
            }
            if (m_currentSkill.GetCurrentState() == FSSkillStates.FS_State_Recover) {
                m_currentSkill.RecoverUpdate();
                m_recoverTimer.Update();
                if (m_recoverTimer.IsFinished) {
                    FinishRecoveringSkill();
                }
            }
        }

        bool SkillStateShouldShowProjector(FSSkillStates p_state) {
            return (p_state == FSSkillStates.FS_State_Inactive || p_state == FSSkillStates.FS_State_Casting || p_state == FSSkillStates.FS_State_Perform);
        }

        public void CancelCurrentSkill() {
            HideSkillShape();
            player.playerStats.Remove_Modifier("freeshot_casting_ms");
            player.playerStats.Remove_Modifier("freeshot_perform_ms");
            player.playerStats.Remove_Modifier("freeshot_recover_ms");
            playerMovement.RemoveMoveBlock("freeshot");
            playerMovement.RemoveRotationBlock("freeshot");
            if (m_currentSkill) {
                m_currentSkill.ResetStateToInactive();
                if (m_currentSkill.HasCastLoopAnimationName())
                    playerAnimator.SetBool(m_currentSkill.CastLoopAnimationName, false);
            }
            m_currentSkill = null;
            m_SkillInUse = false;
        }

        void SetCurrentSkill(FSSkillBase p_skill) {
            Debug.Log("FSSkillUser:SetCurrentSkill");

            if (p_skill == null || p_skill == m_currentSkill)
                return;

            if (!p_skill.cooldownTimer.IsComplete) {
                if (ErrorBar.instance)
                    ErrorBar.instance.SpawnText("Cooldown active");

                return;
            }

            if (m_currentSkill && m_currentSkill.GetCurrentState() != FSSkillStates.FS_State_Casting && m_currentSkill.GetCurrentState() != FSSkillStates.FS_State_Inactive) {
                return;
            }

            //TO-DO: code queueing of skills instead of cancelling
            CancelCurrentSkill();

            m_currentSkill = p_skill;
            m_SkillInUse = true;
            ResetCurrentSkill();

            if (m_currentSkill.noPlacement)
                StartCastingSkill();
        }

        public static bool CurrentSkillIsActive() {
            return m_SkillInUse;
        }

        void StartCastingSkill() {
            m_currentSkill.SetState(FSSkillStates.FS_State_Casting);

            if (!m_currentSkill.noPlacement)
                // FIXME PlayerCombat.instance.DisableAttackNextFrame();

            if (m_currentSkill.HasCastAnimationName())
                playerAnimator.SetBool(m_currentSkill.CastAnimationName, true);

            if (m_currentSkill.CastTime > 0) {
                m_castingTimer.Start(m_currentSkill.CastTime);
                m_castingStartPosition = player.transform.position;
                if (m_currentSkill.CastCanMove == false)
                    playerMovement.AddMoveBlock("freeshot");
                if (m_currentSkill.CastCanRotate == false)
                    playerMovement.AddRotationBlock("freeshot");
                player.playerStats.Add_Modifier("freeshot_casting_ms", "movement_speed", 0, m_currentSkill.CastMovespeedMod);
                if (m_currentSkill.HasCastLoopAnimationName())
                    playerAnimator.SetBool(m_currentSkill.CastLoopAnimationName, true);
                PlayerCastbar.castbar.OnSpellcast(m_currentSkill);
            }
            else {
                m_castingTimer.Finish();
                if (m_currentSkill.HasFinishAnimationName())
                    playerAnimator.SetBool(m_currentSkill.FinishAnimationName, true);
            }
        }

        void FinishCastingSkill() {
            if (m_currentSkill.HasCastLoopAnimationName())
                playerAnimator.SetBool(m_currentSkill.CastLoopAnimationName, false);

            if (m_currentSkill.HasFinishAnimationName())
                playerAnimator.SetBool(m_currentSkill.FinishAnimationName, true);

            player.playerStats.Remove_Modifier("freeshot_casting_ms");
            playerMovement.RemoveMoveBlock("freeshot");
            playerMovement.RemoveRotationBlock("freeshot");
            m_currentSkill.cooldownTimer.StartTimerBySeconds(m_currentSkill.cooldown);
        }

        void StartPerformingSkill() {
            if (m_currentSkill.HasPerformAnimationName())
                playerAnimator.SetBool(m_currentSkill.PerformAnimationName, true);

            if (m_currentSkill.PerformTime > 0) {
                m_performTimer.Start(m_currentSkill.PerformTime);
                if (m_currentSkill.PerformCanMove == false)
                    playerMovement.AddMoveBlock("freeshot");
                if (m_currentSkill.PerformCanRotate == false)
                    playerMovement.AddRotationBlock("freeshot");
                player.playerStats.Add_Modifier("freeshot_perform_ms", "movement_speed", 0, m_currentSkill.PerformMovespeedMod);
            }
            else
                m_performTimer.Finish();

            m_currentSkill.PerformStart();
        }

        void FinishPerformingSkill() {
            if (m_currentSkill.HasPerformAnimationName())
                playerAnimator.SetBool(m_currentSkill.PerformAnimationName, false);

            if (m_currentSkill.type == FSSkillType.FS_Type_Area) {
                FSSkillArea areaSkill = (FSSkillArea)m_currentSkill;
                areaSkill.SetSpawnPosition(m_skillProjector.transform.position + (m_skillProjector.transform.forward * (m_skillProjector.farClipPlane * 0.5f)));
                areaSkill.SetSpawnRotation(m_skillProjector.transform.rotation * Quaternion.Euler(new Vector3(-90, 0, 0)));
            }
            //add projectile spawn
            m_currentSkill.ApplySkillEffect();
            player.playerStats.Remove_Modifier("freeshot_perform_ms");
            playerMovement.RemoveMoveBlock("freeshot");
            playerMovement.RemoveRotationBlock("freeshot");
            HideSkillShape();

            m_currentSkill.PerformEnd();
        }

        void StartChannelingSkill() {
            PlayerCastbar.castbar.OnSpellcast(m_currentSkill, PlayerCastbar.CastState.Channel);

            m_currentSkill.SetState(FSSkillStates.FS_State_Channeling);

            if (m_currentSkill.HasChannelingAnimationName())
                playerAnimator.SetBool(m_currentSkill.ChannelingAnimationName, true);

            m_channelTimer.Start(m_currentSkill.ChannelingTime);
            if (m_currentSkill.ChannelingCanMove == false)
                playerMovement.AddMoveBlock("freeshot");
            if (m_currentSkill.ChannelingCanRotate == false)
                playerMovement.AddRotationBlock("freeshot");
            player.playerStats.Add_Modifier("freeshot_perform_ms", "movement_speed", 0, m_currentSkill.ChannelingMovespeedMod);

            m_currentSkill.ChannelStart();
        }

        void FinishChannelingSkill() {
            m_currentSkill.ChannelEnd();

            if (m_currentSkill.HasChannelingAnimationName())
                playerAnimator.SetBool(m_currentSkill.ChannelingAnimationName, false);

            player.playerStats.Remove_Modifier("freeshot_perform_ms");
            playerMovement.RemoveMoveBlock("freeshot");
            playerMovement.RemoveRotationBlock("freeshot");
        }

        void StartRecoveringFromSkill() {
            m_currentSkill.SetState(FSSkillStates.FS_State_Recover);
            player.playerStats.Remove_Modifier("freeshot_perform_ms");

            if (m_currentSkill.HasRecoverAnimationName())
                playerAnimator.SetBool(m_currentSkill.RecoverAnimationName, true);

            if (m_currentSkill.RecoverTime > 0) {
                m_recoverTimer.Start(m_currentSkill.RecoverTime);
                if (m_currentSkill.RecoverCanMove == false)
                    playerMovement.AddMoveBlock("freeshot");
                if (m_currentSkill.RecoverCanRotate == false)
                    playerMovement.AddRotationBlock("freeshot");
                player.playerStats.Add_Modifier("freeshot_recover_ms", "movement_speed", 0, m_currentSkill.RecoverMovespeedMod);
            }
            else
                m_recoverTimer.Finish();

            m_currentSkill.RecoverStart();
        }

        void FinishRecoveringSkill() {
            m_currentSkill.RecoverEnd();

            if (m_currentSkill.HasRecoverAnimationName())
                playerAnimator.SetBool(m_currentSkill.RecoverAnimationName, false);

            player.playerStats.Remove_Modifier("freeshot_recover_ms");
            playerMovement.RemoveMoveBlock("freeshot");
            playerMovement.RemoveRotationBlock("freeshot");
            CompleteCurrentSkill();
        }

        void CompleteCurrentSkill() {
            for (int i = 0; i < (int)FSSkillElement.FS_Elem_Count; ++i) {
                int TempTributeGain = m_currentSkill.GetTributeGainByElement((FSSkillElement)i);

                if (TempTributeGain > 0) {
                    GodManager.Instance.AddTribute((FSSkillElement)i, TempTributeGain);
                }
            }

            GodManager.Instance.RemoveTribute(m_currentSkill.element, m_currentSkill.removeAmountGPPOnUse);

            if (m_currentSkill.removeAllGPPOnUse) {
                GodManager.Instance.RemoveAllTribute(m_currentSkill.element);
            }

            m_currentSkill.SkillEnd();
            playerMovement.RemoveMoveBlock("freeshot");
            playerMovement.RemoveRotationBlock("freeshot");
            CancelCurrentSkill();
        }

        void ResetCurrentSkill() {
            m_currentSkill.SetState(FSSkillStates.FS_State_Inactive);
            SetNewSkillShape();
            ShowSkillShape();
            UpdatePositionToPlacing();
        }

        void SetNewSkillShape() {
            m_skillProjector.orthographic = true;
            m_skillProjector.aspectRatio = (float)m_currentSkill.shapeTexture.width / (float)m_currentSkill.shapeTexture.height;
            m_skillProjector.orthographicSize = m_currentSkill.shapeSize * 0.5f;
			m_skillProjector.material.SetColor ("_Color", m_currentSkill.Element.Color);
            m_skillProjector.material.SetTexture("_ShadowTex", m_currentSkill.shapeTexture);
            currentPlacingMethod = m_currentSkill.placing;
        }

        void ShowSkillShape() {
            m_skillProjector.gameObject.SetActive(true);
        }

        void HideSkillShape() {
            m_skillProjector.gameObject.SetActive(false);
        }

        public static void AddEnemyToTargetList(GameObject p_enemy) {
            m_enemyList.Add(p_enemy);
        }

        float GetClosestDistanceToShapeCenter() {
            if (m_currentSkill != null)
                return fromPlayerRange + m_currentSkill.shapeSize * 0.5f;

            return fromPlayerRange;
        }

        void UpdatePositionToPlacing() {
            if (currentPlacingMethod == FSSkillPlacing.FS_Placing_FreePlace)
                DetermineFreeplaceTargetPosition();
            else if (currentPlacingMethod == FSSkillPlacing.FS_Placing_FromPlayer) {
                m_skillProjector.transform.localRotation = (Quaternion.Euler(90, 0, 0));
                m_skillProjector.transform.localPosition = (Vector3.up * (m_skillProjector.farClipPlane * 0.5f)) + new Vector3(0, 0, GetClosestDistanceToShapeCenter());
            }
            else if (currentPlacingMethod == FSSkillPlacing.FS_Placing_PlayerIsCenter) {
                m_skillProjector.transform.localRotation = (Quaternion.Euler(90, 0, 0));
                m_skillProjector.transform.localPosition = (Vector3.up * (m_skillProjector.farClipPlane * 0.5f));
            }
        }

        void DetermineFreeplaceTargetPosition() {
            if (SetProjectionViaRaycast(player.transform.position + new Vector3(0, 1, 0), cameraController.transform.forward, m_currentSkill.range)) {
                ShowSkillShape();
            }
            else if (SetProjectionViaRaycast(player.transform.position + new Vector3(0, 1, 0) + cameraController.transform.forward * m_currentSkill.range, Vector3.down, 30.0f)) {
                ShowSkillShape();
            }
            else {
                HideSkillShape();
            }
        }

        //- returns success
        bool SetProjectionViaRaycast(Vector3 p_startPos, Vector3 p_direction, float p_maxRange) {
            Ray ray = new Ray(p_startPos, p_direction);
            Debug.DrawRay(p_startPos, p_direction * p_maxRange, Color.cyan, 0.2f);
            RaycastHit[] hitInfo = Physics.RaycastAll(ray, p_maxRange);

            if (hitInfo.Length > 0) {
                float closestDistance = (hitInfo[0].point - (player.transform.position + new Vector3(0, 1, 0))).magnitude;
                foreach (RaycastHit hit in hitInfo) {
                    if (hit.collider.gameObject.tag == "IgnoreFreeshotProjecting")
                        continue;

                    float distanceToHit = (hit.point - p_startPos).magnitude;
                    if (distanceToHit <= closestDistance) {
                        closestDistance = distanceToHit;
                        m_skillProjector.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                        m_skillProjector.transform.position = hit.point + (m_skillProjector.transform.up * (m_skillProjector.farClipPlane * 0.5f));
                        m_skillProjector.transform.rotation = m_skillProjector.transform.rotation * (Quaternion.Euler(90, 0, 0));
                    }
                }
                return true;
            }

            return false;
        }

        public FSSkillBase GetCurrentSkill() {
            return m_currentSkill;
        }

        public void AddSkillBlock(string p_sourceName) {
            if (!skillBlockers.Contains(p_sourceName)) {
                skillBlockers.Add(p_sourceName);
                TryToCancelCurrentSpell();
            }
        }

        public void RemoveSkillBlock(string p_sourceName) {
            skillBlockers.Remove(p_sourceName);
        }

        public bool SkillUserEnabled() {
            return skillBlockers.Count == 0;
        }
    }
}