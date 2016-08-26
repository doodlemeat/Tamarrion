using UnityEngine;
using System.Collections;

public class SupportGodPowerFeedback : MonoBehaviour {

    public GameObject effect;
    private GameObject m_cur_effect;
    //public bool active = false;

	public void Activate () {
        if (!m_cur_effect) {
            m_cur_effect = (GameObject)Instantiate(effect);
            m_cur_effect.transform.SetParent(transform);
            m_cur_effect.transform.localPosition = Vector3.zero;
        }
	}
    public void Deactivate() {
        if (m_cur_effect)
            Destroy(m_cur_effect);
	}
}