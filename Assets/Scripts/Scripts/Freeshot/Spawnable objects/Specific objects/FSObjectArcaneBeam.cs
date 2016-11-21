using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
    public class FSObjectArcaneBeam : MonoBehaviour {
        public List<float> DamageAmount = new List<float>();
        public List<GameObject> beamParticleEffects = new List<GameObject>();
        public GameObject beamHitParticles;
        public GameObject beamSparkParticles;
        public float TickTime = 0.75f;
        public float UpgradeTime = 2;
        public float RaycastRange = 6;
        public float MagicDamagePercentage = 1f;

        Timer tickTimer = new Timer();
        Timer upgradeTimer = new Timer();
        float ForceTime = 0.15f;
        Timer forceTimer = new Timer();

        int m_currentUpgradeLevel = 0;
        GameObject m_hitTarget;
        Vector3 m_lastHitPos;

        void Start() {
            tickTimer.Start(TickTime);
            forceTimer.Start(ForceTime);
            UpdateBeamParticles();
            SpawnSparkParticles();
        }

        void Update() {
            CastRay();

            if (m_hitTarget) {
                upgradeTimer.Update();
                if (upgradeTimer.IsFinished) {
                    upgradeTimer.Start(UpgradeTime);
                    if (LevelUpgradeAllowed()) {
                        SpawnSparkParticles();
                        UpgradeToNextLevel();
                    }
                }
            }

            tickTimer.Update();
            if (tickTimer.IsFinished) {
                tickTimer.Start(TickTime);

                if (m_hitTarget) {
                    DealDamageToHitTarget();
                    if (beamHitParticles) {
                        Instantiate(beamHitParticles, m_lastHitPos, beamHitParticles.transform.rotation);
                    }
                }
            }

            forceTimer.Update();
            if (forceTimer.IsFinished) {
                forceTimer.Start(ForceTime);
                ForcePusher.instance.SendForceFromObject(Player.player.gameObject, new Vector3(30, 0, 0), 0.35f, ForcePusher.Shape.Box, new Vector3(1.5f, 1, 1.5f), new Vector3(0, 0.65f, 0), true);
            }
        }

        public void SpawnSparkParticles() {
            if (beamSparkParticles)
                Instantiate(beamSparkParticles, (Player.player.LeftHand ? Player.player.LeftHand.position : Player.player.transform.position + new Vector3(0, 1, 1)), beamSparkParticles.transform.rotation);
        }

        void CastRay() {
            Ray ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward * RaycastRange, Color.cyan, 0.2f);
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(ray, out hitInfo, RaycastRange);

            if (hit) {
                m_lastHitPos = hitInfo.point;

                if (Enemy_List.GameObjectIsEnemy(hitInfo.collider.gameObject))
                    ChangeTarget(hitInfo.collider.gameObject);
                else if (Enemy_List.GameObjectsParentIsEnemy(hitInfo.collider.gameObject))
                    ChangeTarget(hitInfo.collider.gameObject.transform.parent.gameObject);
            }
            else
                RemoveTarget();
        }

        void UpgradeToNextLevel() {
            ++m_currentUpgradeLevel;
            UpdateBeamParticles();
            //add upgrade effect particle!
        }

        bool LevelUpgradeAllowed() {
            return (m_currentUpgradeLevel < DamageAmount.Count - 1);
        }

        void UpdateBeamParticles() {
            for (int i = 0; i < beamParticleEffects.Count; ++i) {
                if (i == m_currentUpgradeLevel)
                    beamParticleEffects[i].SetActive(true);
                else
                    beamParticleEffects[i].SetActive(false);
            }
        }

        void ResetUpgradeLevelAndTimer() {
            m_currentUpgradeLevel = 0;
            upgradeTimer.Start(UpgradeTime);
        }

        void ChangeTarget(GameObject p_obj) {
            if (m_hitTarget != p_obj) {
                m_hitTarget = p_obj;
                ResetUpgradeLevelAndTimer();
                UpdateBeamParticles();
            }
        }

        void RemoveTarget() {
            m_hitTarget = null;
            ResetUpgradeLevelAndTimer();
            UpdateBeamParticles();
        }

        void DealDamageToHitTarget() {
            if (m_hitTarget == null)
                return;

            if (DamageAmount.Count > 0 && m_currentUpgradeLevel < DamageAmount.Count) {
                float totalDamage = DamageAmount[m_currentUpgradeLevel];
                bool crit = (PlayerStats.instance ? PlayerStats.instance.GetCrit() : false);
                if (PlayerStats.instance) {
                    totalDamage += PlayerStats.instance.GetStatValue(Property.MagicalDamage) * MagicDamagePercentage;
                    totalDamage *= (crit ? PlayerStats.instance.GetStatValue(Property.CriticalDamage) : 1.0f);
                }

                m_hitTarget.GetComponent<Enemy_Stats>().DealDamage(totalDamage, crit);
            }
        }
    }
}