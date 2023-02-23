using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Menu
    {
        public static Dictionary<string, string> AreaOptions = new Dictionary<string, string>()
        {
            { "Fight", "Fight an enemy in this area." },
            { "Travel", "Travel to another area." },
            { "Town", "Travel to this area's town." },
            { "Inventory", "View your inventory." },
            { "View Stats", $"View {Game.Hero!.Name}'s stats." },
            { "Equip Weapon", "Equip a different weapon." },
            { "Equip Armor", "Equip different armor." },
            { "Skill Points", "Spend Skill Points on stats, new skills or abilities." },
            { "Collection", "View completion stats." }
        };

        public static Dictionary<string, string> TownOptions = new Dictionary<string, string>()
        {
            { "Shop", "Visit the town's shop." },
        };

        public static Dictionary<string, string> TurnOptions = new Dictionary<string, string>()
        {
            { "Attack", "Attack an enemy with your equipped weapon." },
            { "Ability", "Use an ability at the cost of SP." },
            { "Item", "Use an item." },
            { "Run", "Attempt to escape the combat." }
        };
        public static Dictionary<string, string> SkillPointOptions = new Dictionary<string, string>()
        {
            { "Stat Boost", "Spend a Skill Point to boost a stat." },
            { "Unlock Skill", "Spend Skill Points to unlock permanent skills." },
            { "Unlock Ability", "Spend Skill Points to unlock new abilities to use in combat." }
        };
        public static Dictionary<string, string> BoostStatOptions = new Dictionary<string, string>()
        {
            { "Boost HP", "Increase max HP by 5" },
            { "Boost SP", "Increase max SP by 3" },
            { "Boost Damage", "Increase base damage by 1" },
            { "Boost Crit", "Increase crit chance by 1%" }
        };
        public Menu()
        {

        }

        public void DisplayClassSelectionMenu(int index = 0)
        {
            for (int i = 0; i < Game.Classes.Length; i++)
            {
                Class currentClass = Game.Classes[i];
                if (i == index)
                {
                    WriteLine($"\n> {currentClass.Name}\n", ForegroundColor = currentClass.Color);
                }
                else
                {
                    WriteLine($"{currentClass.Name}", ForegroundColor = currentClass.Color);
                }
            }
            WriteLine($"\n{Game.Classes[index].Description}", ForegroundColor = ConsoleColor.White);
            ResetColor();
        }
        public void DisplayAreaMenu(int index = 0)
        {
            int i = 0;
            foreach(KeyValuePair<string, string> kvp in AreaOptions)
            {
                if (i == index)
                {
                    WriteLine($"\n> {kvp.Key}\n", ForegroundColor = ConsoleColor.White);
                }
                else
                {
                    WriteLine($"{kvp.Key}", ForegroundColor = ConsoleColor.DarkGray);
                }
                i++;
            }
            WriteLine($"\n{AreaOptions.ElementAt(index).Value}", ForegroundColor = ConsoleColor.White);
            ResetColor();
        }
        public void DisplayTravelMenu(int index = 0)
        {
            for (int i = 0; i < Game.Areas.Length + 1; i++)
            {
                if(i < Game.Areas.Length)
                {
                    Area area = Game.Areas[i];
                    if(area.LevelRequirement <= Game.Hero!.Level)
                    {
                        if (i == index)
                        {
                            WriteLine($"\n> {area.Name}\n", ForegroundColor = area.Color);
                        }
                        else
                        {
                            WriteLine($"{area.Name}", ForegroundColor = area.Color);
                        }
                    } else
                    {
                        if (i == index)
                        {
                            WriteLine($"\n> {area.Name} (Level {area.LevelRequirement})\n", ForegroundColor = ConsoleColor.DarkGray);
                        }
                        else
                        {
                            WriteLine($"{area.Name} (Level {area.LevelRequirement})", ForegroundColor = ConsoleColor.DarkGray);
                        }
                    }
                } else
                {
                    if(i == index)
                    {
                        WriteLine($"\n> Exit Travel Menu\n", ForegroundColor = ConsoleColor.White);
                    } else
                    {
                        WriteLine($"Exit Travel Menu", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
                
            }
            ResetColor();
        }
        public void DisplayTownMenu(int index = 0)
        {
            Town town = Game.Hero!.Area.Town;
            Dictionary<string, string> curTownOptions = TownOptions;
            curTownOptions.TryAdd($"Tavern ({town.TavernCost} ⓪)", "Rest up at the town's tavern, replenishing your resources for a price.");
            curTownOptions.TryAdd(town.SpecialDescription.Key, town.SpecialDescription.Value);
            curTownOptions.TryAdd("Exit", "Leave the current town.");
            int i = 0;
            foreach (KeyValuePair<string, string> kvp in curTownOptions)
            {
                if (i == index)
                {
                    WriteLine($"\n> {kvp.Key}\n", ForegroundColor = ConsoleColor.White);
                }
                else
                {
                    WriteLine($"{kvp.Key}", ForegroundColor = ConsoleColor.DarkGray);
                }
                i++;
            }
            WriteLine($"\n{curTownOptions.ElementAt(index).Value}", ForegroundColor = ConsoleColor.White);
            ResetColor();
        }
        public void DisplayTurnMenu(int index = 0)
        {
            ConsoleColor[] optionColors = new ConsoleColor[]
            {
                ConsoleColor.Red,
                ConsoleColor.Green,
                ConsoleColor.Yellow,
                ConsoleColor.White
            };
            int i = 0;
            foreach (KeyValuePair<string, string> kvp in TurnOptions)
            {
                if (i == index)
                {
                    WriteLine($"\n> {kvp.Key}\n", ForegroundColor = optionColors[i]);
                }
                else
                {
                    WriteLine($"{kvp.Key}", ForegroundColor = ConsoleColor.DarkGray);
                }
                i++;
            }
            WriteLine($"\n{TurnOptions.ElementAt(index).Value}", ForegroundColor = ConsoleColor.White);
            ResetColor();
        }
        public void DisplayTargetMenu(List<Enemy> targets, int index = 0)
        {
            for(int i = 0; i < targets.Count + 1; i++)
            {
                if(i < targets.Count)
                {
                    if (i == index)
                    {
                        WriteLine($"\n> {targets[i].Name}\n", ForegroundColor = targets[i].HealthStatus);
                    }
                    else
                    {
                        WriteLine($"{targets[i].Name}", ForegroundColor = targets[i].HealthStatus);
                    }
                }
                else
                {
                    if (i == index)
                    {
                        WriteLine($"\n> Back\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"Back", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
            }
            ResetColor();
        }
        public void DisplayAbilityMenu(List<Ability> abilities, int index = 0)
        {
            for (int i = 0; i < abilities.Count + 1; i++)
            {
                if(i < abilities.Count)
                {
                    Ability ability = abilities[i];
                    if (i == index)
                    {
                        WriteLine($"\n> {ability.Name} - {ability.SpCost} SP\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"{ability.Name} - {ability.SpCost} SP", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
                else
                {
                    if (i == index)
                    {
                        WriteLine($"\n> Back\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"Back", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
            }
            if(index < abilities.Count)
            {
                WriteLine($"\n{abilities[index].Description}", ForegroundColor = ConsoleColor.White);
            }
            ResetColor();
        }
        public void DisplayCombatItemMenu(int index = 0)
        {
            Dictionary<Item, int> items = Game.Hero!.ItemInventory;
            int i = 0;
            foreach(KeyValuePair<Item, int> kvp in items)
            {
                if (i == index)
                {
                    WriteLine($"\n> {kvp.Key.Name} ({kvp.Value})\n", ForegroundColor = ConsoleColor.White);
                }
                else
                {
                    WriteLine($"{kvp.Key.Name} ({kvp.Value})", ForegroundColor = ConsoleColor.DarkGray);
                }
                i++;
            }
            if(index == items.Count)
            {
                WriteLine($"\n> Back\n", ForegroundColor = ConsoleColor.White);
            }
            else
            {
                WriteLine($"Back", ForegroundColor = ConsoleColor.DarkGray);
            }
            if(index < items.Count)
            {
                WriteLine($"\n{items.ElementAt(index).Key.Description}", ForegroundColor = ConsoleColor.White);
            }
            ResetColor();
        }
        public void DisplayShopMenu(Shop shop, int index = 0)
        {
            int shopLength = shop.Weapons.Count + shop.Armor.Count + shop.Items.Count;
            for(int i = 0; i < shopLength + 1; i++)
            {
                if(i < shop.Weapons.Count)
                {
                    if (i == index)
                    {
                        WriteLine($"\n> {shop.Weapons.ElementAt(i).Key.Name} ({shop.Weapons.ElementAt(i).Value} ⓪)\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"{shop.Weapons.ElementAt(i).Key.Name} ({shop.Weapons.ElementAt(i).Value} ⓪)", ForegroundColor = ConsoleColor.DarkGray);
                    }
                } 
                else if (i < shop.Weapons.Count + shop.Armor.Count)
                {
                    int armorIndex = i - shop.Weapons.Count;
                    if (i == index)
                    {
                        WriteLine($"\n> {shop.Armor.ElementAt(armorIndex).Key.Name} ({shop.Armor.ElementAt(armorIndex).Value} ⓪)\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"{shop.Armor.ElementAt(armorIndex).Key.Name} ({shop.Armor.ElementAt(armorIndex).Value} ⓪)", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
                else if (i < shopLength)
                {
                    int itemIndex = i - (shop.Weapons.Count + shop.Armor.Count);
                    if (i == index)
                    {
                        WriteLine($"\n> {shop.Items.ElementAt(itemIndex).Key.Name} ({shop.Items.ElementAt(itemIndex).Value} ⓪)\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"{shop.Items.ElementAt(itemIndex).Key.Name} ({shop.Items.ElementAt(itemIndex).Value} ⓪)", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
                else
                {
                    if (index == i)
                    {
                        WriteLine($"\n> Back\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"Back", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
            }
            ResetColor();
            if (index < shop.Weapons.Count)
            {
                WriteLine($"\n{shop.Weapons.ElementAt(index).Key.Description}");
            }
            else if (index < shop.Weapons.Count + shop.Armor.Count)
            {
                WriteLine($"\n{shop.Armor.ElementAt(index - shop.Weapons.Count).Key.Description}");
            }
            else if (index < shopLength)
            {
                WriteLine($"\n{shop.Items.ElementAt(index - (shop.Weapons.Count + shop.Armor.Count)).Key.Description}");
            }
        }
        public void DisplayEquipWeaponMenu(int index = 0)
        {
            Weapon current = Game.Hero!.EquippedWeapon;
            WriteLine($"Current weapon: {current.Name}\n{current.Description}\n", ForegroundColor = ConsoleColor.White);
            List<Weapon> weapons = Game.Hero.WeaponInventory.ToList();
            weapons.Remove(current);
            for(int i = 0; i < weapons.Count + 1; i++)
            {
                if(i < weapons.Count)
                {
                    if (i == index)
                    {
                        WriteLine($"\n> {weapons[i].Name}\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"{weapons[i].Name}", ForegroundColor = ConsoleColor.DarkGray);
                    }
                } 
                else
                {
                    if (index == i)
                    {
                        WriteLine($"\n> Back\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"Back", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
            }
            ResetColor();
            if(index < weapons.Count)
            {
                WriteLine($"\n{weapons[index].Description}");
            }
        }
        public void DisplayEquipArmorMenu(int index = 0)
        {
            Armor current = Game.Hero!.EquippedArmor;
            WriteLine($"Current armor: {current.Name}\n{current.Description}\n", ForegroundColor = ConsoleColor.White);
            List<Armor> armor = Game.Hero.ArmorInventory.ToList();
            armor.Remove(current);
            for (int i = 0; i < armor.Count + 1; i++)
            {
                if (i < armor.Count)
                {
                    if (i == index)
                    {
                        WriteLine($"\n> {armor[i].Name}\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"{armor[i].Name}", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
                else
                {
                    if (index == i)
                    {
                        WriteLine($"\n> Back\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"Back", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
            }
            ResetColor();
            if (index < armor.Count)
            {
                WriteLine($"\n{armor[index].Description}");
            }
        }
        public void DisplaySkillPointMenu(int index = 0)
        {
            for(int i = 0; i < SkillPointOptions.Count + 1; i++)
            {
                if(i < SkillPointOptions.Count)
                {
                    if (i == index)
                    {
                        WriteLine($"\n> {SkillPointOptions.ElementAt(i).Key}\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"{SkillPointOptions.ElementAt(i).Key}", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
                else
                {
                    if (index == i)
                    {
                        WriteLine($"\n> Back\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"Back", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
            }
            if(index < SkillPointOptions.Count)
            {
                WriteLine($"\n{SkillPointOptions.ElementAt(index).Value}", ForegroundColor = ConsoleColor.White);
            }
            ResetColor();
        }
        public void DisplayBoostStatMenu(int index = 0)
        {
            for (int i = 0; i < BoostStatOptions.Count + 1; i++)
            {
                if (i < BoostStatOptions.Count)
                {
                    if (i == index)
                    {
                        WriteLine($"\n> {BoostStatOptions.ElementAt(i).Key}\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"{BoostStatOptions.ElementAt(i).Key}", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
                else
                {
                    if (index == i)
                    {
                        WriteLine($"\n> Back\n", ForegroundColor = ConsoleColor.White);
                    }
                    else
                    {
                        WriteLine($"Back", ForegroundColor = ConsoleColor.DarkGray);
                    }
                }
            }
            if (index < BoostStatOptions.Count)
            {
                WriteLine($"\n{BoostStatOptions.ElementAt(index).Value}", ForegroundColor = ConsoleColor.White);
            }
            ResetColor();
        }
    }
}
