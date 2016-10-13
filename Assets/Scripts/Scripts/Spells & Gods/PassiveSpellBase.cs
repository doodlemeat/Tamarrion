using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class PassiveSpellBase : MonoBehaviour {
        public Texture spellIcon;
        public SpellManager.SpellType Type;
        public string Name = "";
        public string description = "";

        protected SpellManager spellManager;
        protected PlayerStats playerStats;

        protected virtual void Awake() {

        }

        protected virtual void Destroy() {

        }

        protected virtual void Start() {
            spellManager = GetComponentInParent<SpellManager>();
            playerStats = GetComponentInParent<PlayerStats>();
        }

        protected virtual void Update() {

        }

        public virtual void onCastSpell(SpellBase spell) {
        }

        public virtual void onAttack() {
        }
    }
}