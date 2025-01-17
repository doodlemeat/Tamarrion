﻿using UnityEngine;
using System.Collections.Generic;
using Tamarrion;

public class Evade : MyMonoBehaviour {
    public static Evade instance;

    bool GodModeOn = false;
    public float GodModeMaxDistance = 4f;
    public float GodModeRaycastHeightOffset = 0.5f;
    public float GodModeWallOffset = 0.5f;
    public float RollTime = 1;
    public float GodCooldownTime = 0.3f;
    public AnimationCurve SpeedCurve = new AnimationCurve();
    public float InvulTime = 0.14f;
    public ParticleSystem normalParticleEffect;
    public GameObject godmodeParticleEffect;

    Animator animator;
    bool isEvading = false;
    bool isInvulnerable = false;
    Vector3 RollDirection;
    GameObject trailInstance;
    Timer rollTimer = new Timer();
    Timer invulTimer = new Timer();

    List<string> evadeBlockers = new List<string>();

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        animator = Player.player.gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (!isEvading && (Input.GetButton("Roll") || Input.GetAxis("Roll") > 0))
        {
            Vector3 inputDir = PlayerMovement.instance.GetInputDirection();
            if (inputDir.magnitude > 0)
                Use(PlayerMovement.instance.GetInputDirection());
            else
                Use(Player.player.gameObject.transform.forward);
        }

        if (isInvulnerable)
        {
            invulTimer.Update();
            if (invulTimer.IsFinished)
            {
                PlayerStats.instance.Remove_Modifier("roll_invul");
            }
        }

        if (isEvading && !GodModeOn)
        {
            PlayerMovement.instance.forceDirection(RollDirection);
            PlayerStats.instance.Remove_Modifier("Roll_MS");

            rollTimer.Update();
            if (rollTimer.IsFinished)
            {
                CancelEvade();
            }
            else
                PlayerStats.instance.Add_Modifier("Roll_MS", Property.MovementSpeed, 0, SpeedCurve.Evaluate(rollTimer.Progress()));
        }
        else if (GodModeOn)
        {
            rollTimer.Update();
            if (rollTimer.IsFinished)
            {
                RemoveEvadeBlock("Evade_GodMode");
            }
        }
    }

    public void Use(Vector3 p_direction)
    {
        if (isEvading || !EvadeEnabled())
            return;

        PlayerMovement.instance.RemoveMoveBlock("attack");

        RollDirection = p_direction;

        if (!GodModeOn)
            rollTimer.Start(RollTime);
        else
            rollTimer.Start(GodCooldownTime);

        isInvulnerable = true;
        invulTimer.Start(InvulTime);

        SpawnNormalParticleEffect();

        if (GodModeOn)
            StartGodmodeEvade(p_direction);
        else
            StartNormalEvade(p_direction);
    }

    void SpawnNormalParticleEffect()
    {
        if (normalParticleEffect)
            Instantiate(normalParticleEffect, Player.player.transform.position, normalParticleEffect.transform.rotation);
    }

    void SpawnGodmodeParticleEffect()
    {
        if (godmodeParticleEffect)
            Instantiate(godmodeParticleEffect, Player.player.transform.position + godmodeParticleEffect.transform.position, godmodeParticleEffect.transform.rotation);
    }

    void StartNormalEvade(Vector3 p_direction)
    {
		AudioOptions options = new AudioOptions ();
		options.pitch = Random.Range (0.7f, 1.2f);
		Trigger (new TriggerAudioEvent("evade", options));

        if (PlayerCombat.instance)
            PlayerCombat.instance.AddAttackBlocker("evade");

        isEvading = true;

        if (PlayerStats.instance)
        {
            PlayerStats.instance.Add_Modifier("roll_invul", Property.DamageReduction, 1);
            PlayerStats.instance.Add_Modifier("Roll_MS", Property.MovementSpeed, 0, SpeedCurve.Evaluate(1));
        }

        animator.SetBool("Rolling", true);

        if (PlayerMovement.instance)
            PlayerMovement.instance.forceDirection(p_direction);
    }

    void StartGodmodeEvade(Vector3 p_direction)
    {
        AddEvadeBlock("Evade_GodMode");

        Vector3 teleportPosition = PlayerMovement.instance.transform.position;

        Ray ray = new Ray(PlayerMovement.instance.transform.position + new Vector3(0, GodModeRaycastHeightOffset, 0), p_direction);
        RaycastHit raycastInfo = new RaycastHit();
        bool raycast = Physics.Raycast(ray, out raycastInfo, GodModeMaxDistance);
        if (raycast)
        {
            teleportPosition = raycastInfo.point - (p_direction * GodModeWallOffset);
        }
        else
        {
            teleportPosition = PlayerMovement.instance.transform.position + p_direction * GodModeMaxDistance;
        }

        PlayerMovement.instance.transform.position = teleportPosition;
        SpawnGodmodeParticleEffect();
    }

    public void CancelEvade()
    {
        Tamarrion.PlayerCombat.instance.RemoveAttackBlocker("evade");
        PlayerMovement.instance.forceDirection(Vector3.zero);
        PlayerStats.instance.Remove_Modifier("Roll_MS");

        isEvading = false;
        animator.SetBool("Rolling", false);

        if (trailInstance)
        {
            trailInstance.transform.SetParent(null);
            trailInstance = null;
        }
    }

    public void AddEvadeBlock(string p_sourceName)
    {
        if (!evadeBlockers.Contains(p_sourceName))
            evadeBlockers.Add(p_sourceName);
    }

    public void RemoveEvadeBlock(string p_sourceName)
    {
        evadeBlockers.Remove(p_sourceName);
    }

    public bool EvadeEnabled()
    {
        return evadeBlockers.Count == 0;
    }

    public bool IsEvading()
    {
        return isEvading;
    }

    public void SetGodModeActive(bool p_active = true)
    {
        if (!p_active)
            RemoveEvadeBlock("Evade_GodMode");
        else
            CancelEvade();

        GodModeOn = p_active;
    }
}
