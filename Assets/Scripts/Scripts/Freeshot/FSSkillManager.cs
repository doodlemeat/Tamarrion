using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class FSSkillManager : MonoBehaviour {
		public static FSSkillManager instance;
		public List<FSSkillBase> currentSkills = new List<FSSkillBase> ();

		public Color ColorHoly = new Color (1, 0.9f, 0.6f, 1);
		public Color ColorMagic = new Color (0.6f, 0.7f, 1, 1);
		public Color ColorNature = new Color (0.8f, 0.6f, 1, 1);
		public Color ColorDefense = new Color (0.6f, 1, 0.6f, 1);
		public Color ColorWar = new Color (1, 0.5f, 0.5f, 1);

		void Awake () {
			instance = this;
			GameObject PlayerSkills = new GameObject ();
			for ( int i = 0; i < currentSkills.Count; ++i ) {
				currentSkills[i] = (FSSkillBase)Instantiate (currentSkills[i], Vector3.zero, Quaternion.identity);
				currentSkills[i].transform.SetParent (PlayerSkills.transform);
			}
		}

		public FSSkillBase GetSkillInSlot (int p_slot) {
			if ( p_slot < 0 || p_slot >= currentSkills.Count )
				return null;

			return currentSkills[p_slot];
		}

		void Update () {
			foreach ( FSSkillBase skill in currentSkills ) {
				if ( !skill.cooldownTimer.IsComplete )
					skill.cooldownTimer.Update ();
			}
		}

		public Color GetColorByElement (FSSkillElement p_element) {
			if ( p_element == FSSkillElement.FS_Elem_Holy )
				return ColorHoly;
			else if ( p_element == FSSkillElement.FS_Elem_Magic )
				return ColorMagic;
			else if ( p_element == FSSkillElement.FS_Elem_Nature )
				return ColorNature;
			else if ( p_element == FSSkillElement.FS_Elem_Defense )
				return ColorDefense;
			else if ( p_element == FSSkillElement.FS_Elem_War )
				return ColorWar;

			return Color.black;
		}
	}
}