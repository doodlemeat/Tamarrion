using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Bonus_Melee : Bonus_Base {
        protected override void Update() {
            base.Update();
        }

        public override void Activate(int Power, float TimerTime) {
            base.Activate(Power, TimerTime);
            this.playerStats.Add_Modifier("bonus_melee", "physical", (float)Power, 1.0f);
            BuffManager.player_buffs.AddBuff("bonus_melee", Player.player.gameObject, TimerTime, Texture);
        }

        public override void DeActivate() {
            playerStats.Remove_Modifier("bonus_melee");
            //this.playerStats.Remove_Modifier("bonus_melee");
            //this.playerStats.AttackSpeed -= 5 * this.Power;
            base.DeActivate();
        }
    }
}