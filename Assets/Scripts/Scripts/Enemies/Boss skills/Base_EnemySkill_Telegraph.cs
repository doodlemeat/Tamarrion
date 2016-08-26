using UnityEngine;
using System.Collections;

public class Base_EnemySkill_Telegraph : Base_EnemySkill_Update
{

    private Projector m_charge;

    public string Type = "square/circle/triangle/line", Origin = "boss/player/position";
    public Vector3 Origin_position = Vector3.zero;
    public bool Follow_origin = true, Lock_target = false;
    public bool Chase_origin = false;
    public float Chase_speed = 0.0f;
    public float Size = 1.0f, Offset = 0.0f;
    public float m_current_size;
    public bool Show_charger = true;

    private Vector3 m_origin;

    protected override void Start()
    {
        base.Start();

        if (Show_charger)
            EnableProjector("Charge", Type == "square" ? Size : Type == "line" ? 4.0f : 0.0f, true);
        EnableProjector("Area", Size, false);

        ResetPosition();
        if (Type == "line" || Lock_target)
        {
            AimLineTelegrapher();
        }
    }

    private void EnableProjector(string p_name, float p_size, bool p_charger)
    {
        Projector projector = transform.FindChild(p_name).GetComponent<Projector>();
        projector.orthographicSize = p_size;
        projector.enabled = true;
        m_charge = p_charger ? projector : m_charge;
    }
    protected override void CheckHit()
    {
        if (Type == "square")
        {
            if (gameObject.GetComponent<ColliderTriggerContainerList>())
            {
                if(gameObject.GetComponent<ColliderTriggerContainerList>().containerList.Contains(Player.player.gameObject))
                    OnHitEffect();
            }
            else
            {
                RaycastHit hitInfo;
                Vector3 dir = gameObject.GetComponent<BoxCollider>().bounds.center - Player.player.transform.position;
                Ray ray = new Ray(Player.player.transform.position, dir);
                bool hit = Physics.Raycast(ray, out hitInfo, dir.magnitude);

                if (!hit)
                {
                    OnHitEffect();
                }
            }
        }
        else if (Type == "line")
        {
            OnHitEffect();
        }
        else if (Vector3.Distance(transform.position, m_player.transform.position) < Size)
        {
            if (Type == "circle")
            {
                OnHitEffect();
            }
            else if (Type == "triangle135" && Vector3.Angle(transform.up, m_player.transform.position - transform.position) < 67.5f)
            {
                OnHitEffect();
            }
            else if (Type == "triangle180" && Vector3.Angle(transform.up, m_player.transform.position - transform.position) < 90)
            {
                OnHitEffect();
            }
        }
    }

    protected override void Update_telegrapher_movement()
    {
        if (Follow_origin)
        {
            ResetPosition();
        }
        if (Lock_target)
        {
            AimLineTelegrapher();
        }
        if (Chase_origin)
        {
            m_origin = Origin == "boss" ? m_boss.transform.position : Origin == "player" ? m_player.transform.position : transform.position + Origin_position;
            transform.LookAt(m_origin);
            transform.position += transform.forward * Chase_speed * Time.deltaTime;
            transform.rotation = m_boss.transform.rotation * Quaternion.Euler(90, 0, 0);
        }
    }
    protected override void Update_telegrapher_charger()
    {
        if (Type == "square")
        {
            m_charge.transform.position += m_charge.transform.up * Time.deltaTime * (1.0f / Casting_time) * (Size * 1.75f);
        }
        else if (Type == "line")
        {
            m_charge.transform.position = transform.position;
            m_charge.transform.position -= transform.up * ((m_current_size / 2.0f) - 4.0f);
            m_charge.transform.position += transform.up * (m_time_casted / Casting_time) * (m_current_size - 0.9f);
        }
        else if (Type == "circle" || Type.Substring(0, 8) == "triangle")
        {
            m_charge.orthographicSize = (Size * (m_time_casted / Casting_time));
        }
    }
    private void ResetPosition()
    {
        //if (Type != "line" && !Lock_target) {
        transform.rotation = m_boss.transform.rotation * Quaternion.Euler(90, 0, 0);
        //}
        m_origin = Origin == "boss" ? m_boss.transform.position : Origin == "player" ? m_player.transform.position : transform.position + Origin_position;
        transform.position = m_origin;
        transform.position += transform.up * Offset;
    }
    private void AimLineTelegrapher()
    {
        transform.LookAt(m_player.transform.position, transform.forward);
        transform.rotation *= Quaternion.Euler(90, 0, 0);

        m_current_size = Vector3.Distance(m_boss.transform.position, m_player.transform.position);
        m_current_size = GetSpecificSize(m_current_size);
        transform.FindChild("Area").GetComponent<Projector>().orthographicSize = m_current_size / 2.0f;
        transform.FindChild("Area").GetComponent<Projector>().aspectRatio = 8.0f / m_current_size;
        transform.position += transform.up * (m_current_size / 2.0f);
    }
    protected virtual float GetSpecificSize(float p_size)
    {
        return p_size;
    }
}