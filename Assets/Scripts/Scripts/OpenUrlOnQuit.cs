using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class OpenUrlOnQuit : MonoBehaviour {
		public string adress;

		void OnApplicationQuit () {
			Application.OpenURL (adress);
		}
	}
}