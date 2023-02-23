using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Armor
    {
        public string Name { get; }
        public string Description { get; }
        public int Defense { get; set; }
        public HashSet<StatusEffect> Resistances { get; set; } = new HashSet<StatusEffect>();
        public Action? OnDefend { get; } = null;
        public int Value { get; }
        
        public Armor(string name, string description, int defense, int value)
        {
            Name = name;
            Description = description;
            Defense = defense;
            Value = value;
        }
        public Armor(string name, string description, int defense, int value, Action onDefend)
        {
            Name = name;
            Description = description;
            Defense = defense;
            OnDefend = onDefend;
            Value = value;
        }
        public Armor(string name, string description, int defense, int value, HashSet<StatusEffect> resistances)
        {
            Name = name;
            Description = description;
            Defense = defense;
            Resistances = resistances;
            Value = value;
        }
        public Armor(string name, string description, int defense, int value, Action onDefend, HashSet<StatusEffect> resistances)
        {
            Name = name;
            Description = description;
            Defense = defense;
            OnDefend = onDefend;
            Resistances = resistances;
            Value = value;
        }
    }
}
