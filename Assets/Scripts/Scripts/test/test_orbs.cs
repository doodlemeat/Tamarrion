using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class test_orbs : MonoBehaviour {

    private List<Transform> m_orbs;
    public Transform m_orb_prefab;
    public int m_orb_amount = 1;

	void Start () {
        m_orbs = new List<Transform>();
        for (int i = 0; i < m_orb_amount; i++) {
            m_orbs.Add((Transform)Instantiate(m_orb_prefab, transform.position + StartPosition() * 0.75f, Quaternion.LookRotation(StartPosition())));
            m_orbs[i].parent = transform;
        }
	}
	void Update () {
        foreach (Transform orb in m_orbs) {
            if (orb == null) {
                m_orbs.Remove(orb);
                break;
            }
            orb.RotateAround(transform.position, orb.forward, 50.0f * Time.deltaTime);
        }
	}

    private Vector3 StartPosition() {
        return new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    }
}