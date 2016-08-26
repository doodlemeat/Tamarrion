using UnityEngine;
using System.Collections;

public class Spell_Sprint : SpellBase
{
    public float extraSpeed = 0.0f;
    public float duration = 0.0f;
    public GameObject m_trial_obj;

    private float durationCurrent;
    private GameObject trailInstance;

    public override void use()
    {
        base.use();
        _playerStats.Add_Modifier("spell_sprint", "movement_speed", 0.0f, 1.0f + extraSpeed);
        BuffManager.player_buffs.AddBuff("spell_sprint", Player.player.gameObject, duration, _spellIconMenu);

        if (m_trial_obj)
        {
            trailInstance = (GameObject)Instantiate(m_trial_obj, Player.player.gameObject.transform.position, Player.player.gameObject.transform.rotation);
            trailInstance.transform.SetParent(Player.player.gameObject.transform);
            //trailInstance.GetComponent<Xft.XWeaponTrail>().Activate();
            durationCurrent = duration;
        }
    }

    public override void Update()
    {
        base.Update();
        if (m_trial_obj && durationCurrent > 0)
        {
            durationCurrent -= Time.deltaTime;
            if (durationCurrent <= 0)
            {
                if (m_trial_obj)
                {
                    if (trailInstance)
                    {
                        if (trailInstance.GetComponent<Xft.XWeaponTrail>())
                            //trailInstance.GetComponent<Xft.XWeaponTrail>().Deactivate();
                        trailInstance.GetComponent<Xft.XWeaponTrail>().transform.SetParent(null);

                        //if (trailInstance)
                            //Destroy(trailInstance);
                    }
                }
            }
        }
    }
}