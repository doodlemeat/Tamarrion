using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class CombatStats : MonoBehaviour {
		protected Dictionary<string, float> m_base = new Dictionary<string, float> ();
		public Dictionary<string, float> m_stat = new Dictionary<string, float> ();
		public CombatText FloatingText;
		public Animator targetAnimator;
		public string hurtAnimatorString;

		[Header ("Base stats")]
		public float MaxHealth = 100.0f, CurrentHealth = 100.0f;
		public float DamageReduction = 0.0f, Armor = 0.0f;
		public float BaseDamage = 100.0f, PhysicalDamage = 0.0f, MagicalDamage = 0.0f;
		public float CritChance = 0.0f, CritDamage = 2.0f, Multistrike = 0.0f;
		public float CooldownReduction = 0.0f;
		public float MovementSpeed = 1.0f;
		public Color Dmg_color, Heal_color, Crit_color;

		public GameObject StunFX;

		protected virtual void Awake () {
			m_base.Add ("max_health", MaxHealth);
			m_base.Add ("health", CurrentHealth);
			m_base.Add ("damage_reduction", DamageReduction);
			m_base.Add ("armor", Armor);
			m_base.Add ("damage", BaseDamage);
			m_base.Add ("physical", PhysicalDamage);
			m_base.Add ("magical", MagicalDamage);
			m_base.Add ("crit_chance", CritChance);
			m_base.Add ("crit_damage", CritDamage);
			m_base.Add ("multistrike", Multistrike);
			m_base.Add ("cooldown_reduction", CooldownReduction);
			m_base.Add ("movement_speed", MovementSpeed);

			m_base.Add ("invulnerable", 0.0f);
			m_base.Add ("stun", 0.0f);

			m_stat.Add ("max_health", m_base["max_health"]);
			m_stat.Add ("health", m_base["health"]);
			m_stat.Add ("damage_reduction", m_base["damage_reduction"]);
			m_stat.Add ("armor", m_base["armor"]);
			m_stat.Add ("damage", m_base["damage"]);
			m_stat.Add ("physical", m_base["physical"]);
			m_stat.Add ("magical", m_base["magical"]);
			m_stat.Add ("crit_chance", m_base["crit_chance"]);
			m_stat.Add ("crit_damage", m_base["crit_damage"]);
			m_stat.Add ("multistrike", m_base["multistrike"]);
			m_stat.Add ("cooldown_reduction", m_base["cooldown_reduction"]);
			m_stat.Add ("movement_speed", m_base["movement_speed"]);
			m_stat.Add ("invulnerable", m_base["invulnerable"]);
			m_stat.Add ("stun", m_base["stun"]);

			m_stat.Add ("attack_range", 2.5f);

			if ( StunFX != null ) {
				StunFX = (GameObject)Instantiate (StunFX, transform.position, Quaternion.identity);
				StunFX.transform.SetParent (transform);
				Vector3 tmp = StunFX.transform.rotation.eulerAngles;
				tmp.x = -90.0f;
				StunFX.transform.rotation = Quaternion.Euler (tmp);
				tmp = StunFX.transform.position;
				tmp.y = 4.3f;
				StunFX.transform.position = tmp;
				StunFX.SetActive (false);
			}
		}
		void Start () {
			InitializeSpecificStats ();
		}
		public virtual void InitializeSpecificStats () { }
		public virtual void ResetToBase () {
			float health_percent = GetPercentageHP ();

			m_stat["max_health"] = m_base["max_health"];
			m_stat["health"] = m_base["max_health"] * health_percent;
			m_stat["damage_reduction"] = m_base["damage_reduction"];
			m_stat["armor"] = m_base["armor"];
			m_stat["damage"] = m_base["damage"];
			m_stat["physical"] = m_base["physical"];
			m_stat["magical"] = m_base["magical"];
			m_stat["crit_chance"] = m_base["crit_chance"];
			m_stat["crit_damage"] = m_base["crit_damage"];
			m_stat["multistrike"] = m_base["multistrike"];
			m_stat["cooldown_reduction"] = m_base["cooldown_reduction"];
			m_stat["movement_speed"] = m_base["movement_speed"];
			m_stat["invulnerable"] = m_base["invulnerable"];
			m_stat["stun"] = m_base["stun"];
		}
		public float GetPercentageHP () {
			return m_stat["health"] / m_stat["max_health"];
		}

		public virtual float DealDamage (float p_amount, bool p_crit = false) {
			if ( m_stat["invulnerable"] > 0.0f || m_stat["health"] <= 0 )
				return 0.0f;

			float diff = m_stat["health"];

			p_amount = Clamp (p_amount * (1.0f - m_stat["damage_reduction"]) - m_stat["armor"], 0.0f, m_stat["max_health"]);

			m_stat["health"] -= p_amount;
			m_stat["health"] = m_stat["health"] < 0.0f ? 0.0f : m_stat["health"];

			if ( m_stat["health"] <= 0.0f )
				Death ();

			diff -= m_stat["health"];
			if ( Player.GameObjectIsPlayer (gameObject) && diff > 0 ) {
				var rumble = CameraEffectManager.Instance.Create<Rumble> ();
				rumble._speed = 2;
				rumble._Size = Rumble._damageSize;
				rumble._useDmgSize = true;
				rumble.Play ();
				FightStats.DamageTaken += p_amount;
				if ( DamageScreen.instance )
					DamageScreen.instance.StartFade ();
			}

			if ( diff > 0 ) {
				if ( targetAnimator )
					targetAnimator.SetBool (hurtAnimatorString, true);

				if ( FloatingText ) {
					InstansiateFloatingText (p_amount, p_crit, p_crit ? Crit_color : Dmg_color);
				}
			}

			return p_amount;
		}

		public virtual void HealFlat (float p_amount) {
			if ( heal_flat (p_amount) && FloatingText )
				InstansiateFloatingText (p_amount, false, Heal_color);
		}
		public virtual void HealFlat (float p_amount, bool show_text) {
			if ( heal_flat (p_amount) && FloatingText && show_text )
				InstansiateFloatingText (p_amount, false, Heal_color);
		}
		private bool heal_flat (float p_amount) {
			if ( m_stat["health"] <= 0 )
				return false;

			float diff = m_stat["health"];

			m_stat["health"] = Clamp (m_stat["health"] + p_amount, 0.0f, m_stat["max_health"]);

			diff -= m_stat["health"];
			diff = -diff;
			if ( gameObject.tag == "Player" && diff > 0 )
				FightStats.HealingDone += diff;
			return diff > 0;
		}

		public void HealPercentage (float p_percentage) {
			float Amount = m_stat["max_health"] * p_percentage / 100.0f;
			HealFlat (Amount);
		}
		public void HealPercentage (float p_percentage, bool text_show) {
			float Amount = m_stat["max_health"] * p_percentage / 100.0f;
			HealFlat (Amount, text_show);
		}

		public void Ressurect (float p_health) {
			m_stat["health"] = p_health;
			m_stat["health"] = m_stat["health"] > m_stat["max_health"] ? m_stat["max_health"] : m_stat["health"];
			//float Amount = m_stat["max_health"] * p_percentage / 100.0f;
			//HealFlat(Amount, false);
		}

		public bool GetCrit () {
			return Random.Range (0.0f, 1.0f) < m_stat["crit_chance"];
		}
		public bool GetMultistrike () {
			return Random.Range (0.0f, 1.0f) < m_stat["multistrike"];
		}

		private float Clamp (float p_value, float p_min, float p_max) {
			if ( p_value < p_min )
				return p_min;
			if ( p_value > p_max )
				return p_max;
			return p_value;
		}

		/***** Modifiers *****/

		protected struct Modifier {
			public string name, stat;
			public float flat, percent;
		}
		protected List<Modifier> m_modifiers = new List<Modifier> ();

		public void Add_Modifier (string p_ability_name, string p_stat, float p_flat = 0.0f, float p_percent = 1.0f) {
			//Debug.Log("Add: " + p_ability_name + " (" + p_stat + ", " + m_stat[p_stat] + ")" + " " + p_flat + "-" + p_percent + "%");
			Modifier modifier = new Modifier ();
			modifier.name = p_ability_name;
			modifier.stat = p_stat;
			modifier.flat = p_flat;
			modifier.percent = p_percent;
			m_modifiers.Add (modifier);
			UpdateStat (p_stat);
			//Debug.Log("Added: " + m_stat[p_stat]);
		}

		public void Remove_Modifier (string p_ability_name) {
			List<string> stats = new List<string> ();
			foreach ( Modifier m in m_modifiers ) {
				if ( m.name == p_ability_name ) {
					stats.Add (m.stat);
					m_modifiers.Remove (m);
					break;
				}
			}
			foreach ( string s in stats ) {
				UpdateStat (s);
			}
		}

		protected virtual void UpdateStat (string p_stat) {
			//Debug.Log("Updating stats, stun at " + m_stat["stun"]);
			float percentage = 1.0f;
			foreach ( Modifier m in m_modifiers ) {
				if ( m.stat == p_stat ) {
					percentage *= m.percent;
					/*if (p_stat == "stun") {
						Debug.Log("Starting updating " + m.name);
						Debug.Log("percent: " + m.percent);
					}*/
				}
			}

			m_stat[p_stat] = m_base[p_stat] * percentage;
			foreach ( Modifier m in m_modifiers ) {
				if ( m.stat == p_stat ) {
					m_stat[p_stat] += m.flat;
					/*if (p_stat == "stun")
						Debug.Log("flat: " + m.flat);*/
				}
			}

			if ( p_stat == "stun" ) {
				gameObject.GetComponentInChildren<Animator> ().SetBool ("Stunned", m_stat["stun"] != 0.0f);
				if ( gameObject.GetComponent<NavMeshAgent> () != null )
					gameObject.GetComponent<NavMeshAgent> ().enabled = m_stat["stun"] == 0.0f;
				if ( StunFX != null )
					StunFX.SetActive (m_stat["stun"] != 0.0f);
			}
		}
		protected virtual void InstansiateFloatingText (float p_amount, bool p_crit, Color p_color) {
			FloatingText.Amount = p_amount;
			FloatingText.Crit = p_crit;
			FloatingText.Color = p_color;
			Instantiate (FloatingText, transform.position + new Vector3 (0.0f, 3.0f, 0.0f), Quaternion.identity);
		}

		protected virtual void Death () { }

		public float GetStatValue (string p_statName) {
			if ( m_stat.ContainsKey (p_statName) )
				return m_stat[p_statName];

			return 0f;
		}
	}
}