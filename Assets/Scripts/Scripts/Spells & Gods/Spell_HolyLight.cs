using UnityEngine;
using System.Collections;

public class Spell_HolyLight : SpellBase
{
    public float minHealAmount = 15;
    public float maxHealAmount = 25;

    public override void use()
    {
        base.use();
        _playerStats.HealFlat(Random.Range(minHealAmount, maxHealAmount));
    }
}