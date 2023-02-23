using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Enemy
    {
        public string Name { get; set; }
        public string Description { get; }
        public int BaseDamage { get; set; }
        public List<Ability> Abilities { get; }
        public int Defense { get; set; }
        public int MaxHp { get; }
        public int Hp { get; set; }
        public int XpValue { get; set; }
        public int GoldValue { get; set; }
        public List<StatusEffect> StatusEffects { get; set; } = new List<StatusEffect>();
        public bool IsBoss { get; } = false;
        public ConsoleColor HealthStatus { get; set; } = ConsoleColor.Green;

        public Enemy(string name, string description, int baseDamage, List<Ability> abilities, int defense, int hp, int xp, int gold)
        {
            Name = name;
            Description = description;
            BaseDamage = Convert.ToInt32(baseDamage + new Random().Next(baseDamage / 4));
            Abilities = abilities;
            Defense = defense;
            MaxHp = Convert.ToInt32(hp + new Random().Next(hp / 4));
            Hp = MaxHp;
            XpValue = xp;
            GoldValue = gold;
        }

        public Enemy Clone()
        {
            Enemy clone = (Enemy)MemberwiseClone();
            clone.StatusEffects = new List<StatusEffect>();
            return clone;
        }

        public void UpdateHealthStatus()
        {
            float hpPercent = (float)Hp / (float)MaxHp * 100f;
            if(hpPercent > 75)
            {
                HealthStatus = ConsoleColor.Green;
            } 
            else if (hpPercent > 50)
            {
                HealthStatus = ConsoleColor.DarkYellow;
            }
            else if (hpPercent > 25)
            {
                HealthStatus = ConsoleColor.Yellow;
            } 
            else
            {
                HealthStatus = ConsoleColor.Red;
            }
        }

        public int TakeDamage(int damage)
        {
            damage -= Defense;
            damage = Math.Clamp(damage, 1, MaxHp);
            Hp -= damage;
            UpdateHealthStatus();
            return damage;
        }
        public int TakeDamage(int damage, bool ignoresArmor)
        {
            if (!ignoresArmor)
            {
                damage -= Defense;
                damage = Math.Clamp(damage, 1, MaxHp);
            }
            Hp -= damage;
            UpdateHealthStatus();
            return damage;
        }
        public int Heal(int heal)
        {
            Hp = Math.Clamp(Hp + heal, 0, MaxHp);
            return heal;
        }

        public void Attack(Hero target)
        {
            WriteLine($"{Name} attacks {target.Name}!");
            Thread.Sleep(1000);
            if (new Random().Next(100) < target.DodgeChance)
            {
                WriteLine("Dodged!");
            }
            else
            {
                int damage = BaseDamage + new Random().Next(BaseDamage / 4);
                WriteLine($"{target.TakeDamage(damage)} Damage dealt!");
            }
            ResetColor();
        }
    }
}
