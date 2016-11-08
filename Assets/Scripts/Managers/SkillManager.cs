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
		public List<FSSkillBase> SelectedSkillsInstances = new List<FSSkillBase> ();
		public Dictionary<FSSkillElement, SkillElement> SkillElementsLookup = new Dictionary<FSSkillElement, SkillElement> ();

		protected override void OnAwake () {
			SelectedSkills.AddRange(new int[] { -1, -1, -1, -1, -1 });
			SelectedSkillsInstances.AddRange (new FSSkillBase[] { null, null, null, null, null });
			
			SkillElements.ForEach (e => SkillElementsLookup.Add (e.Id, e));

			int StartingSkillIndex = 0;
			for (int i = 0; i < SelectedSkills.Count; ++i ) {
				if ( SelectedSkills[i] == -1 && StartingSkillIndex < AllSkills.Count ) {
					SelectedSkills[i] = StartingSkillIndex;
					++StartingSkillIndex;
				}
			}

			if ( Application.isPlaying ) {
				for ( int i = 0; i < SelectedSkills.Count; ++i ) {
					if ( SelectedSkills[i] > -1 ) {
						FSSkillBase Skill = Instantiate (AllSkills[SelectedSkills[i]]);
						Skill.transform.SetParent (Player.player.transform);
						Skill.Element = GetElement (Skill.element);

						SelectedSkillsInstances[i] = Skill;
					}
				}
			}

			if(AllSkills.GroupBy (s => s.Identifier).Count () != AllSkills.Count) {
				Debug.LogError ("All skills needs to have unique identifers.");
			}

			AllSkills.FindAll (s => s.IsUnlockable).ForEach (s => s.Unlock ());
		}

		void Start() {
			UpdateSkillTree ();
		}

		void OnDestroy() {
			SelectedSkills.Clear ();
			SelectedSkillsInstances.Clear ();
			SaveStateToFile ();
		}

		void Update() {
			SelectedSkillsInstances.ForEach (Skill => {
				if ( Skill && !Skill.cooldownTimer.IsComplete ) {
					Skill.cooldownTimer.Update ();
				}
			});
		}

		public static FSSkillBase GetSkill(string identifer) {
			var skill = instance.AllSkills.FirstOrDefault (s => s.Identifier == identifer);

			if(!skill) {
				throw new SkillNotFoundException (string.Format("Failed to find skill with identifier: {0}", identifer)); 
			}

			return skill;
		}

		public static FSSkillBase GetSkillInSlot(int slot) {
			if (slot < 0 || slot >= instance.SelectedSkills.Count) {
				return null;
			}

			if(instance.SelectedSkillsInstances[slot] != null) {
				return instance.SelectedSkillsInstances[slot];
			}

			return null;
		}

		public static SkillElement GetElement(FSSkillElement element) {
			SkillElement FoundSkillElement;
			if(instance.SkillElementsLookup.TryGetValue (element, out FoundSkillElement)) {
				return FoundSkillElement;
			}

			return null;
		}
		
		void UpdateSkillTree() {

			// Unlock skills that has no parent
			/*AllSkills.ForEach (s => {
				if(s.ParentSkills.Count == 0) {
					s.IsLocked = false;
				}
			});*/

			// 
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
