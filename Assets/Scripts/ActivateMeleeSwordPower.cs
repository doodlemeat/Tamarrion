using UnityEngine;
using System.Collections;

public class ActivateMeleeSwordPower : MonoBehaviour {

    public ParticleSystem particles = null;
    private ParticleSystem m_particle;
    public float fade_in = 1.0f, duration = 10.0f;
    private float time = 0.0f;
    private bool activated = false;
    private float opcaity = 0.7f;
    private float min_em = 2.7f, max_em = 5.0f;
    public bool next_hit_stun = false;

    void Start() {
        time = 0.0f;
    }
    void Update() {
        if (activated) {
            //Debug.Log("Activated: " + time);
            time += Time.deltaTime;
            Material[] materials = gameObject.GetComponent<MeshRenderer>().materials;
            foreach (Material m in materials) {
                //Debug.Log(m.name);
                if (m.name == "Melee G power Glow (Instance)") {
                    if (next_hit_stun) {
                        m.SetFloat("_EmissivePower", max_em);
                    }
                    else {
                        m.SetFloat("_EmissivePower", min_em);
                    }
                    //Debug.Log("Material found");
                    m.SetFloat("_Opacity", opcaity);
                    if (time < fade_in) {
                        m.SetFloat("_Opacity", time / fade_in * opcaity);
                    }
                    if (time >= duration - fade_in) {
                        //Debug.Log((1 - ((time - (duration - fade_in)) / fade_in)));
                        m.SetFloat("_Opacity", (1 - ((time - (duration - fade_in)) / fade_in)) * opcaity);
                    }
                    if (time >= duration) {
                        m.SetFloat("_Opacity", 0.0f);
                    }
                }
            }
            if (m_particle && time >= duration) {
                Destroy(m_particle);
                activated = false;
            }
        }
    }

    public void Activate() {
        //Debug.Log("Activate particles and such");
        if (particles) {
            //Debug.Log("Particles instanced");
            m_particle = (ParticleSystem)Instantiate(particles);
            m_particle.transform.SetParent(transform);
            m_particle.transform.localPosition = Vector3.zero;
            m_particle.transform.localRotation = Quaternion.Euler(Vector3.zero);
            m_particle.transform.position += m_particle.transform.forward * 0.25f;
        }
        time = 0.0f;
        activated = true;
    }
}