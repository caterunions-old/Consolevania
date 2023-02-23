using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Class
    {
        public string Name { get; }
        public string Description { get; }
        public ConsoleColor Color { get; }
        public int StartingHp { get; }
        public int StartingSp { get; }
        public Weapon StartingWeapon { get; }
        public int BaseDamage { get; }
        public int BaseDefense { get; }
        public int BaseCritChance { get; }
        public int BaseDodgeChance { get; }
        public WeaponType FavoredWeaponType { get; }
        public Ability StartingAbility { get; }

        public Class(string name, string description, ConsoleColor color, int startingHp, int startingSp, Weapon startingWeapon, int baseDamage,
            int baseDefense, int baseCritChance, int baseDodgeChance, WeaponType favoredWeaponType, Ability startingAbility)
        {
            Name = name;
            Description = description;
            Color = color;
            StartingHp = startingHp;
            StartingSp = startingSp;
            StartingWeapon = startingWeapon;
            BaseDamage = baseDamage;
            BaseDefense = baseDefense;
            BaseCritChance = baseCritChance;
            BaseDodgeChance = baseDodgeChance;
            FavoredWeaponType = favoredWeaponType;
            StartingAbility = startingAbility;
        }
    }
}
