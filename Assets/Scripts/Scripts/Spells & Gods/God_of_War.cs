using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class God_of_War : God_Base {
        public Texture _buffIcon;
        public float _stunDuration = 0.5f;
        public int _hits = 2;
        int _currentHits = 0;

        override protected void Start() {
            base.Start();
            Player.player.GetComponentInChildren<ActivateMeleeSwordPower>().Activate();
            AddListener<Tamarrion.EnemyHitEvent>(OnHit);
            _currentHits = _hits - 1;
        }

        override protected void Update() {
            if (Player.player.GetComponentInChildren<ActivateMeleeSwordPower>())
                Player.player.GetComponentInChildren<ActivateMeleeSwordPower>().next_hit_stun = (_currentHits == (_hits - 1));
            if (_currentHits >= _hits) {
                //To-Do (Tomas 2015-12-17): FIXA SÅ DET FUNKAR MED Enemy_List
                BuffManager.boss_buffs.AddBuff("Stun", Valac.instance.gameObject, _stunDuration, _buffIcon);
                Valac.instance.GetComponent<Enemy_Stats>().Add_Modifier("Stun", "stun", 1);
                _currentHits = 0;
            }
        }

        public override void Deactivate() {
            base.Deactivate();
            RemoveListener<Tamarrion.EnemyHitEvent>(OnHit);
        }

        void OnHit(Tamarrion.EnemyHitEvent e) {
            ++_currentHits;
        }
        public override string ThreeWordDescription() {
            return "Stun on hit";
        }
        public override string GodName() {
            return "Revenna";
        }
        public override string ActiveEffectName() {
            return "Revenna's Wrath";
        }
    }
}