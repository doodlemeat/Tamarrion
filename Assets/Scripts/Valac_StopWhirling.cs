﻿using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Valac_StopWhirling : StateMachineBehaviour {
		override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			if ( Valac.instance )
				Valac.instance.Whirling = false;
		}
	}
}