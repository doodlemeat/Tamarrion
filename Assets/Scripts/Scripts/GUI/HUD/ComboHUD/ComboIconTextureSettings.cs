using UnityEngine;
using System.Collections;

public class ComboIconTextureSettings : MonoBehaviour
{
    //private bool m_showing = false;
    private float m_fade = 0.0f;//, m_fade_speed = 4.0f;

    void Start() {
        //m_showing = false;

        //m_fade = 0.0f;
        m_fade = 1.0f;

        GetComponent<CanvasGroup>().alpha = m_fade;
    }

    void Update() 
	{
        //if (!m_showing && Player.player.gameObject.GetComponent<PlayerStats>().ComboPoints.Count > 0) {
        //    m_showing = true;
        //}
        //else if (m_showing && Player.player.gameObject.GetComponent<PlayerStats>().ComboPoints.Count == 0) {
        //    m_showing = false;
        //}
        //if (m_showing && m_fade < 1.0f) {
        //    m_fade += Time.deltaTime * m_fade_speed;
        //    m_fade = m_fade > 1.0f ? 1.0f : m_fade;
        //    GetComponent<CanvasGroup>().alpha = m_fade;
        //}
        //else if (!m_showing && m_fade > 0.0f) {
        //    m_fade -= Time.deltaTime * m_fade_speed;
        //    m_fade = m_fade < 0.0f ? 0.0f : m_fade;
        //    GetComponent<CanvasGroup>().alpha = m_fade;
        //}
    }
}