using System;

namespace Tamarrion {
	[AttributeUsage(AttributeTargets.All, Inherited = true)]
	public class UnitySingletonAttribute : Attribute {
		public readonly bool mustBeOnlyComponent;
		public readonly bool mustBeWithinRootObject;

		public UnitySingletonAttribute (bool mustBeOnlyComponent = false, bool mustBeWithinRootObject = false) {
			this.mustBeOnlyComponent = mustBeOnlyComponent;
			this.mustBeWithinRootObject = mustBeWithinRootObject;
		}
	}
}
