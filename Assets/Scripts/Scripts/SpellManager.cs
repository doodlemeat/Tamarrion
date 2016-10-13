using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tamarrion {
	[UnitySingleton (false, true)]
	class SpellManager : UnitySingleton<SpellManager> {
		public List<FSSkillBase> AllSpells = new List<FSSkillBase> ();
	}
}
