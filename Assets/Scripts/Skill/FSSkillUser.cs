using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
    public class FSSkillUser : MonoBehaviour {
        public static FSSkillUser instance;

        public Player player;
        public PlayerMovement playerMovement;
        public Animator playerAnimator;
        public CameraController cameraController;
        public SkillProjector skillProjector;
        public Projector chargeProjector;
        public float fromPlayerRange = 2.5f;
        public List<string> skillBlockers = new List<string>();

        private static List<GameObject> enemyList;

        static public Timer castingTimer = new Timer();
        static public Timer performTimer = new Timer();
        static public Timer recoverTimer = new Timer();
        static public Timer channelTimer = new Timer();

        private FSSkillBase currentSkill;

        private FSSkillPlacing currentPlacingMethod = FSSkillPlacing.FS_Placing_FromPlayer;
        
        private static bool SkillInUse = false;
        private Vector3 castingStartPosition;

        void Awake() {
            instance = this;
        }

        void Start() {
            skillProjector.HideSkillShape();
        }

        void Update() {
            UpdateInputs();
            UpdateCurrentSkill();

            if (currentSkill != null
                && SkillStateShouldShowProjector(currentSkill.GetCurrentState())
                && currentPlacingMethod == FSSkillPlacing.FS_Placing_FreePlace) {
                skillProjector.UpdatePositionToPlacing(currentPlacingMethod, player.gameObject, currentSkill);
            }
        }

        /* 
         * 
         */
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
                    if (currentSkill != null && currentSkill.GetCurrentState() == FSSkillStates.FS_State_Inactive)
                        StartCastingSkill();
                }

                if (Input.GetButtonDown("Cancel Spell") && CurrentSkillIsActive()) {
                    TryToCancelCurrentSpell();
                }
            }
        }

        void TryToCancelCurrentSpell() {
            if (!currentSkill)
                return;

            if (currentSkill.GetCurrentState() == FSSkillStates.FS_State_Inactive || currentSkill.GetCurrentState() == FSSkillStates.FS_State_Casting)
                CancelCurrentSkill();
            else if (currentSkill.CanBeCanceled && currentSkill.GetCurrentState() == FSSkillStates.FS_State_Channeling)
                channelTimer.Finish();
        }

        void UpdateCurrentSkill() {
            if (currentSkill == null)
                return;

            if (currentSkill.GetCurrentState() == FSSkillStates.FS_State_Casting) {
                if (currentSkill.CastTime > 0 && currentSkill.CastCancelOnMove && (player.transform.position - castingStartPosition).magnitude > 0.1f) {
                    if (ErrorBar.instance)
                        ErrorBar.instance.SpawnText("Must stand still");
                    castingTimer.Finish();
                    CancelCurrentSkill();
                    return;
                }

                castingTimer.Update();
                if (castingTimer.IsFinished) {
                    FinishCastingSkill();
                    currentSkill.AdvanceState();
                    StartPerformingSkill();
                }
            }
            if (currentSkill.GetCurrentState() == FSSkillStates.FS_State_Perform) {
                currentSkill.PerformUpdate();
                performTimer.Update();
                if (performTimer.IsFinished) {
                    FinishPerformingSkill();
                    if (currentSkill.isChanneling)
                        StartChannelingSkill();
                    else
                        StartRecoveringFromSkill();
                }
            }
            if (currentSkill.GetCurrentState() == FSSkillStates.FS_State_Channeling) {
                currentSkill.ChannelUpdate();
                channelTimer.Update();
                if (channelTimer.IsFinished) {
                    FinishChannelingSkill();
                    StartRecoveringFromSkill();
                }
            }
            if (currentSkill.GetCurrentState() == FSSkillStates.FS_State_Recover) {
                currentSkill.RecoverUpdate();
                recoverTimer.Update();
                if (recoverTimer.IsFinished) {
                    FinishRecoveringSkill();
                }
            }
        }

        bool SkillStateShouldShowProjector(FSSkillStates p_state) {
            return (p_state == FSSkillStates.FS_State_Inactive || p_state == FSSkillStates.FS_State_Casting || p_state == FSSkillStates.FS_State_Perform);
        }

        public void CancelCurrentSkill() {
            skillProjector.HideSkillShape();
            player.playerStats.Remove_Modifier("freeshot_casting_ms");
            player.playerStats.Remove_Modifier("freeshot_perform_ms");
            player.playerStats.Remove_Modifier("freeshot_recover_ms");
            playerMovement.RemoveMoveBlock("freeshot");
            playerMovement.RemoveRotationBlock("freeshot");
            if (currentSkill) {
                currentSkill.ResetStateToInactive();
                if (currentSkill.HasCastLoopAnimationName())
                    playerAnimator.SetBool(currentSkill.CastLoopAnimationName, false);
            }
            currentSkill = null;
            SkillInUse = false;
        }

        /*
         * 
         */
        void SetCurrentSkill(FSSkillBase p_skill) {
            Debug.Log("FSSkillUser:SetCurrentSkill");

            // If the given skill is null or already our current skill, do nothing
            if (p_skill == null || p_skill == currentSkill)
                return;

            // If the given skill is not off cooldown, show an error and return
            if (!p_skill.cooldownTimer.IsFinished) {
                if (ErrorBar.instance)
                    ErrorBar.instance.SpawnText("Cooldown active");

                return;
            }

            // Only allow cancelling the current skill when it is casting or inactive
            if (currentSkill && currentSkill.GetCurrentState() != FSSkillStates.FS_State_Casting && currentSkill.GetCurrentState() != FSSkillStates.FS_State_Inactive) {
                return;
            }

            //TO-DO: code queueing of skills instead of cancelling

            // Cancel current skill and start casting the new skill
            CancelCurrentSkill();

            currentSkill = p_skill;
            SkillInUse = true;
            ResetCurrentSkill();

            if (currentSkill.noPlacement)
                StartCastingSkill();
        }

        public static bool CurrentSkillIsActive() {
            return SkillInUse;
        }

        void StartCastingSkill() {
            currentSkill.SetState(FSSkillStates.FS_State_Casting);

            if (!currentSkill.noPlacement)
                // FIXME PlayerCombat.instance.DisableAttackNextFrame();

            if (currentSkill.HasCastAnimationName())
                playerAnimator.SetBool(currentSkill.CastAnimationName, true);

            if (currentSkill.CastTime > 0) {
                castingTimer.Start(currentSkill.CastTime);
                castingStartPosition = player.transform.position;
                if (currentSkill.CastCanMove == false)
                    playerMovement.AddMoveBlock("freeshot");
                if (currentSkill.CastCanRotate == false)
                    playerMovement.AddRotationBlock("freeshot");
                player.playerStats.Add_Modifier("freeshot_casting_ms", Property.MovementSpeed, 0, currentSkill.CastMovespeedMod);
                if (currentSkill.HasCastLoopAnimationName())
                    playerAnimator.SetBool(currentSkill.CastLoopAnimationName, true);
                PlayerCastbar.castbar.OnSpellcast(currentSkill);
            }
            else {
                castingTimer.Finish();
                if (currentSkill.HasFinishAnimationName())
                    playerAnimator.SetBool(currentSkill.FinishAnimationName, true);
            }
        }

        void FinishCastingSkill() {
            if (currentSkill.HasCastLoopAnimationName())
                playerAnimator.SetBool(currentSkill.CastLoopAnimationName, false);

            if (currentSkill.HasFinishAnimationName())
                playerAnimator.SetBool(currentSkill.FinishAnimationName, true);

            player.playerStats.Remove_Modifier("freeshot_casting_ms");
            playerMovement.RemoveMoveBlock("freeshot");
            playerMovement.RemoveRotationBlock("freeshot");
            currentSkill.cooldownTimer.Start(currentSkill.cooldown);
        }

        void StartPerformingSkill() {
            if (currentSkill.HasPerformAnimationName())
                playerAnimator.SetBool(currentSkill.PerformAnimationName, true);

            if (currentSkill.PerformTime > 0) {
                performTimer.Start(currentSkill.PerformTime);
                if (currentSkill.PerformCanMove == false)
                    playerMovement.AddMoveBlock("freeshot");
                if (currentSkill.PerformCanRotate == false)
                    playerMovement.AddRotationBlock("freeshot");
                player.playerStats.Add_Modifier("freeshot_perform_ms", Property.MovementSpeed, 0, currentSkill.PerformMovespeedMod);
            }
            else
                performTimer.Finish();

            currentSkill.PerformStart();
        }

        void FinishPerformingSkill() {
            if (currentSkill.HasPerformAnimationName())
                playerAnimator.SetBool(currentSkill.PerformAnimationName, false);

            if (currentSkill.type == FSSkillType.FS_Type_Area) {
                FSSkillArea areaSkill = (FSSkillArea)currentSkill;
                areaSkill.SetSpawnPosition(skillProjector.transform.position + (skillProjector.transform.forward * (skillProjector.GetMaxDistance() * 0.5f)));
                areaSkill.SetSpawnRotation(skillProjector.transform.rotation * Quaternion.Euler(new Vector3(-90, 0, 0)));
            }
            //add projectile spawn
            currentSkill.ApplySkillEffect();
            player.playerStats.Remove_Modifier("freeshot_perform_ms");
            playerMovement.RemoveMoveBlock("freeshot");
            playerMovement.RemoveRotationBlock("freeshot");
            skillProjector.HideSkillShape();

            currentSkill.PerformEnd();
        }

        void StartChannelingSkill() {
            PlayerCastbar.castbar.OnSpellcast(currentSkill, PlayerCastbar.CastState.Channel);

            currentSkill.SetState(FSSkillStates.FS_State_Channeling);

            if (currentSkill.HasChannelingAnimationName())
                playerAnimator.SetBool(currentSkill.ChannelingAnimationName, true);

            channelTimer.Start(currentSkill.ChannelingTime);
            if (currentSkill.ChannelingCanMove == false)
                playerMovement.AddMoveBlock("freeshot");
            if (currentSkill.ChannelingCanRotate == false)
                playerMovement.AddRotationBlock("freeshot");
            player.playerStats.Add_Modifier("freeshot_perform_ms", Property.MovementSpeed, 0, currentSkill.ChannelingMovespeedMod);

            currentSkill.ChannelStart();
        }

        void FinishChannelingSkill() {
            currentSkill.ChannelEnd();

            if (currentSkill.HasChannelingAnimationName())
                playerAnimator.SetBool(currentSkill.ChannelingAnimationName, false);

            player.playerStats.Remove_Modifier("freeshot_perform_ms");
            playerMovement.RemoveMoveBlock("freeshot");
            playerMovement.RemoveRotationBlock("freeshot");
        }

        void StartRecoveringFromSkill() {
            currentSkill.SetState(FSSkillStates.FS_State_Recover);
            player.playerStats.Remove_Modifier("freeshot_perform_ms");

            if (currentSkill.HasRecoverAnimationName())
                playerAnimator.SetBool(currentSkill.RecoverAnimationName, true);

            if (currentSkill.RecoverTime > 0) {
                recoverTimer.Start(currentSkill.RecoverTime);
                if (currentSkill.RecoverCanMove == false)
                    playerMovement.AddMoveBlock("freeshot");
                if (currentSkill.RecoverCanRotate == false)
                    playerMovement.AddRotationBlock("freeshot");
                player.playerStats.Add_Modifier("freeshot_recover_ms", Property.MovementSpeed, 0, currentSkill.RecoverMovespeedMod);
            }
            else
                recoverTimer.Finish();

            currentSkill.RecoverStart();
        }

        void FinishRecoveringSkill() {
            currentSkill.RecoverEnd();

            if (currentSkill.HasRecoverAnimationName())
                playerAnimator.SetBool(currentSkill.RecoverAnimationName, false);

            player.playerStats.Remove_Modifier("freeshot_recover_ms");
            playerMovement.RemoveMoveBlock("freeshot");
            playerMovement.RemoveRotationBlock("freeshot");
            CompleteCurrentSkill();
        }

        void CompleteCurrentSkill() {
            for (int i = 0; i < (int)FSSkillElement.FS_Elem_Count; ++i) {
                int TempTributeGain = currentSkill.GetTributeGainByElement((FSSkillElement)i);

                if (TempTributeGain > 0) {
                    GodManager.Instance.AddTribute((FSSkillElement)i, TempTributeGain);
                }
            }

            GodManager.Instance.RemoveTribute(currentSkill.element, currentSkill.removeAmountGPPOnUse);

            if (currentSkill.removeAllGPPOnUse) {
                GodManager.Instance.RemoveAllTribute(currentSkill.element);
            }

            currentSkill.SkillEnd();
            playerMovement.RemoveMoveBlock("freeshot");
            playerMovement.RemoveRotationBlock("freeshot");
            CancelCurrentSkill();
        }

        /*
         * 
         */
        void ResetCurrentSkill() {
            currentSkill.SetState(FSSkillStates.FS_State_Inactive);
            skillProjector.SetNewSkillShape(currentSkill);
            currentPlacingMethod = currentSkill.placing;
            skillProjector.ShowSkillShape();
            skillProjector.UpdatePositionToPlacing(currentPlacingMethod, player.gameObject, currentSkill);
        }

        public static void AddEnemyToTargetList(GameObject p_enemy) {
            enemyList.Add(p_enemy);
        }

        float GetClosestDistanceToShapeCenter() {
            if (currentSkill != null)
                return fromPlayerRange + currentSkill.shapeSize * 0.5f;

            return fromPlayerRange;
        }

        public FSSkillBase GetCurrentSkill() {
            return currentSkill;
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
