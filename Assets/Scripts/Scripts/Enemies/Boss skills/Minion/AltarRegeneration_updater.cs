﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
    public class AltarRegeneration_updater : Base_EnemySkill_Update {
        protected override void OnHitEffect() {
            Nihteana.instance.GetComponent<Enemy_Stats>().ShieldFlat(Damage[(int)DifficultyManager.current]);
        }
    }
}