using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AltarRegeneration_updater : Base_EnemySkill_Update {
    protected override void OnHitEffect() {
        Nihteana.instance.GetComponent<Enemy_Stats>().ShieldFlat(Damage[(int)Difficulty.Current_difficulty]);
    }
}