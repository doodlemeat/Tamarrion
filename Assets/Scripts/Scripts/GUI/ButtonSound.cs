using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityEngine.EventSystems;
namespace Tamarrion {
	[RequireComponent (typeof (Button))]

	public class ButtonSound : MonoBehaviour//, ISelectHandler
{
		void Start () {
			GetComponent<Button> ().onClick.AddListener (() => { OnClick (); });
		}

		void OnDisable () {
			GetComponent<Button> ().onClick.RemoveListener (() => { OnClick (); });
		}

		void OnClick () {
			if ( MenuSoundManager.instance )
				MenuSoundManager.instance.PlayClickSound ();
		}

		public void OnMouseEnter () {
			if ( MenuSoundManager.instance )
				MenuSoundManager.instance.PlaySelectSound ();
		}

		//public void OnSelect(UnityEngine.EventSystems.BaseEventData data)
		//{
		//    if (SelectSound)
		//        SelectSound.Play();
		//}
	}
}