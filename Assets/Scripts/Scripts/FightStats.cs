using UnityEngine;
using System.Collections;

public class FightStats : MonoBehaviour
{
    private static float StartTime = 0;
    public static float DamageTaken = 0;
    public static float DamageDealt = 0;
    public static float HealingDone = 0;

    void Start()
    {
        StartTime = 0;
        DamageTaken = 0;
        DamageDealt = 0;
        HealingDone = 0;
    }

    public static void StartTimer()
    {
        StartTime = Time.time;
    }

    public static float GetElapsedTime()
    {
        return (Time.time - StartTime);
    }
}