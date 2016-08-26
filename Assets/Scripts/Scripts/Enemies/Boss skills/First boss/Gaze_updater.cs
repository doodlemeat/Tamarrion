using UnityEngine;
using System.Collections;

public class Gaze_updater : Base_EnemySkill_Telegraph
{
    private int m_times_casted = 0;

    protected override void Update() {
        base.Update();
        Valac.instance.transform.LookAt(m_player.transform);
    }

    protected override void Start()
    {
        base.Start();
        if (AlcoveFires.instance)
            AlcoveFires.instance.Activate();
    }
    protected override void OnHitEffect()
    {
        if (AlcoveFires.instance)
            AlcoveFires.instance.Deactivate();

        float rayHeight = 1;
        float rayDistance = 50f;
        Vector3 rayFromPos = m_boss.transform.position + Vector3.up * rayHeight;
        Vector3 rayDirection = Player.player.transform.position - m_boss.transform.position;

        RaycastHit[] hits = Physics.RaycastAll(rayFromPos, rayDirection, rayDistance);
        Debug.DrawRay(rayFromPos, rayDirection * rayDistance, Color.cyan, 5f);

        bool playerIsHit = false;
        float distanceToPlayer = 0;
        bool pillarIsHit = false;
        float distanceToPillar = 0;
        GameObject closestPillar = null;

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.name == "Player")
                {
                    playerIsHit = true;
                    distanceToPlayer = hit.distance;
                }
                else if (hit.collider.gameObject.GetComponent<PillarDestroy>())
                {
                    if (!pillarIsHit)
                    {
                        distanceToPillar = hit.distance;
                        closestPillar = hit.collider.gameObject;
                    }

                    pillarIsHit = true;
                    if (hit.distance < distanceToPillar)
                    {
                        distanceToPillar = hit.distance;
                        closestPillar = hit.collider.gameObject;
                    }
                }
            }

            //RESULTS:

            //Debug.Log("RESULTS playerhit: " + playerIsHit + " distance: " + distanceToPlayer);
            //Debug.Log("RESULTS pillarhit: " + pillarIsHit + " distance: " + distanceToPillar);
            if (playerIsHit)
            {
                if (!pillarIsHit || (pillarIsHit && distanceToPlayer < distanceToPillar))
                {
                    //Debug.Log("Player is hit");
                    DealDamageToPlayer();
                }
            }

            if (closestPillar)
            {
                if (!playerIsHit || (distanceToPillar < distanceToPlayer))
                {
                    //Debug.Log("Pillar is destroyed");
                    DestroyPillar(closestPillar);
                }
            }
        }
    }

    void DealDamageToPlayer()
    {
        m_player.GetComponent<CombatStats>().DealDamage(Damage[(int)Difficulty.Current_difficulty] * ++m_times_casted);
    }

    void DestroyPillar(GameObject p_targetPillar)
    {
        p_targetPillar.GetComponent<DestructibleObject>().DestroyIt();
        p_targetPillar.GetComponent<PillarDestroy>().Destroy();

        var rumble = CameraEffectManager.Instance.Create<Rumble>();
        rumble._speed = 2;
        rumble._Size = 50;
        rumble.Play();
    }

    protected override void OnExit()
    {
        Valac.instance.GetComponentInChildren<Animator>().SetBool("Gaze", false);
        GameObject.Find("HUD").gameObject.transform.Find("Hide").GetComponent<RectTransform>().gameObject.SetActive(false);
    }
}
