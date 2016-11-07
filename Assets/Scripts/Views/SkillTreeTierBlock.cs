using MarkLight.Views.UI;
using MarkLight;
using UnityEngine;
using System.Collections.Generic;

namespace Tamarrion {
	class SkillTreeTierBlock : Region {
		Group Group;

		public override void Initialize () {
			base.Initialize ();

			int tier = 0;
			List<SkillTreeTierBlock> tierBlocks = new List<SkillTreeTierBlock> ();
			Parent.ForEachChild<SkillTreeTierBlock> (e => {
				tierBlocks.Add (e);
			});

			for(int i = 0; i < tierBlocks.Count; ++i ) {
				if(tierBlocks[i] == this) {
					tier = i + 1;
					break;
				}
			}

			Margin.Value = GetMargin (tier);

			if ( ChildCount > 1 && Group == null ) {
				List<SkillTreeSkill> skillsToMove = new List<SkillTreeSkill> ();
				this.ForEachChild<SkillTreeSkill> (c => {
					skillsToMove.Add (c);
				});
				Group = CreateView<Group> ();
				Group.Spacing.Value = ElementSize.FromPixels (32);
				Group.Orientation.Value = ElementOrientation.Horizontal;
				skillsToMove.ForEach (s => s.MoveTo (Group));
				Group.InitializeViews ();
			}
		}

		ElementMargin GetMargin(int Tier) {
			float topPercent;
			float bottomPercent;
			float percentPart = 1f / Parent.ChildCount;

			topPercent = (Tier - 1) * percentPart;
			bottomPercent = 1f - Tier * percentPart;

			return new ElementMargin (ElementSize.FromPercents(0), ElementSize.FromPercents(topPercent), ElementSize.FromPercents(0), ElementSize.FromPercents(bottomPercent));
		}
	}
}
