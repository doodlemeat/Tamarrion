﻿using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Soul_Nova_updater : Base_EnemySkill_Telegraph {

        protected override void CheckHit() {
            if (Vector3.Distance(transform.position, m_player.transform.position) < Size) {
                OnHitEffect();
            }
            /*foreach (Enemy_Base en in Enemy_List.Enemies) {
                if (Vector3.Distance(transform.position, en.transform.position) < Size) {
                    OnHitEnemyEffect(en);
                }
            }*/
        }
        private void OnHitEnemyEffect(Enemy_Base en) {
            float damage = Damage[(int)DifficultyManager.current];
            en.GetComponent<CombatStats>().DealDamage(damage);
        }
    }
}