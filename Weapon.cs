using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPG
{
    public enum WeaponType
    {
        Medium,
        Heavy,
        Light,
        Ranged,
        Magic
    }
    internal class Weapon
    {
        public string Name { get; }
        public string Description { get; }
        public int Damage { get; set; }
        public List<StatusEffect> Effects { get; set; } = new List<StatusEffect>();
        public WeaponType Type { get; }
        public Action? OnAttack { get; } = null;
        public int Accuracy { get; }
        public int ExtraCrit { get; }
        public int Value { get; }

        public Weapon(string name, string description, int damage, WeaponType type, int accuracy, int extraCrit, int value)
        {
            Name = name;
            Description = description;
            Damage = damage;
            Type = type;
            Accuracy = accuracy;
            ExtraCrit = extraCrit;
            Value = value;
        }
        public Weapon(string name, string description, int damage, WeaponType type, int accuracy, int extraCrit, int value, Action onAttack)
        {
            Name = name;
            Description = description;
            Damage = damage;
            Type = type;
            Accuracy = accuracy;
            ExtraCrit = extraCrit;
            OnAttack = onAttack;
            Value = value;
        }
        public Weapon(string name, string description, int damage, WeaponType type, int accuracy, int extraCrit, int value, List<StatusEffect> effects)
        {
            Name = name;
            Description = description;
            Damage = damage;
            Type = type;
            Accuracy = accuracy;
            ExtraCrit = extraCrit;
            Effects = effects;
            Value = value;
        }
        public Weapon(string name, string description, int damage, WeaponType type, int accuracy, int extraCrit, int value, Action onAttack, List<StatusEffect> effects)
        {
            Name = name;
            Description = description;
            Damage = damage;
            Type = type;
            Accuracy = accuracy;
            ExtraCrit = extraCrit;
            OnAttack = onAttack;
            Effects = effects;
            Value = value;
        }
    }
}
