﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GodManager : MonoBehaviour
{
    public static GodManager Instance;
    public List<God_Base> Gods = new List<God_Base>();
    public God_Base CurrentGod = null;
    public float Timer = 0.0f;

    public float[] currentTributeAmounts = new float[(int)FSSkillElement.FS_Elem_Count];
    public float maxTribute = 100f;
    bool tributeGodChosen = false;
    FSSkillElement chosenGodElement = FSSkillElement.FS_Elem_Count;

    public delegate void GodChosen(FSSkillElement p_element);
    public static event GodChosen onGodChosen;
    public delegate void GodActivated(FSSkillElement p_element);
    public static event GodActivated onGodActivated;
    public delegate void GodDeactivated(FSSkillElement p_element);
    public static event GodDeactivated onGodDeactivated;
    public delegate void TributeGained(FSSkillElement p_element, float p_amount);
    public static event TributeGained onTributeGain;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (tributeGodChosen && !CurrentGod)
        {
            fetchGod(chosenGodElement);
        }

        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.KeypadDivide))
                AddTribute(FSSkillElement.FS_Elem_Holy, 20f);
            if (Input.GetKeyDown(KeyCode.KeypadMultiply))
                AddTribute(FSSkillElement.FS_Elem_Magic, 20f);
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
                AddTribute(FSSkillElement.FS_Elem_Nature, 20f);
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
                AddTribute(FSSkillElement.FS_Elem_War, 20f);
        }

        if (CurrentGod)
        {
            if (Timer <= 0.0f)
            {
                Timer = 0.0f;

                if (onGodDeactivated != null)
                    onGodDeactivated(CurrentGod.element);
                tributeGodChosen = false;
                chosenGodElement = FSSkillElement.FS_Elem_Count;

                CurrentGod.Deactivate();
                Destroy(CurrentGod);
                CurrentGod = null;
            }
            else
            {
                Timer -= Time.deltaTime;
            }
        }
    }

    public void deactivate_current_god() {
        if (onGodDeactivated != null)
            onGodDeactivated(CurrentGod.element);
        tributeGodChosen = false;
        chosenGodElement = FSSkillElement.FS_Elem_Count;

        CurrentGod.Deactivate();
        Destroy(CurrentGod);
        CurrentGod = null;
    }

    public bool fetchGod(FSSkillElement p_element)
    {
        List<God_Base> available_gods = new List<God_Base>();

        foreach (God_Base god in Gods)
        {
            if (god.element == p_element)
            {
                available_gods.Add(god);
            }
        }

        for (int i = 0; i < currentTributeAmounts.Length; ++i)
        {
            currentTributeAmounts[i] = 0;
        }

        if (available_gods.Count == 0)
        {
            Debug.Log("There is no god with spelltype: " + p_element);
            return false;
        }

        int randomGodIndex = Random.Range(0, available_gods.Count - 1);
        God_Base selectedGod = available_gods[randomGodIndex];

        CurrentGod = Instantiate(selectedGod);
        CurrentGod.transform.SetParent(transform);

        Timer = CurrentGod.Time;
        if (ComboHelpText.instance && CurrentGod)
        {
            ComboHelpText.instance.SpawnText(CurrentGod.ActiveEffectName() + "\n(" + CurrentGod.ThreeWordDescription() + ")", CurrentGod.element);
            ComboHelpText.instance.SetStaticText(CurrentGod.ThreeWordDescription(), CurrentGod.element);
        }

        if (onGodActivated != null)
            onGodActivated(CurrentGod.element);

        return true;
    }

    public void AddTribute(FSSkillElement p_element, float p_amount)
    {
        if (!tributeGodChosen)
        {
            float diffToMax = maxTribute - currentTributeAmounts[(int)p_element];
            if (p_amount > diffToMax)
                p_amount = diffToMax;

            if (p_amount > 0)
            {
                currentTributeAmounts[(int)p_element] += p_amount;
                if (currentTributeAmounts[(int)p_element] >= maxTribute)
                {
                    tributeGodChosen = true;
                    chosenGodElement = p_element;
                    if (onGodChosen != null)
                        onGodChosen(p_element);
                }
                if (onTributeGain != null)
                    onTributeGain(p_element, p_amount);
            }
        }
    }

    public float GetPercentDone()
    {
        if (CurrentGod)
        {
            if (Timer < 0)
                Timer = 0;
            return Timer / CurrentGod.Time;
        }
        return 0;
    }

    public God_Base GetGodByType(FSSkillElement p_element)
    {
        foreach (God_Base god in Gods)
        {
            if (god.element == p_element)
                return god;
        }

        return null;
    }
}