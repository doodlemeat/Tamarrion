using MarkLight.Views.UI;

namespace Tamarrion {
	public class GameMenuSkills : MyViewMonoBehavior {
		public void ClickChangeSkillTree(Button button) {
			Trigger (new TriggerAudioEvent ("menu_click"));
		}
	}
}
