using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Item
    {
        public string Name { get; }
        public string Description { get; }
        public Action Action { get; }
        public int Value { get; }

        public Item(string name, string description, Action action, int value)        
        {
            Name = name;
            Description = description;
            Action = action;
            Value = value;
        }

        public void Use()
        {
            Action();
        }

        public static void Apple()
        {
            Thread.Sleep(1000);
            int heal = Game.Hero!.Heal(new Random().Next(8,15));
            if(Game.Hero.CurrentCombat != null)
            {
                WriteLine($"{Game.Hero.Name} healed {heal} HP!");
            }
        }
        public static void ApplePie()
        {
            Thread.Sleep(1000);
            int heal = Game.Hero!.Heal(new Random().Next(26, 31));
            if (Game.Hero.CurrentCombat != null)
            {
                WriteLine($"{Game.Hero.Name} healed {heal} HP!");
            }
        }
        public static void RestorationVial()
        {
            if (Game.Hero!.CurrentCombat != null)
            {
                Game.Hero.StatusEffects.Add(StatusEffect.Regeneration);
            }
        }
        public static void Antidote()
        {
            while(Game.Hero!.StatusEffects.Contains(StatusEffect.Poison))
            {
                Game.Hero.StatusEffects.Remove(StatusEffect.Poison);
            }
        }
        public static void StaminaVial()
        {
            Thread.Sleep(1000);
            int spRestore = Game.Hero!.RestoreSP(new Random().Next(6, 11));
            if (Game.Hero.CurrentCombat != null)
            {
                WriteLine($"{Game.Hero.Name} restored {spRestore} SP!");
            }
        }
    }
}
