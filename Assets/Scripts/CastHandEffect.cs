using UnityEngine;
using System.Collections;

public class CastHandEffect : MonoBehaviour {

    public GameObject[] SpellEffect = new GameObject[5];
    private GameObject m_current_effect;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void SetSpellEffect(int p_spell) {
        if (m_current_effect == null) {
            m_current_effect = (GameObject)Instantiate(SpellEffect[p_spell], transform.position, Quaternion.identity);
            m_current_effect.transform.parent = transform;
        }
    }
    public void RemoveSpellEffect() {
        Destroy(m_current_effect);
    }
}