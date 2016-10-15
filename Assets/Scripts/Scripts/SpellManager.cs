using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace Tamarrion {
	[UnitySingleton (false, true)]
	class SpellManager : UnitySingleton<SpellManager> {
		public List<FSSkillBase> AllSpells = new List<FSSkillBase> ();
		public List<int> SelectedSpells = new List<int> ();

		protected override void OnAwake () { }

		void SaveStateToFile() {
			StringBuilder sb = new StringBuilder ();
			StringWriter sw = new StringWriter ();
			JsonWriter writer = new JsonTextWriter (sw);
			writer.Formatting = Formatting.Indented;
			writer.WriteStartObject ();

			writer.WritePropertyName ("SelectedSpells");
			writer.WriteValue (SelectedSpells);
			writer.WriteEndObject ();

			File.WriteAllText (Application.persistentDataPath + "/spells_" + GameManager.GetVersion() + ".json", sb.ToString());
		}

		void LoadStateFromFile() {
		}
	}
}
