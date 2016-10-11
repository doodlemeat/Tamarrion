using UnityEngine;
using System;
using System.Collections;
using System.IO;

//(tomas)temp for testing:
using System.Collections.Generic;
namespace Tamarrion {
	public class PlayerPrefsDefaults : MonoBehaviour {
		void Awake () {
			for ( int i = 0; i < SpellManager.SpellSlotCount; ++i ) {
				PlayerPrefs.SetInt ("playerSpell_" + i, i);
			}

			PlayerPrefs.SetInt ("playerSpell_" + 0, 0);
			PlayerPrefs.SetInt ("playerSpell_" + 1, 1);
			PlayerPrefs.SetInt ("playerSpell_" + 2, 2);
			PlayerPrefs.SetInt ("playerSpell_" + 3, 3);

			// Preselected passive spells
			int[] passiveSpells = { 0, 1, 2 };
			PlayerPrefs.SetInt ("passiveSpellsAmount", 3);
			PlayerPrefsX.SetIntArray ("passiveSpells", passiveSpells);
		}
	}
}