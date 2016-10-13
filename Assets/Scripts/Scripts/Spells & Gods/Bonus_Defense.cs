using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Bonus_Defense : Bonus_Base {
        protected override void Update() {
            base.Update();
        }

        public override void Activate(int Power, float TimerTime) {
            base.Activate(Power, TimerTime);
            this.playerStats.Add_Modifier("bonus_defensive", "damage_reduction", 0.05f * (float)this.Power, 1.0f);
            BuffManager.player_buffs.AddBuff("bonus_defensive", Player.player.gameObject, TimerTime, Texture);
        }

        public override void DeActivate() {
            playerStats.Remove_Modifier("bonus_defensive");
            //this.playerStats.Armor -= 5 * this.Power;
            base.DeActivate();
        }
    }
}