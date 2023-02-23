using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Combat
    {
        public Hero Hero { get; }
        public List<Enemy> Enemies { get; set; }

        public Combat(Hero hero, List<Enemy> enemies)
        {
            Hero = hero;
            Enemies = enemies;
        }

        public void CalculateDeaths()
        {
            foreach(Enemy enemy in Enemies.ToList())
            {
                if(enemy.Hp <= 0)
                {
                    WriteLine($"{enemy.Name} was defeated!");
                    Game.Hero!.Experience += enemy.XpValue;
                    Game.Hero.Gold += enemy.GoldValue;
                    WriteLine($"Earned {enemy.XpValue} XP and {enemy.GoldValue} ⓪");
                    if(new Random().Next(4) == 0)
                    {
                        int dropType = new Random().Next(11);
                        if(dropType == 0 && Hero.Area.WeaponDrops.Count > 0)
                        {
                            Weapon weapon = Hero.Area.GetWeaponDrop();
                            WriteLine($"{enemy.Name} dropped {weapon.Name}!");
                            Hero.GainWeapon(weapon);
                        } else if (dropType == 1 && Hero.Area.ArmorDrops.Count > 0)
                        {
                            Armor armor = Hero.Area.GetArmorDrop();
                            WriteLine($"{enemy.Name} dropped {armor.Name}!");
                            Hero.GainArmor(armor);
                        } else
                        {
                            Item item = Hero.Area.GetItemDrop();
                            WriteLine($"{enemy.Name} dropped {item.Name}!");
                            Hero.GainItem(item);
                        }
                    }
                    Enemies.Remove(enemy);
                    if(Hero.Experience >= Hero.XpToNextLevel)
                    {
                        Hero.LevelUp();
                    }
                }
            }
        }

        public void EnemyTurn()
        {
            foreach(Enemy enemy in Enemies)
            {
                Thread.Sleep(1000);
                if(new Random().Next(3) != 0 && enemy.Abilities.Count > 0)
                {
                    Ability enemyAbility = enemy.Abilities[new Random().Next(enemy.Abilities.Count)];
                    WriteLine($"{enemy.Name} uses {enemyAbility.Name}!");
                    enemyAbility.Activate();
                } else
                {
                    enemy.Attack(Game.Hero!);
                }
                if(Hero.Hp <= 0)
                {
                    WriteLine($"{Hero.Name} has died!");
                    break;
                }
            }
            if(Hero.Hp > 0)
            {
                foreach (StatusEffect heroEffect in Hero.StatusEffects.ToList())
                {
                    if (heroEffect.Duration <= 0)
                    {
                        Hero.StatusEffects.Remove(heroEffect);
                    }
                    else if (heroEffect.ActivationType == ActivationType.OnTurnEnd)
                    {
                        if (heroEffect.Name == "Poisoned")
                        {
                            heroEffect.PoisonTick(Hero);
                        }
                        else if (heroEffect.Name == "Regenerating")
                        {
                            heroEffect.RegenerationTick(Hero);
                        }
                        else if (heroEffect.Name == "Blessed")
                        {
                            heroEffect.BlessingTick(Hero);
                        }
                    }
                }
                foreach (Enemy enemy in Enemies)
                {
                    foreach (StatusEffect enemyEffect in enemy.StatusEffects.ToList())
                    {
                        if (enemyEffect.Duration <= 0)
                        {
                            enemy.StatusEffects.Remove(enemyEffect);
                        }
                        else if (enemyEffect.ActivationType == ActivationType.OnTurnEnd)
                        {
                            if (enemyEffect.Name == "Poisoned")
                            {
                                enemyEffect.PoisonTick(enemy);
                            }
                            else if (enemyEffect.Name == "Regenerating")
                            {
                                enemyEffect.RegenerationTick(enemy);
                            }
                            else if (enemyEffect.Name == "Blessed")
                            {
                                enemyEffect.BlessingTick(Hero);
                            }
                        }
                    }
                }
            }
        }
    }
}
