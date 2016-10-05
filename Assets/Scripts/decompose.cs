using UnityEngine;
using System.Collections;

public class decompose : MonoBehaviour {

    public float alive_time = 0, decomposeTime = 0;
    //public Vector3 decompose_travel = Vector3.zero;
    private float time_alive = 0, time_decomposed = 0;
    private bool decomposing = false;
    public bool decompose_at_start = false;
    private bool dead = false;

	void Start () {
        decomposing = decompose_at_start;
    }
	
	void Update () {
        if (decomposing) {
            time_alive += Time.deltaTime;
            if (time_alive >= alive_time) {
                if (!dead) {
                    dead = true;
                    if (gameObject.GetComponent<BoxCollider>() != null)
                        gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                time_alive = alive_time;
                time_decomposed += Time.deltaTime;

                gameObject.transform.position -= new Vector3(0, 1.0f * Time.deltaTime * (1 / decomposeTime), 0);

                if (time_decomposed >= decomposeTime) {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void StartDecomposing() {
        decomposing = true;
    }
}