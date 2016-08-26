using UnityEngine;
using System.Collections.Generic;

public class WingProgressionUndead : WingProgressionBase
{
    public Transform EntrancePos;
    public Transform PreNihtPos;
    public Transform PostNihtPos;
    public Transform PreValacPos;
    public Transform PostValacPos;
    public Encounter nihtEncounter;
    public Encounter valacEncounter;

    protected override void Initialize()
    {
        AddWingProgression("Entrance", EntrancePos, new Dictionary<string, bool>()
        {
            { "NihtAlive", true },
            { "ValacAlive", true }
        });

        AddWingProgression("PreNiht", PreNihtPos, new Dictionary<string, bool>()
        {
            { "NihtAlive", true },
            { "ValacAlive", true }
        });

        AddWingProgression("PostNiht", PostNihtPos, new Dictionary<string, bool>()
        {
            { "NihtAlive", false },
            { "ValacAlive", true }
        });

        AddWingProgression("PreValac", PreValacPos, new Dictionary<string, bool>()
        {
            { "NihtAlive", false },
            { "ValacAlive", true }
        });

        AddWingProgression("PostValac", PostValacPos, new Dictionary<string, bool>()
        {
            { "NihtAlive", false },
            { "ValacAlive", false }
        });
    }

    public override void UpdateWingState()
    {
        Debug.Log("wing state updating");

        if (currentProgression == null)
            return;

        Debug.Log("current progress exists");

        if (currentProgression.WingStates.ContainsKey("NihtAlive") && !currentProgression.WingStates["NihtAlive"] && nihtEncounter)
            nihtEncounter.SetEncounterAsCompelte();
        if (currentProgression.WingStates.ContainsKey("ValacAlive") && !currentProgression.WingStates["ValacAlive"] && valacEncounter)
            valacEncounter.SetEncounterAsCompelte();
    }
}
