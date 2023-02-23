using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public enum ActivationType
    {
        OnAqcuire,
        OnCombatStart,
        OnCombatEnd,
        OnTurnStart,
        OnTurnEnd,
        OnAttack,
        OnDefend,
        OnKill,
        OnItem
    }
    internal class Skill
    {
        public string Name { get; }
        public string Description { get; }
        public Action Action { get; }
        public ActivationType ActivationType { get; }

        public Skill(string name, string description, Action action, ActivationType activationType)
        {
            Name = name;
            Description = description;
            Action = action;
            ActivationType = activationType;
        }
    }
}
