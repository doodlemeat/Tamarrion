using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Tamarrion;
namespace Tamarrion {
	public class Enemy_SkillManager : MyMonoBehaviour {
		public List<GameObject> Skills = new List<GameObject> ();
		public bool is_boss = false;
		public GameObject Skill_Gameobject;
		private List<Base_EnemySkill> m_skills = new List<Base_EnemySkill> ();
		private Base_EnemySkill m_current_skill = null, m_relevant_skill = null;
		private float m_current_relevance = 0.0f;
		private bool m_using_skill = false;
		private Base_EnemySkill_Update m_current_updater;

		private Xft.XWeaponTrail m_trail;

		void Start () {
			//Debug.Log("Start Skill Manager");
			m_trail = gameObject.GetComponentInChildren<Xft.XWeaponTrail> ();
			if ( m_trail )
				m_trail.Deactivate ();
			SetDefaultSkills ();
			//Debug.Log("End Skill Manager");
		}

		public void SetDefaultSkills () {
			//Debug.Log("Set default skills: " + gameObject.name);
			NewPhase (1);
		}

		public bool UpdateSkills () {
			if ( m_current_skill == null ) {
				//Debug.Log("Current skill null?");
				m_using_skill = false;
				return false;
			}
			/*if (is_boss && m_current_updater != null)
				Debug.Log("Stop using skill " + m_current_updater.GetProgress() + " - " + m_using_skill);*/
			if ( m_current_skill.UpdateSkill () ) {
				/*if (is_boss)
					Debug.Log("Stop using skill " + m_current_skill.name);*/
				m_using_skill = false;
				if ( m_trail )
					m_trail.Deactivate ();
				return true;
			}
			return false;
		}

		public float GetRelevance () {
			float relevance;
			m_current_relevance = 0.0f;
			//Debug.Log("-- GetRelevance -- (" + m_skills.Count + ")");
			foreach ( Base_EnemySkill skill in m_skills ) {
				relevance = skill.CheckRelevance ();
				//if (is_boss)
				//	Debug.Log("Get relevance " + skill.m_name + ": " + relevance);
				if ( relevance > m_current_relevance ) {
					m_current_relevance = relevance;
					m_relevant_skill = skill;
				}
			}
			return m_current_relevance;
		}

		public void UseSkill () {
			if ( !m_using_skill ) {
				/*if (is_boss)
					Debug.Log("Use skill " + m_relevant_skill.name);*/
				//Debug.Log(m_relevant_skill.name);
				if ( m_trail )
					m_trail.Activate ();
				m_current_skill = m_relevant_skill;
				m_current_skill.Initialize ();
				m_using_skill = true;
				if ( is_boss )
					BossCastbar.castbar.GetComponentInChildren<Text> ().text = m_current_skill.m_name;
			}
		}
		public bool UsingSkill () {
			return m_using_skill;
		}
		public void SetUpdater (Base_EnemySkill_Update p_updater) {
			m_current_updater = p_updater;
		}
		public float GetProgress () {
			if ( m_current_updater == null ) {
				return 1.0f;
			}
			return m_current_updater.GetProgress ();
		}
		public bool GetShowCastbar () {
			if ( m_current_updater )
				return m_current_updater._useCastbar;
			return false;
		}
		public void NewPhase (int p_phase) {
			Trigger (new BossPhaseSwitchEvent (p_phase, GetComponent<Enemy_Base> ()));

			for ( int i = 0; i < Skills.Count; i++ ) {
				//Debug.Log(Skills[i].name + ", Phase " + Skills[i].GetComponent<Base_EnemySkill>().PhaseActivate + "/" + p_phase);
				if ( Skills[i].GetComponent<Base_EnemySkill> ().PhaseActivate <= p_phase ) {
					//Debug.Log(gameObject + ", activate " + Skills[i]);
					GameObject tmp = Instantiate (Skills[i]);
					tmp.transform.parent = Skill_Gameobject.transform;
					tmp.GetComponent<Base_EnemySkill> ().m_boss = gameObject.transform;
					tmp.GetComponent<Base_EnemySkill> ().m_animator = gameObject.GetComponentInChildren<Animator> ();
					m_skills.Add (tmp.GetComponent<Base_EnemySkill> ());
					Skills.Remove (Skills[i--]);
				}
			}
			for ( int i = 0; i < m_skills.Count; i++ ) {
				//Debug.Log("Remove skills");
				if ( m_skills[i].GetComponent<Base_EnemySkill> ().PhaseDeactivated <= p_phase && m_skills[i].GetComponent<Base_EnemySkill> ().PhaseDeactivated != 0 ) {
					Destroy (m_skills[i].gameObject);
					m_skills.Remove (m_skills[i--]);
					//break;
				}
				//Debug.Log("Removed");
			}
		}
	}
}