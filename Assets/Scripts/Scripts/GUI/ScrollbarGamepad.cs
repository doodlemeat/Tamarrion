using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class ScrollbarGamepad : MonoBehaviour {
		public string AxisName = "";

		private UnityEngine.UI.Scrollbar TargetScrollbar = null;
		bool Valid = false;

		void Start () {
			TargetScrollbar = GetComponent<UnityEngine.UI.Scrollbar> ();
			if ( TargetScrollbar && AxisName != "" )
				Valid = true;
		}

		void Update () {
			if ( Valid ) {
				TargetScrollbar.value += Input.GetAxis (AxisName) * Time.deltaTime;
				if ( TargetScrollbar.value > 1 )
					TargetScrollbar.value = 1;
				else if ( TargetScrollbar.value < 0 )
					TargetScrollbar.value = 0;
			}
		}
	}
}
