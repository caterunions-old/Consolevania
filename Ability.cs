using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Ability
    {
        // Enemy abilities
        public static Ability Stampede = new Ability("Stampede", "", 0, StampedeAction);
        public static Ability Pilfer = new Ability("Pilfer", "", 0, PilferAction);
        public static Ability Bash = new Ability("Bash", "", 0, BashAction);
        public static Ability ForestLight = new Ability("Forest Light", "", 0, ForestLightAction);
        public static Ability PoisonousBite = new Ability("Poisonous Bite", "", 0, PoisonousBiteAction);
        public static Ability NymphBlessing = new Ability("Nymph's Blessing", "", 0, NymphBlessingAction);

        // Player abilities
        public static Ability SpinAttack = new Ability("Blade Spin", "Deal damage to all enemies in combat. Ignores defense.", 3, SpinAttackAction);
        public static Ability ShadowStrike = new Ability("Shadow Strike", "Low chance to deal massive damage to the strongest enemy.", 4, ShadowStrikeAction);
        public static Ability MagicMissile = new Ability("Magic Missile", "Fire 3-5 magic blasts at random enemies. Ignores defense.", 3, MagicMissileAction);
        public static Ability TippedShot = new Ability("Tipped Shot", "Shoot a poisonous arrow at the strongest enemy. Lasts 3 turns.", 5, TippedShotAction);
        public static Ability Bless = new Ability("Bless", "Gain a blessing that boosts attack and regenerates health. Lasts 5 turns.", 9, BlessAction);

        public string Name { get; }
        public string Description { get; }
        public int SpCost { get; }
        public Action Action { get; }

        public Ability(string name, string description, int spCost, Action action)
        {
            Name = name;
            Description = description;
            SpCost = spCost;
            Action = action;
        }

        public void Activate()
        {
            Action();
        }

        // Enemy ability actions
        private static void StampedeAction()
        {
            for(int i = 0; i < 3; i++)
            {
                if(new Random().Next(2) == 0)
                {
                    Thread.Sleep(1000);
                    int damage = Game.Hero!.TakeDamage(new Random().Next(3, 6), true);
                    WriteLine($"{damage} Damage dealt!");
                }
            }
        }
        private static void PilferAction()
        {
            Thread.Sleep(1000);
            if (new Random().Next(4) == 0)
            {
                int pilfered = new Random().Next(2, 5);
                Game.Hero!.Gold = Math.Clamp(Game.Hero.Gold - pilfered, 0, int.MaxValue);
                WriteLine($"Stole {pilfered} Gold!");
            } else
            {
                WriteLine("But it failed!");
            }
        }
        private static void BashAction()
        {
            Thread.Sleep(1000);
            if (new Random().Next(3) == 0)
            {
                int damage = new Random().Next(8, 12);
                WriteLine($"{damage} Damage dealt!");
                Game.Hero!.TakeDamage(damage, true);
            }
            else
            {
                WriteLine("But it failed!");
            }
        }
        private static void ForestLightAction()
        {
            Thread.Sleep(1000);
            if(new Random().Next(2) == 0)
            {
                Combat? combat = Game.Hero!.CurrentCombat;
                if (combat != null)
                {
                    List<Enemy> enemies = combat.Enemies;
                    int heal = new Random().Next(5, 9);
                    foreach (Enemy enemy in enemies)
                    {
                        enemy.Heal(heal);
                    }
                    WriteLine($"All enemies healed {heal} HP!");
                }
            } else
            {
                WriteLine("But it failed!");
            }
        }
        private static void PoisonousBiteAction()
        {
            Thread.Sleep(1000);
            if (new Random().Next(3) == 0)
            {
                int damage = Game.Hero!.TakeDamage(new Random().Next(5, 9)); ;
                WriteLine($"{Game.Hero.Name} took {damage} damage and was poisoned!");
                Game.Hero.StatusEffects.Add(StatusEffect.Poison);
            }
            else
            {
                WriteLine("But it failed!");
            }
        }
        private static void NymphBlessingAction()
        {
            Thread.Sleep(1000);
            Combat? combat = Game.Hero!.CurrentCombat;
            if (combat != null)
            {
                List<Enemy> enemies = combat.Enemies;
                Enemy target = enemies[new Random().Next(enemies.Count)];
                WriteLine($"{target.Name} was blessed!");
                StatusEffect.Blessing.BlessingAquire(target);
                target.StatusEffects.Add(StatusEffect.Blessing);
            }
        }

        // Player ability actions
        private static void SpinAttackAction()
        {
            Thread.Sleep(1000);
            Combat? combat = Game.Hero!.CurrentCombat;
            if(combat != null)
            {
                List<Enemy> enemies = combat.Enemies;
                int damage = Convert.ToInt32(Game.Hero.BaseDamage + new Random().Next(Game.Hero.BaseDamage / 3));
                foreach(Enemy enemy in enemies)
                {
                    enemy.TakeDamage(damage, true);
                }
                WriteLine($"{damage} Damage dealt to all enemies!");
            }
        }
        private static void ShadowStrikeAction()
        {
            Thread.Sleep(1000);
            Combat? combat = Game.Hero!.CurrentCombat;
            if (combat != null)
            {
                List<Enemy> enemies = combat.Enemies;
                Enemy? strongest = null;
                int curHighest = 0;
                foreach(Enemy enemy in enemies)
                {
                    if(enemy.Hp > curHighest)
                    {
                        curHighest = enemy.Hp;
                        strongest = enemy;
                    }
                }
                if(new Random().Next(4) == 0)
                {
                    int damage = strongest!.TakeDamage((Game.Hero.BaseDamage + Game.Hero.EquippedWeapon.Damage) * 5);
                    WriteLine($"{strongest.Name} took {damage} damage!");
                } else
                {
                    strongest!.TakeDamage(1);
                    WriteLine($"{strongest.Name} took 1 damage.");
                }
            }
        }
        private static void MagicMissileAction()
        {
            Combat? combat = Game.Hero!.CurrentCombat;
            if (combat != null)
            {
                List<Enemy> enemies = combat.Enemies;
                int missiles = new Random().Next(3, 6);
                for(int i = 0; i < missiles; i++)
                {
                    Thread.Sleep(1000);
                    Enemy target = enemies[new Random().Next(enemies.Count)];
                    int damage = Convert.ToInt32(Game.Hero.BaseDamage / 2 + new Random().Next(Game.Hero.BaseDamage / 2));
                    target.TakeDamage(damage, true);
                    WriteLine($"{target.Name} took {damage} damage!");
                }
            }
        }
        private static void TippedShotAction()
        {
            Thread.Sleep(1000);
            Combat? combat = Game.Hero?.CurrentCombat;
            if (combat != null)
            {
                List<Enemy> enemies = combat.Enemies;
                Enemy? strongest = null;
                int curHighest = 0;
                foreach (Enemy enemy in enemies)
                {
                    if (enemy.Hp > curHighest)
                    {
                        curHighest = enemy.Hp;
                        strongest = enemy;
                    }
                }
                int damage = strongest!.TakeDamage(Game.Hero!.BaseDamage + Game.Hero.EquippedWeapon.Damage);
                StatusEffect poison = StatusEffect.Poison.Clone();
                strongest.StatusEffects.Add(poison);
                WriteLine($"{strongest.Name} took {damage} damage and was poisoned!");
            }
        }
        private static void BlessAction()
        {
            Thread.Sleep(1000);
            WriteLine($"{Game.Hero!.Name} was blessed!");
            StatusEffect.Blessing.BlessingAquire(Game.Hero);
            Game.Hero.StatusEffects.Add(StatusEffect.Blessing);
        }
    }
}
