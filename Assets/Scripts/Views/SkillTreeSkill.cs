using MarkLight.Views.UI;
using UnityEngine;

namespace Tamarrion {
	class SkillTreeSkill : MyUIViewMonoBehavior {
		FSSkillBase CurrentSkill;
		public void Start () {
			try {
				SkillManager.GetSkill (Id);
			} catch(SkillNotFoundException e) {
				Debug.LogError (e);
			}
		}

		public void ClickSkill() {
			CurrentSkill = SkillManager.GetSkill (Id);
			
			if( CurrentSkill.IsLocked ) {
				Trigger (new MessageBoxEvent {
					Message = "Do you want to spend " + CurrentSkill.Cost + " Favour to unlock " + CurrentSkill.Name + "?",
					YesAction = ClickYesUnlock,
					NoAction = () => CurrentSkill = null
				});
			}
		}

		void ClickYesUnlock() {
			if(!CurrentSkill.IsUnlockable) {
				Trigger (new AlertEvent {
					Message = "This skill can't yet be unlocked."
				});
			} else if ( Player.player.CanAfford (CurrentSkill.Cost) ) {
				Player.player.Withdraw (CurrentSkill.Cost);
				CurrentSkill.Unlock ();
				Trigger (new AlertEvent {
					Message = "You unlocked " + CurrentSkill.Name + " for " + CurrentSkill.Cost + " Favour."
				});
			} else {
				Trigger (new AlertEvent {
					Message = "You don't have enough Favour."
				});
			}
			CurrentSkill = null;
		}
	}
}
