using System;

namespace Tamarrion {
	[AttributeUsage(AttributeTargets.All, Inherited = true)]
	public class UnitySingletonAttribute : Attribute {
		public readonly bool mustBeOnlyComponentOnObject;
		public readonly bool mustBeWithinRootObject;

		public UnitySingletonAttribute (bool mustBeOnlyComponentOnObject = false, bool mustBeWithinRootObject = false) {
			this.mustBeOnlyComponentOnObject = mustBeOnlyComponentOnObject;
			this.mustBeWithinRootObject = mustBeWithinRootObject;
		}
	}
}
