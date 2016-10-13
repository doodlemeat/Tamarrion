using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Spell_Spellslinger : PassiveSpellBase {
        public float percent = 10.0f;

        public override void onCastSpell(SpellBase spell) {
            float n = Random.Range(0.0f, 100.0f);
            if (n <= percent) {

                // Reset all spells cooldowns
            }
        }
    }
}