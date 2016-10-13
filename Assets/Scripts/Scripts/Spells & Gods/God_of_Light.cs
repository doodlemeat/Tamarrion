using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class God_of_Light : God_Base {
        public GameObject wings_prefabs;
        private GameObject m_wings;
        public float _percentageOfAttack = 3.0f;

        protected override void Start() {
            base.Start();
            AddListener<Tamarrion.EnemyHitEvent>(OnHit);

            Player.player.GetComponentInChildren<DivineLigtWings>().show_wings = true;
        }

        protected override void Update() {
        }

        public override void Deactivate() {
            base.Deactivate();
            RemoveListener<Tamarrion.EnemyHitEvent>(OnHit);
            Player.player.GetComponentInChildren<DivineLigtWings>().show_wings = false;
        }

        void OnHit(Tamarrion.EnemyHitEvent e) {
            float healing = e.damage * _percentageOfAttack / 100;
            Player.player.playerStats.HealFlat(healing);
        }

        public override string ThreeWordDescription() {
            return "Heal on hit";
        }
        public override string GodName() {
            return "High Lord";
        }
        public override string ActiveEffectName() {
            return "High Lord's Grace";
        }
    }
}