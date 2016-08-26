using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]

public class Projectile : MonoBehaviour
{
    public float damage = 0.0f;
    public float speed = 1.0f;
    public GameObject createParticles;
    public GameObject destroyParticles;
    public bool crit = false;
    public bool heavy = false;
    public float vulnerability = 0.0f;
    bool VelocityInitialized = false;

    void Start()
    {
        if (createParticles)
            Instantiate(createParticles, transform.position, transform.rotation);
    }

    void Update()
    {
        if (!VelocityInitialized)
            UpdateVelocity();
        //transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void UpdateVelocity()
    {
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    //void OnTriggerEnter(Collision p_other)
    //{
    //    if (p_other.gameObject.tag == "Force")
    //        return;

    //    Debug.Log("projectile colliding with: " + p_other.gameObject);

    //    if (Enemy_List.GameObjectIsEnemy(p_other.gameObject))
    //        HitEnemy(p_other.gameObject);
    //    else if (Enemy_List.GameObjectsParentIsEnemy(p_other.gameObject))
    //        HitEnemy(p_other.gameObject.transform.parent.gameObject);

    //    if (destroyParticles)
    //        Instantiate(destroyParticles, transform.position, Quaternion.identity);

    //    Destroy(this.gameObject);
    //}

    void OnTriggerEnter(Collider p_other)
    {
        if (p_other.CompareTag("Force") || Player.GameObjectIsPlayer(p_other.gameObject))
            return;

        if (Enemy_List.GameObjectIsEnemy(p_other.gameObject))
        {
            HitEnemy(p_other.gameObject);
            DestroyThis();
        }
        else if (p_other.gameObject.transform.parent && Enemy_List.GameObjectIsEnemy(p_other.gameObject.transform.parent.gameObject))
        {
            HitEnemy(p_other.gameObject.transform.parent.gameObject);
            DestroyThis();
        }

        if (!p_other.isTrigger)
            DestroyThis();
    }

    void DestroyThis()
    {
        if (destroyParticles)
            Instantiate(destroyParticles, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }

    void HitEnemy(GameObject p_enemy)
    {
        p_enemy.GetComponent<Enemy_Stats>().DealDamage(damage, crit);
        if (heavy)
        {
            p_enemy.GetComponent<CombatStats>().Add_Modifier("Projectile Stun", "stun", 1);
            p_enemy.GetComponent<CombatStats>().Add_Modifier("Projectile DR", "damage_reduction", vulnerability);
        }
    }
}
