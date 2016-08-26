using UnityEngine;
using System.Collections;

public class FixedScale : MonoBehaviour {
    public Vector3 scale = new Vector3();

	void LateUpdate () {
        transform.localScale = scale;
	}
}