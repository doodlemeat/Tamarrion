using UnityEngine;
using System.Collections;

public class StatsItem : BaseItem {

    public enum EStatType
    {
        Health,
        DamageReduction,
        Armor,
        Damage,
        Physical,
        Magical,
        CritChance,
        CritDamage,
        MultiStrike,
        Cooldown,
        MovementSpeed,
        Count
    };

    public struct ItemStat {
        public float value;
        public bool percentage;
    };

    public float Health = 0;
    public float DamageReduction = 0, Armor = 0;
    //public float AttackSpeed = 0;
    public float BaseDamage = 0, PhysicalDamage = 0, MagicalDamage = 0;
    public float CritChance = 0, CritDamage = 0, Multistrike = 0;
    public float CooldownReduction = 0;
    public float MovementSpeed = 0;

    public ItemStat[] stats = new ItemStat[(int)EStatType.Count];

    void Awake() {
        stats[(int)EStatType.Health].value = Health;
        stats[(int)EStatType.Health].percentage = false;

        stats[(int)EStatType.DamageReduction].value = DamageReduction;
        stats[(int)EStatType.DamageReduction].percentage = true;

        stats[(int)EStatType.Armor].value = Armor;
        stats[(int)EStatType.Armor].percentage = false;

        stats[(int)EStatType.Damage].value = BaseDamage;
        stats[(int)EStatType.Damage].percentage = false;

        stats[(int)EStatType.Physical].value = PhysicalDamage;
        stats[(int)EStatType.Physical].percentage = false;

        stats[(int)EStatType.Magical].value = MagicalDamage;
        stats[(int)EStatType.Magical].percentage = false;

        stats[(int)EStatType.CritChance].value = CritChance;
        stats[(int)EStatType.CritChance].percentage = true;

        stats[(int)EStatType.CritDamage].value = CritDamage;
        stats[(int)EStatType.CritDamage].percentage = true;

        stats[(int)EStatType.MultiStrike].value = Multistrike;
        stats[(int)EStatType.MultiStrike].percentage = true;

        stats[(int)EStatType.Cooldown].value = CooldownReduction;
        stats[(int)EStatType.Cooldown].percentage = true;

        stats[(int)EStatType.MovementSpeed].value = MovementSpeed;
        stats[(int)EStatType.MovementSpeed].percentage = true;
    }
}