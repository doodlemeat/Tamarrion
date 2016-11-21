using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
	public enum Property {
		Health,
		MaxHealth,
		Shield,
		Damage,
		Armor,
		DamageReduction,
		PhysicalDamage,
		MagicalDamage,
		CriticalChance,
		CriticalDamage,
		CooldownReduction,
		MovementSpeed,
		RotationSpeed,
		AttackRange
	}

	public class CombatStats : MonoBehaviour {
		protected Dictionary<Property, float> m_base = new Dictionary<Property, float>();
		public Dictionary<Property, float> m_stat = new Dictionary<Property, float>();
		public CombatText FloatingText;
		public Animator targetAnimator;
		public string hurtAnimatorString;

		[Header("Base stats")]
		public float MaxHealth = 100.0f, CurrentHealth = 100.0f;
		public float DamageReduction = 0.0f, Armor = 0.0f;
		public float BaseDamage = 100.0f, PhysicalDamage = 0.0f, MagicalDamage = 0.0f;
		public float CritChance = 0.0f, CritDamage = 2.0f, Multistrike = 0.0f;
		public float CooldownReduction = 0.0f;
		public float MovementSpeed = 1.0f;
		public Color Dmg_color, Heal_color, Crit_color;

		public GameObject StunFX;

		protected struct Modifier {
			public string name;
			public Property stat;
			public float flat, percent;
		}
		protected List<Modifier> m_modifiers = new List<Modifier>();
		private List<StatusEffect> statusEffects = new List<StatusEffect>();

		protected virtual void Awake() {
			m_base.Add(Property.MaxHealth, MaxHealth);
			m_base.Add(Property.Health, CurrentHealth);
			m_base.Add(Property.DamageReduction, DamageReduction);
			m_base.Add(Property.Armor, Armor);
			m_base.Add(Property.Damage, BaseDamage);
			m_base.Add(Property.PhysicalDamage, PhysicalDamage);
			m_base.Add(Property.MagicalDamage, MagicalDamage);
			m_base.Add(Property.CriticalChance, CritChance);
			m_base.Add(Property.CriticalDamage, CritDamage);
			//m_base.Add("multistrike", Multistrike);
			m_base.Add(Property.CooldownReduction, CooldownReduction);
			m_base.Add(Property.MovementSpeed, MovementSpeed);

			//m_base.Add("invulnerable", 0.0f);
			//m_base.Add("stun", 0.0f);

			m_stat.Add(Property.MaxHealth, m_base[Property.MaxHealth]);
			m_stat.Add(Property.Health, m_base[Property.Health]);
			m_stat.Add(Property.DamageReduction, m_base[Property.DamageReduction]);
			m_stat.Add(Property.Armor, m_base[Property.Armor]);
			m_stat.Add(Property.Damage, m_base[Property.Damage]);
			m_stat.Add(Property.PhysicalDamage, m_base[Property.PhysicalDamage]);
			m_stat.Add(Property.MagicalDamage, m_base[Property.MagicalDamage]);
			m_stat.Add(Property.CriticalChance, m_base[Property.CriticalChance]);
			m_stat.Add(Property.CriticalDamage, m_base[Property.CriticalDamage]);
			//m_stat.Add("multistrike", m_base["multistrike"]);
			m_stat.Add(Property.CooldownReduction, m_base[Property.CooldownReduction]);
			m_stat.Add(Property.MovementSpeed, m_base[Property.MovementSpeed]);
			//m_stat.Add("invulnerable", m_base["invulnerable"]);
			//m_stat.Add("stun", m_base["stun"]);

			m_stat.Add(Property.AttackRange, 2.5f);

			if (StunFX != null) {
				StunFX = (GameObject)Instantiate(StunFX, transform.position, Quaternion.identity);
				StunFX.transform.SetParent(transform);
				Vector3 tmp = StunFX.transform.rotation.eulerAngles;
				tmp.x = -90.0f;
				StunFX.transform.rotation = Quaternion.Euler(tmp);
				tmp = StunFX.transform.position;
				tmp.y = 4.3f;
				StunFX.transform.position = tmp;
				StunFX.SetActive(false);
			}
		}
		void Start() {
			InitializeSpecificStats();
		}
		public virtual void InitializeSpecificStats() { }
		public virtual void ResetToBase() {
			float health_percent = GetPercentageHP();

			m_stat[Property.MaxHealth] = m_base[Property.MaxHealth];
			m_stat[Property.Health] = m_base[Property.MaxHealth] * health_percent;
			m_stat[Property.DamageReduction] = m_base[Property.DamageReduction];
			m_stat[Property.Armor] = m_base[Property.Armor];
			m_stat[Property.Damage] = m_base[Property.Damage];
			m_stat[Property.PhysicalDamage] = m_base[Property.PhysicalDamage];
			m_stat[Property.MagicalDamage] = m_base[Property.MagicalDamage];
			m_stat[Property.CriticalChance] = m_base[Property.CriticalChance];
			m_stat[Property.CriticalDamage] = m_base[Property.CriticalDamage];
			//m_stat["multistrike"] = m_base["multistrike"];
			m_stat[Property.CooldownReduction] = m_base[Property.CooldownReduction];
			m_stat[Property.MovementSpeed] = m_base[Property.MovementSpeed];
			//m_stat["invulnerable"] = m_base["invulnerable"];
			//m_stat["stun"] = m_base["stun"];
		}
		public float GetPercentageHP() {
			return m_stat[Property.Health] / m_stat[Property.MaxHealth];
		}

		public bool inStatusEffect(StatusEffectType type) {
			foreach (StatusEffect effect in statusEffects) {
				if (effect.GetType() == type) {
					return true;
				}
			}
			return false;
		}

		public virtual float DealDamage(float p_amount, bool p_crit = false) {
			if (inStatusEffect(StatusEffectType.Invulnerability) || m_stat[Property.Health] <= 0)
				return 0.0f;

			float diff = m_stat[Property.Health];

			p_amount = Clamp(p_amount * (1.0f - m_stat[Property.DamageReduction]) - m_stat[Property.Armor], 0.0f, m_stat[Property.MaxHealth]);

			m_stat[Property.Health] -= p_amount;
			m_stat[Property.Health] = m_stat[Property.Health] < 0.0f ? 0.0f : m_stat[Property.Health];

			if (m_stat[Property.Health] <= 0.0f)
				Death();

			diff -= m_stat[Property.Health];
			if (Player.GameObjectIsPlayer(gameObject) && diff > 0) {
				var rumble = CameraEffectManager.Instance.Create<Rumble>();
				rumble._speed = 2;
				rumble._Size = Rumble._damageSize;
				rumble._useDmgSize = true;
				rumble.Play();
				FightStats.DamageTaken += p_amount;
				if (DamageScreen.instance)
					DamageScreen.instance.StartFade();
			}

			if (diff > 0) {
				if (targetAnimator)
					targetAnimator.SetBool(hurtAnimatorString, true);

				if (FloatingText) {
					InstansiateFloatingText(p_amount, p_crit, p_crit ? Crit_color : Dmg_color);
				}
			}

			return p_amount;
		}

		protected void Update() {
			// Update all status effects and remove the ones that have finished
			foreach (StatusEffect effect in statusEffects) {
				effect.Update();
			}
			int removed = statusEffects.RemoveAll(effect => effect.isFinished());
		}

		public virtual void HealFlat(float p_amount) {
			if (heal_flat(p_amount) && FloatingText)
				InstansiateFloatingText(p_amount, false, Heal_color);
		}
		public virtual void HealFlat(float p_amount, bool show_text) {
			if (heal_flat(p_amount) && FloatingText && show_text)
				InstansiateFloatingText(p_amount, false, Heal_color);
		}
		private bool heal_flat(float p_amount) {
			if (m_stat[Property.Health] <= 0)
				return false;

			float diff = m_stat[Property.Health];

			m_stat[Property.Health] = Clamp(m_stat[Property.Health] + p_amount, 0.0f, m_stat[Property.MaxHealth]);

			diff -= m_stat[Property.Health];
			diff = -diff;
			if (gameObject.tag == "Player" && diff > 0)
				FightStats.HealingDone += diff;
			return diff > 0;
		}

		public void HealPercentage(float p_percentage) {
			float Amount = m_stat[Property.MaxHealth] * p_percentage / 100.0f;
			HealFlat(Amount);
		}
		public void HealPercentage(float p_percentage, bool text_show) {
			float Amount = m_stat[Property.MaxHealth] * p_percentage / 100.0f;
			HealFlat(Amount, text_show);
		}

		public void Ressurect(float p_health) {
			m_stat[Property.Health] = p_health;
			m_stat[Property.Health] = m_stat[Property.Health] > m_stat[Property.MaxHealth] ? m_stat[Property.MaxHealth] : m_stat[Property.Health];
			//float Amount = m_stat["max_health"] * p_percentage / 100.0f;
			//HealFlat(Amount, false);
		}

		public float GetDamage() {
			// TODO Vary based on type modifier (Physical, Magic)
			bool critProcced = GetCrit();
			float baseDamage = m_stat[Property.Damage] + m_stat[Property.PhysicalDamage];
			return Random.Range(baseDamage, baseDamage * 1.5f) * (critProcced ? m_stat[Property.CriticalDamage] : 1.0f);
		}

		public bool GetCrit() {
			return Random.Range(0.0f, 1.0f) < m_stat[Property.CriticalChance];
		}

		private float Clamp(float p_value, float p_min, float p_max) {
			if (p_value < p_min)
				return p_min;
			if (p_value > p_max)
				return p_max;
			return p_value;
		}

		/***** Modifiers *****/

		public void Add_Modifier(string p_ability_name, Property p_stat, float p_flat = 0.0f, float p_percent = 1.0f) {
			//Debug.Log("Add: " + p_ability_name + " (" + p_stat + ", " + m_stat[p_stat] + ")" + " " + p_flat + "-" + p_percent + "%");
			Modifier modifier = new Modifier();
			modifier.name = p_ability_name;
			modifier.stat = p_stat;
			modifier.flat = p_flat;
			modifier.percent = p_percent;
			m_modifiers.Add(modifier);
			UpdateStat(p_stat);
			//Debug.Log("Added: " + m_stat[p_stat]);
		}

		public void Remove_Modifier(string p_ability_name) {
			List<Property> stats = new List<Property>();
			foreach (Modifier m in m_modifiers) {
				if (m.name == p_ability_name) {
					stats.Add(m.stat);
					m_modifiers.Remove(m);
					break;
				}
			}
			foreach (Property s in stats) {
				UpdateStat(s);
			}
		}

		protected virtual void UpdateStat(Property p_stat) {
			//Debug.Log("Updating stats, stun at " + m_stat["stun"]);
			float percentage = 1.0f;
			foreach (Modifier m in m_modifiers) {
				if (m.stat == p_stat) {
					percentage *= m.percent;
					/*if (p_stat == "stun") {
                        Debug.Log("Starting updating " + m.name);
                        Debug.Log("percent: " + m.percent);
                    }*/
				}
			}

			m_stat[p_stat] = m_base[p_stat] * percentage;
			foreach (Modifier m in m_modifiers) {
				if (m.stat == p_stat) {
					m_stat[p_stat] += m.flat;
					/*if (p_stat == "stun")
                        Debug.Log("flat: " + m.flat);*/
				}
			}
		}

		public void ApplyStatusEffect(StatusEffect effect) {
			effect.setTarget(gameObject);
			effect.onApply();
			statusEffects.Add(effect);
		}

		protected virtual void InstansiateFloatingText(float p_amount, bool p_crit, Color p_color) {
			FloatingText.Amount = p_amount;
			FloatingText.Crit = p_crit;
			FloatingText.Color = p_color;
			Instantiate(FloatingText, transform.position + new Vector3(0.0f, 3.0f, 0.0f), Quaternion.identity);
		}

		protected virtual void Death() { }

		public float GetStatValue(Property p_statName) {
			if (m_stat.ContainsKey(p_statName))
				return m_stat[p_statName];

			return 0f;
		}
	}
}
