using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Persistant : MonoBehaviour {
		void Awake () {
			DontDestroyOnLoad (gameObject);
		}
	}
}