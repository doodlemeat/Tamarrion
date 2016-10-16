using UnityEngine;

namespace Tamarrion {
	[CreateAssetMenu (fileName = "SkillElement_", menuName = "Tamarrion/Skill Element", order = 1)]
	public class SkillElement : ScriptableObject {
		public Color Color = new Color (1, 1, 1, 1);
		public FSSkillElement Id;
	}
}
