using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace Tamarrion {
	[UnitySingleton (false, true)]
	class SkillManager : UnitySingleton<SkillManager> {
		public List<SkillElement> SkillElements = new List<SkillElement> ();
		public List<FSSkillBase> AllSkills = new List<FSSkillBase> ();
		public List<int> SelectedSkills = new List<int> ();

		protected override void OnAwake () {
			SelectedSkills.AddRange(new int[] { -1, -1, -1, -1, -1 });

			int StartingSkillIndex = 0;
			for (int i = 0; i < SelectedSkills.Count; ++i ) {
				if ( SelectedSkills[i] == -1 && StartingSkillIndex < AllSkills.Count ) {
					SelectedSkills[i] = StartingSkillIndex;
					++StartingSkillIndex;
				}
			}
		}

		void OnDestroy() {
			SaveStateToFile ();
		}

		public static FSSkillBase GetSkillInSlot(int slot) {
			if (slot < 0 || slot >= instance.SelectedSkills.Count) {
				return null;
			}

			int selectedSkill = instance.SelectedSkills[slot];
			if (selectedSkill == -1) {
				return null;
			}

			return instance.AllSkills[selectedSkill];
		}

		void SaveStateToFile() {
			StringBuilder sb = new StringBuilder ();
			StringWriter sw = new StringWriter (sb);
			JsonTextWriter writer = new JsonTextWriter (sw);
			writer.Formatting = Formatting.Indented;
			writer.Indentation = 1;
			writer.IndentChar = '\t';

			writer.WriteStartObject ();

			writer.WritePropertyName ("SelectedSkills");
			writer.WriteStartArray ();
			SelectedSkills.ForEach (e => writer.WriteValue(e));
			writer.WriteEndArray ();

			writer.WriteEndObject ();

			File.WriteAllText (Application.persistentDataPath + "/skills_" + GameManager.GetVersion() + ".json", sb.ToString());
		}

		void LoadStateFromFile() {

		}
	}
}
