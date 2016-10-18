using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
	/** Types of attack */
	public enum AttackType { Physical, Magical };

	public class PlayerCombat : MyMonoBehaviour {
		public static PlayerCombat instance;

		/** The combo indicator */
		public GameObject comboIndicator;

		/** Particle system for attack hit effects */
		public ParticleSystem onHitParticles;

		/** The player animation state machine */
		private Animator animator;

		/** Player combat stats */
		private PlayerStats playerStats;

		/** The player weapon trail */
		private Xft.XWeaponTrail weaponTrail;

		/** List of sources that block attacking */
		private List<string> attackBlockers = new List<string>();

		void Awake() {
			instance = this;
		}

		void Start() {
			animator = GetComponentInChildren<Animator>();
			playerStats = GetComponent<PlayerStats>();
			weaponTrail = GetComponentInChildren<Xft.XWeaponTrail>();

			HideWeaponTrail();
		}

		void Update() {
			if (SceneManager.Instance.IsPaused()) {
				return;
			}

			// FIXME Shouldn't this be in the Player class?
			if (playerStats.m_stat["health"] <= 0) {
				animator.SetBool("Dead", true);
				return;
			}

			if (!GodManager.Instance) {
				return;
			}
			bool useMelee = GodManager.Instance.CurrentGod == null ||
				GodManager.Instance.CurrentGod.element != FSSkillElement.FS_Elem_Magic;

			bool activeSkill = FSSkillUser.CurrentSkillIsActive();
			if (activeSkill) {
				return;
			}

			if (CanAttack()) {
				if (Input.GetMouseButtonDown(0)) {
					if (useMelee) {
						animator.SetTrigger("Attack");
					}
					else {
						animator.SetTrigger("MagicAttack");
					}
				}
			}
		}

		public void ShowWeaponTrail() {
			weaponTrail.Activate();
		}

		public void HideWeaponTrail() {
			weaponTrail.Deactivate();
		}

		public void ShowComboIndicator() {
			if (!comboIndicator.activeSelf)
				comboIndicator.SetActive(true);
		}

		public void HideComboIndicator() {
			if (comboIndicator.activeSelf)
				comboIndicator.SetActive(false);
		}

		public void SendForceFromPlayer(Vector3 force, float lifetime, Vector3 scale, Vector3 offset) {
			if (ForcePusher.instance) {
				ForcePusher.instance.SendForceFromObject(Player.player.gameObject, force, lifetime,
						ForcePusher.Shape.Box, scale, offset, true);
			}
		}

		public IEnumerator AttackAfter(AttackType type, float delay) {
			yield return new WaitForSeconds(delay);
			PerformAttack(type);
		}

		private void PerformAttack(AttackType type) {
			HideWeaponTrail();
			Player player = Player.player;

			if (type == AttackType.Magical) {
				float damage = player.playerStats.GetDamage();

				Trigger(new PlayerAttackEvent(damage));
			}
			if (type == AttackType.Physical) {
				foreach (Enemy_Base enemy in Enemy_List.Enemies) {
					float damage = player.playerStats.GetDamage();

					Trigger(new PlayerAttackEvent(damage));

					if (EnemyInRange(player, enemy.gameObject) && EnemyInArc(player, enemy.gameObject)) {
						// TODO Make enemy listener to hit event rather than directly dealing damage
						enemy.GetComponent<Enemy_Stats>().DealDamage(damage); // TODO add whether the damage critted?

						Trigger(new EnemyHitEvent(damage));

						PlayRandomHitSound();
						ShowOnHitParticles(enemy.gameObject.transform.position + new Vector3(0, 1, 0));
					}
				}
			}
		}

		private bool EnemyInRange(Player player, GameObject enemy) {
			float distance = Vector3.Distance(player.gameObject.transform.position, enemy.transform.position);
			return distance < player.playerStats.m_stat["attack_range"];
		}

		private bool EnemyInArc(Player player, GameObject enemy) {
			Vector3 playerPosition = player.gameObject.transform.position;
			Vector3 enemyPosition = enemy.transform.position;
			Vector3 enemyDirection = enemyPosition - playerPosition;

			float angle = Vector3.Angle(player.gameObject.transform.forward, enemyDirection);
			float attackAngle = 67.5f; // TODO Replace by an arc specific to the attack

			return angle < attackAngle;
		}

		private void PlayRandomHitSound() {
			if (PlayerAnimationEventHandler.Instance) {
				PlayerAnimationEventHandler.Instance.OnHit();
			}
		}

		private void ShowOnHitParticles(Vector3 position) {
			if (onHitParticles) {
				Instantiate(onHitParticles, position, onHitParticles.transform.rotation);
			}
		}

		public void AddAttackBlocker(string source) {
			if (!attackBlockers.Contains(source)) {
				attackBlockers.Add(source);
			}
		}

		public void RemoveAttackBlocker(string source) {
			attackBlockers.Remove(source);
		}

		public bool CanAttack() {
			return attackBlockers.Count == 0;
		}
	}
}
