using UnityEngine;
using System.Collections;

public class SpwnOrbFromUrn : MonoBehaviour {

    public GameObject health_orb;
    public float[] spawn_percent = new float[3];

    void Start() {
        if (Random.Range(0.0f, 100.0f) < spawn_percent[(int)Difficulty.Current_difficulty]) {
            /*GameObject urn_orb = (GameObject)*/Instantiate(health_orb, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            //urn_orb.transform.SetParent(GameObject.Find("Level 1").transform);
           // Debug.Log("Spawn health: " + spawn_percent[(int)Difficulty.Current_difficulty]);
        }
    }
}