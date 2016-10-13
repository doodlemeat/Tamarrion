using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class Spell_HolyShield : SpellBase {
        public float invulnerableDuration = 0.0f;

        public override void Start() {
            base.Start();
            //PlayerCastParticleSys.GetComponent<AutoDestroyParticleSystem>().Delay = invulnerableDuration;
        }

        public override void use() {
            base.use();
            PlayerAnimationEventHandler.Instance.OnShield();
            _playerStats.Add_Modifier("holy_shield", "invulnerable", 1.0f, 0.0f);
            BuffManager.player_buffs.AddBuff("holy_shield", Player.player.gameObject, invulnerableDuration, _spellIconMenu);
            HolyShieldEffect effect = gameObject.GetComponent<HolyShieldEffect>();
            effect.StartEffect();
            effect.SetDuration(invulnerableDuration);

            //GetComponentInChildren<AutoDestroyParticleSystem>().Delay = invulnerableDuration;
        }
    }
}