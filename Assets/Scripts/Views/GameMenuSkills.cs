using MarkLight.Views.UI;
using MarkLight;

namespace Tamarrion {
	public class GameMenuSkills : MyUIViewMonoBehavior {
		public ViewSwitcher ContentViewSwitcher_SkillTree;
		public ViewSwitcher ViewSwitcher_SkillTreeName;

		public void ChangeToMagic() {
			Trigger (new TriggerAudioEvent ("menu_click"));
			ViewSwitcher_SkillTreeName.SwitchTo ("SkillElementMagic");
			ContentViewSwitcher_SkillTree.SwitchTo ("SkillTreeMagic");
		}

		public void ChangeToDefense () {
			Trigger (new TriggerAudioEvent ("menu_click"));
			ViewSwitcher_SkillTreeName.SwitchTo ("SkillElementDefense");
			ContentViewSwitcher_SkillTree.SwitchTo ("SkillTreeDefense");
		}

		public void ChangeToHoly () {
			Trigger (new TriggerAudioEvent ("menu_click"));
			ViewSwitcher_SkillTreeName.SwitchTo ("SkillElementHoly");
			ContentViewSwitcher_SkillTree.SwitchTo ("SkillTreeHoly");
		}

		public void ChangeToWar () {
			Trigger (new TriggerAudioEvent ("menu_click"));
			ViewSwitcher_SkillTreeName.SwitchTo ("SkillElementWar");
			ContentViewSwitcher_SkillTree.SwitchTo ("SkillTreeWar");
		}

		public void ChangeToNature () {
			Trigger (new TriggerAudioEvent ("menu_click"));
			ViewSwitcher_SkillTreeName.SwitchTo ("SkillElementNature");
			ContentViewSwitcher_SkillTree.SwitchTo ("SkillTreeNature");
		}
	}
}
