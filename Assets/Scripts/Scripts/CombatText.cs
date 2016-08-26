using UnityEngine;
using System.Collections;

public class CombatText : MonoBehaviour
{
    private RectTransform m_canvas;
    private RectTransform m_outline, m_color;
    private UnityEngine.UI.Text m_outline_text, m_color_text;
    private Transform m_camera;

    public float Amount = 0.0f;
    public bool Crit = false;
    public Color Color;
    private float m_speed = 0.5f, m_fade = 0.4f;

    void Start()
    {
        if (CameraController.instance)
            m_camera = CameraController.instance.transform;
        m_canvas = gameObject.GetComponent<RectTransform>();

        m_outline = transform.FindChild("Black text").GetComponent<RectTransform>();
        m_color = transform.FindChild("White text").GetComponent<RectTransform>();

        Vector3 pos = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.12f, 0.12f), 0.0f);
        m_outline.transform.position += pos;
        m_color.transform.position += pos;

        m_outline_text = transform.FindChild("Black text").GetComponent<UnityEngine.UI.Text>();
        m_color_text = transform.FindChild("White text").GetComponent<UnityEngine.UI.Text>();

        m_outline_text.text = Amount.ToString("0");
        m_color_text.text = m_outline_text.text;

        m_color_text.color = Color;

        if (Crit)
        {
            m_canvas.localScale *= 1.2f;
        }
    }
    
    void Update()
    {
        m_outline_text.color -= new Color(0.0f, 0.0f, 0.0f, Time.deltaTime * m_fade);
        m_color_text.color -= new Color(0.0f, 0.0f, 0.0f, Time.deltaTime * m_fade);
        if (m_outline_text.color.a <= 0.0f)
        {
            Destroy(gameObject);
        }

        if (m_camera)
            transform.LookAt(m_camera);

        m_outline.transform.position += m_outline.transform.up * Time.deltaTime * m_speed;
        m_color.transform.position += m_color.transform.up * Time.deltaTime * m_speed;
    }
}