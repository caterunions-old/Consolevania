using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class StatusEffect
    {
        public static StatusEffect Poison = new StatusEffect("Poisoned", "", ActivationType.OnTurnEnd, 3, ConsoleColor.Green);
        public static StatusEffect Regeneration = new StatusEffect("Regenerating", "", ActivationType.OnTurnEnd, 5, ConsoleColor.Magenta);
        public static StatusEffect Blessing = new StatusEffect("Blessed", "", ActivationType.OnTurnEnd, 5, ConsoleColor.Yellow);

        public string Name { get; }
        public string Description { get; }
        public ActivationType ActivationType { get; }
        public ConsoleColor Color { get; }
        public int Duration { get; set; }

        public StatusEffect(string name, string description, ActivationType activationType, int duration, ConsoleColor color)
        {
            Name = name;
            Description = description;
            ActivationType = activationType;
            Duration = duration;
            Color = color;
        }
        public StatusEffect Clone()
        {
            return (StatusEffect)MemberwiseClone();
        }

        public void PoisonTick(Hero hero)
        {
            Thread.Sleep(1000);
            Duration--;
            int damage = Convert.ToInt32((hero.MaxHp / 20) + 1);
            hero.TakeDamage(damage, true);
            WriteLine($"{hero.Name} takes {damage} damage from poison!");
        }
        public void PoisonTick(Enemy enemy)
        {
            Thread.Sleep(1000);
            Duration--;
            int damage = Convert.ToInt32((enemy.MaxHp / 10) + 1);
            enemy.TakeDamage(damage, true);
            WriteLine($"{enemy.Name} takes {damage} damage from poison!");
        }
        public void RegenerationTick(Hero hero)
        {
            Thread.Sleep(1000);
            Duration--;
            int regen = Convert.ToInt32(hero.MaxHp / 10);
            hero.Heal(regen);
            WriteLine($"{hero.Name} regenerated {regen} HP!");
        }
        public void RegenerationTick(Enemy enemy)
        {
            Thread.Sleep(1000);
            Duration--;
            int regen = Convert.ToInt32(enemy.MaxHp / 20);
            enemy.Heal(regen);
            WriteLine($"{enemy.Name} regenerated {regen} HP!");
        }
        public void BlessingAquire(Hero hero)
        {
            Thread.Sleep(1000);
            int attackBuff = 6;
            hero.BaseDamage += attackBuff;
            WriteLine($"{hero.Name}'s attack rose by {attackBuff}!");
        }
        public void BlessingTick(Hero hero)
        {
            Thread.Sleep(1000);
            Duration--;
            int regen = 3;
            hero.Heal(regen);
            WriteLine($"{hero.Name} regenerated {regen} HP!");
            if(Duration == 0)
            {
                Thread.Sleep(1000);
                WriteLine($"{hero.Name}'s blessing ran out!");
                Thread.Sleep(1000);
                int attackBuff = 6;
                hero.BaseDamage -= attackBuff;
                WriteLine($"{hero.Name}'s attack fell by {attackBuff}!");
                hero.StatusEffects.Remove(this);
                Duration--;
            }
        }
        public void BlessingAquire(Enemy enemy)
        {
            Thread.Sleep(1000);
            int attackBuff = 3;
            enemy.BaseDamage += attackBuff;
            WriteLine($"{enemy.Name}'s attack rose by {attackBuff}!");
        }
        public void BlessingTick(Enemy enemy)
        {
            Thread.Sleep(1000);
            Duration--;
            int regen = 2;
            enemy.Heal(regen);
            WriteLine($"{enemy.Name} regenerated {regen} HP!");
            if (Duration == 0)
            {
                Thread.Sleep(1000);
                WriteLine($"{enemy.Name}'s blessing ran out!");
                Thread.Sleep(1000);
                int attackBuff = 3;
                enemy.BaseDamage -= attackBuff;
                WriteLine($"{enemy.Name}'s attack fell by {attackBuff}!");
                enemy.StatusEffects.Remove(this);
                Duration--;
            }
        }
    }
}
