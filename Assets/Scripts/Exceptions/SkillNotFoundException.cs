using System;

namespace Tamarrion {
	class SkillNotFoundException : Exception {
		public SkillNotFoundException() { }
		public SkillNotFoundException(string message) 
			: base(message) { }
		public SkillNotFoundException (string message, Exception inner)
        : base(message, inner) { }
	}
}
