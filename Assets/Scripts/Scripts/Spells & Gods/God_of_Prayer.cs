using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class God_of_Prayer : God_Base {
		override protected void Start () {
			base.Start ();
			Name = "God of Prayer";
			if ( Evade.instance )
				Evade.instance.SetGodModeActive ();
		}

		public override void Deactivate () {
			base.Deactivate ();
			if ( Evade.instance )
				Evade.instance.SetGodModeActive (false);
		}

		override protected void Update () {
			//Debug.Log("God of prayer update");
		}
		public override string ThreeWordDescription () {
			return "Teleporting Evade";
		}
		public override string GodName () {
			return "Aiana";
		}
		public override string ActiveEffectName () {
			return "Aiana's Gift";
		}
	}
}
