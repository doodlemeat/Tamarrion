using MarkLight.Views.UI;

namespace Tamarrion {
	public class GameMenuSkills : MyViewMonoBehavior {
		public ViewSwitcher ContentViewSwitcher_SkillTree;

		public void ChangeToMagic() {
			Trigger (new TriggerAudioEvent ("menu_click"));
			ContentViewSwitcher_SkillTree.SwitchTo ("SkillTreeMagic");
		}

		public void ChangeToDefense () {
			Trigger (new TriggerAudioEvent ("menu_click"));
			ContentViewSwitcher_SkillTree.SwitchTo ("SkillTreeDefense");
		}

		public void ChangeToHoly () {
			Trigger (new TriggerAudioEvent ("menu_click"));
			ContentViewSwitcher_SkillTree.SwitchTo ("SkillTreeHoly");
		}

		public void ChangeToWar () {
			Trigger (new TriggerAudioEvent ("menu_click"));
			ContentViewSwitcher_SkillTree.SwitchTo ("SkillTreeWar");
		}

		public void ChangeToNature () {
			Trigger (new TriggerAudioEvent ("menu_click"));
			ContentViewSwitcher_SkillTree.SwitchTo ("SkillTreeNature");
		}
	}
}
