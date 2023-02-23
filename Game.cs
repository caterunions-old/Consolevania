using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPG
{
    internal class Game
    {
        public static Armor StarterArmor = new Armor("Faded Leathers", "1 Defense", 1, 0);

        public static Weapon DevSword = new Weapon("Developer Sword", "look at you go", 9999, WeaponType.Medium, 100, 100, 0);

        public static List<Weapon> Tier1Weapons = new List<Weapon>
        {
            new Weapon("Dull Broadsword", "Type: Medium\nDamage: 7", 7, WeaponType.Medium, 85, 0, 5),
            new Weapon("Copper Shortsword", "Type: Light\nDamage: 8\n+ 5% Crit", 8, WeaponType.Light, 90, 5, 4),
            new Weapon("Gnarled Staff", "Type: Magic\nDamage: 8", 8, WeaponType.Magic, 75, 0, 5),
            new Weapon("Old Bow", "Type: Ranged\nDamage: 8\n+ 5% Crit", 8, WeaponType.Ranged, 80, 5, 6),
            new Weapon("Unwieldy Mace", "Type: Heavy\nDamage: 10", 10, WeaponType.Heavy, 65, 0, 3),
            new Weapon("Battleaxe", "Type: Medium\nDamage: 17", 17, WeaponType.Medium, 95, 0, 19),
            new Weapon("Steel Dagger", "Type: Light\nDamage: 10\n+ 15% Crit", 10, WeaponType.Light, 90, 15, 14),
            new Weapon("Water Bolt", "Type: Magic\nDamage: 12", 12, WeaponType.Magic, 80, 0, 28),
            new Weapon("Hunter's Crossbow", "Type: Ranged\nDamage: 15\n+ 10% Crit", 15, WeaponType.Ranged, 90, 10, 21),
            new Weapon("Bronze Claymore", "Type: Heavy\nDamage: 18", 18, WeaponType.Heavy, 75, 0, 18),
            new Weapon("Venomous Shiv", "Type: Light\nDamage: 15\n+ 10% Crit\nApplies Poison on hit.", 15, WeaponType.Light, 90, 10, 38, new List<StatusEffect>() { StatusEffect.Poison } ),
        };

        public static Class[] Classes = new Class[5]
{
            new Class("Warrior", "Warriors specialize in survivability and dealing damage without needing resources.\n\nFavored weapon type: Medium\n+ Defense\n+ Attack\n- SP", ConsoleColor.Red, 40, 10, Tier1Weapons[0], 6, 3, 5, 0, WeaponType.Medium, Ability.SpinAttack),
            new Class("Rogue", "Rogues specialize in quickly taking town big targets with high damage strikes and evading enemy attacks.\n\nFavored weapon type: Light\n+ Crit chance\n+ Dodge chance\n- Defense", ConsoleColor.Gray, 36, 20, Tier1Weapons[1], 5, 1, 15, 10, WeaponType.Light, Ability.ShadowStrike),
            new Class("Mage", "Mages specialize in using SP to deal devestating damage to enemies.\n\nFavored weapon type: Magic\n+ SP\n+ Attack\n- Defense\n- HP", ConsoleColor.Blue, 30, 35, Tier1Weapons[2], 8, 1, 10, 0, WeaponType.Magic, Ability.MagicMissile),
            new Class("Ranger", "Rangers specialize in disabling their targets with a variety of negative effects, and landing large attacks on the strongest enemies.\n\nFavored weapon type: Ranged\n+ Well-rounded", ConsoleColor.Green, 38, 20, Tier1Weapons[3], 5, 2, 5, 5, WeaponType.Ranged, Ability.TippedShot),
            new Class("Paladin", "Paladins specialize in absorbing large amounts of damage and giving positive effects to themselves.\n\nFavored weapon type: Heavy\n+ HP\n+ Defense\n- Accuracy\n- Crit chance", ConsoleColor.Yellow, 44, 15, Tier1Weapons[4], 5, 2, -10, 0, WeaponType.Heavy, Ability.Bless),
            //to enable: uncomment and increase the size of the array
            //new Class("Developer", "For cheaters only.", ConsoleColor.White, 9999, 9999, DevSword, 9999, 0, 100, 0, WeaponType.Medium, Ability.SpinAttack)
        };

        public static List<Armor> Tier1Armor = new List<Armor>
        {
            new Armor("Padded Leather", "2 Defense", 2, 8),
            new Armor("Rusty Chainmail", "3 Defense", 3, 13),
            new Armor("Studded Leather", "4 Defense", 4, 26),
            new Armor("Polished Platemail", "5 Defense", 5, 36)
        };

        public static List<Item> Tier1Items = new List<Item>
        {
            new Item("Apple", "Heals 8-14 HP.", Item.Apple, 2),
            new Item("Apple Pie", "Heals 26-30 HP.", Item.ApplePie, 6),
            new Item("Restoration Vial", "Gives Regeneration for 5 turns.", Item.RestorationVial, 8),
            new Item("Antidote", "Cures poison.", Item.Antidote, 4),
            new Item("Stamina Vial", "Restores 6-10 SP.", Item.StaminaVial, 5)
        };

        public static List<Enemy> Tier1Enemies = new List<Enemy>
        {
            new Enemy("Sly Goblin", "", 6, new List<Ability>() { Ability.Pilfer }, 2, 19, 5, 3),
            new Enemy("Dire Boar", "", 7, new List<Ability>() { Ability.Stampede }, 5, 28, 8, 4),
            new Enemy("Suspicious Troll", "", 8, new List<Ability>() { Ability.Bash }, 4, 23, 9, 5),
            new Enemy("Angry Nymph", "", 5, new List<Ability>() { Ability.ForestLight, Ability.Pilfer, Ability.NymphBlessing }, 1, 13, 6, 4),
            new Enemy("Forest Spider", "", 6, new List<Ability>() { Ability.PoisonousBite }, 3, 16, 7, 4),
            new Enemy("Will-O'-Wisp", "", 4, new List<Ability>() { Ability.ForestLight }, 0, 12, 5, 4),
            new Enemy("Diseased Rat", "", 3, new List<Ability>() { Ability.PoisonousBite }, 1, 8, 3, 3),
            new Enemy("Resentful Snake", "", 6, new List<Ability>() { Ability.PoisonousBite }, 1, 6, 4, 4)
        };

        public static Enemy Tier1Boss = new Enemy("boss", "", 0, new List<Ability>(), 0, 0, 0, 0);

        public static Shop[] Shops = new Shop[]
        {
            // tier 1 shop
            new Shop(
                    new Dictionary<Weapon, int>
                    {
                        { Tier1Weapons[0], 0 }
                    },
                    new Dictionary<Armor, int>
                    {
                        { Tier1Armor[0], 0 }
                    },
                    new Dictionary<Item, int>
                    {
                        { Tier1Items[0], 0 }
                    }
                )
        };

        public static Town[] Towns = new Town[]
        {
            new Town(Shops[0], Town.WishingWell, 10, 1, new List<string> { "" }, new KeyValuePair<string, string>( "Wishing Well (1 ⓪)", "Toss a coin into the well for good luck!" ))
        };

        public static Area[] Areas = new Area[]
        {
            new Area("Verdant Forest", Towns[0], Tier1Enemies, Tier1Weapons, Tier1Armor, Tier1Items, 1, Tier1Boss, ConsoleColor.Green),
            new Area("Dank Caverns", Towns[0], Tier1Enemies, Tier1Weapons, Tier1Armor, Tier1Items, 10, Tier1Boss, ConsoleColor.Gray),
            new Area("Glacial Peaks", Towns[0], Tier1Enemies, Tier1Weapons, Tier1Armor, Tier1Items, 25, Tier1Boss, ConsoleColor.Cyan),
            new Area("Volcanic Cauldron", Towns[0], Tier1Enemies, Tier1Weapons, Tier1Armor, Tier1Items, 50, Tier1Boss, ConsoleColor.DarkRed),
            new Area("Endless Void", Towns[0], Tier1Enemies, Tier1Weapons, Tier1Armor, Tier1Items, 90, Tier1Boss, ConsoleColor.DarkMagenta)
        };
        public static Hero? Hero { get; set; }
        public Game()
        {

        }
        public void PrintTitle()
        {
            string titleSegment1 = "\n\n" +
            "        ▄████████  ▄██████▄   ███▄▄▄▄      ▄████████  ▄██████▄   ▄█          ▄████████  ▄█    █▄     ▄████████ ███▄▄▄▄    ▄█     ▄████████\n" +
            "        ███    ███ ███    ███ ███▀▀▀██▄   ███    ███ ███    ███ ███         ███    ███ ███    ███   ███    ███ ███▀▀▀██▄ ███    ███    ███";

            string titleSegment2 =
            "        ███    █▀  ███    ███ ███   ███   ███    █▀  ███    ███ ███         ███    █▀  ███    ███   ███    ███ ███   ███ ███▌   ███    ███\n" +
            "        ███        ███    ███ ███   ███   ███        ███    ███ ███        ▄███▄▄▄     ███    ███   ███    ███ ███   ███ ███▌   ███    ███";

            string titleSegment3 =
            "        ███        ███    ███ ███   ███ ▀███████████ ███    ███ ███       ▀▀███▀▀▀     ███    ███ ▀███████████ ███   ███ ███▌ ▀███████████\n" +
            "        ███    █▄  ███    ███ ███   ███          ███ ███    ███ ███         ███    █▄  ███    ███   ███    ███ ███   ███ ███    ███    ███";

            string titleSegment4 =
            "        ███    ███ ███    ███ ███   ███    ▄█    ███ ███    ███ ███▌    ▄   ███    ███ ███    ███   ███    ███ ███   ███ ███    ███    ███\n" +
            "        ████████▀   ▀██████▀   ▀█   █▀   ▄████████▀   ▀██████▀  █████▄▄██   ██████████  ▀██████▀    ███    █▀   ▀█   █▀  █▀     ███    █▀\n\n";

            WriteLine(new string('═', WindowWidth));
            ResetColor();
            WriteLine(titleSegment1, ForegroundColor = ConsoleColor.Red);
            WriteLine(titleSegment2, ForegroundColor = ConsoleColor.DarkRed);
            WriteLine(titleSegment3, ForegroundColor = ConsoleColor.Magenta);
            WriteLine(titleSegment4, ForegroundColor = ConsoleColor.DarkMagenta);
            ResetColor();
            WriteLine(new string('═', WindowWidth) + "\n");
        }
        public void PrintPlayerInfo()
        {
            Write(Hero!.Name + $" ({Hero.Class.Name})", ForegroundColor = Hero.Class.Color);
            Write("    ");
            Write($"{Hero.Hp}/{Hero.MaxHp} ♥", ForegroundColor = ConsoleColor.Red);
            Write("    ");
            Write($"{Hero.Sp}/{Hero.MaxSp} ♦", ForegroundColor = ConsoleColor.Green);
            Write("    ");
            Write($"{Hero.GetDefense()} ◊", ForegroundColor = ConsoleColor.DarkGray);
            Write("    ");
            Write($"{Hero.Gold} ⓪", ForegroundColor = ConsoleColor.DarkYellow);
            Write("    ");
            Write($"Level {Hero.Level}", ForegroundColor = ConsoleColor.Cyan);
            Write("    ");
            Write($"{Hero.Experience}/{Hero.XpToNextLevel} XP", ForegroundColor = ConsoleColor.Blue);
            Write("    ");
            Write($"Equipped Weapon: {Hero.EquippedWeapon.Name}", ForegroundColor = ConsoleColor.Gray);
            Write("    ");
            Write($"Equipped Armor: {Hero.EquippedArmor.Name}", ForegroundColor = ConsoleColor.Gray);
            Write("    ");
            Write($"{Hero.LevelPoints} Skill Point(s)", ForegroundColor = ConsoleColor.White);
            if (Hero.StatusEffects.Count > 0)
            {
                ResetColor();
                Write(" [");
                foreach (StatusEffect effect in Hero.StatusEffects)
                {
                    Write($" {effect.Name} ", ForegroundColor = effect.Color);
                    ResetColor();
                }
                Write("]");
            }
            Write("\n");
            ResetColor();
            Write("Current Area: ");
            if(Hero.InTown)
            {
                Write(Hero.Area.Name + " (Town)", ForegroundColor = Hero.Area.Color);
            } else
            {
                Write(Hero.Area.Name, ForegroundColor = Hero.Area.Color);
            }
            ResetColor();
            WriteLine("\n\n" + new string('═', WindowWidth) + "\n");
        }
        public void PrintEnemyInfo(List<Enemy> enemies)
        {
            Write("Fighting:");
            Write("   ");
            foreach(Enemy enemy in enemies)
            {
                Write($"{enemy.Name}", ForegroundColor = enemy.HealthStatus);
                if(enemy.StatusEffects.Count > 0)
                {
                    ResetColor();
                    Write(" [");
                    foreach (StatusEffect effect in enemy.StatusEffects)
                    {
                        Write($" {effect.Name} ", ForegroundColor = effect.Color);
                        ResetColor();
                    }
                    Write("]");
                }
                Write("   ");
            }
            ResetColor();
            WriteLine("\n\n" + new string('═', WindowWidth) + "\n");
        }
        public void NameHero(string error)
        {
            Clear();
            PrintTitle();
            if(!string.IsNullOrEmpty(error))
            {
                WriteLine(error, ForegroundColor = ConsoleColor.Red);
                ResetColor();
            }
            WriteLine("Please name your hero:");
            string name = ReadLine()!;
            if(name.Length > 20)
            {
                NameHero("Name cannot be longer than 20 characters");
            } else if (name.Length == 0)
            {
                NameHero("Name cannot be empty");
            } else
            {
                ChooseClass(name, 0);
            }
        }
        private void ChooseClass(string name, int index)
        {
            Clear();
            PrintTitle();
            WriteLine($"Choose {name}'s class:\n");
            Menu classSelect = new Menu();
            classSelect.DisplayClassSelectionMenu(index);
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (index == 0)
                {
                    index = Classes.Length - 1;
                }
                else if (index > 0)
                {
                    index--;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (index == Classes.Length - 1)
                {
                    index = 0;
                }
                else if (index < Classes.Length - 1)
                {
                    index++;
                }
            }
            if (key != ConsoleKey.Enter)
            {
                ChooseClass(name, index);
            }
            else
            {
                BuildHero(name, Classes[index]);
                AreaMenu();
            }
        }
        private void BuildHero(string name, Class @class)
        {
            Hero = new Hero(
                name, @class.StartingHp, @class.BaseDamage, @class.BaseDefense, @class.StartingWeapon, StarterArmor, @class,
                new List<Weapon> { @class.StartingWeapon }, new List<Armor> { StarterArmor}, new Dictionary<Item, int>() { { Tier1Items[new Random().Next(Tier1Items.Count)], 1 } },
                Areas[0], new HashSet<Skill>(), new List<Ability>() { @class.StartingAbility }, @class.StartingSp, @class.BaseCritChance, @class.BaseDodgeChance);
            if(Hero.Class.Name == "Developer")
            {
                Hero.Level = 100;
            }
            Hero.Area.WeaponDrops.Remove(@class.StartingWeapon);
        }
        private void AreaMenu(int index = 0)
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            Menu area = new Menu();
            area.DisplayAreaMenu(index);
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (index == 0)
                {
                    index = Menu.AreaOptions.Count - 1;
                }
                else if (index > 0)
                {
                    index--;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (index == Menu.AreaOptions.Count - 1)
                {
                    index = 0;
                }
                else if (index < Menu.AreaOptions.Count - 1)
                {
                    index++;
                }
            }
            if (key != ConsoleKey.Enter)
            {
                AreaMenu(index);
            }
            else
            {
                AreaMenuSelection(index);
            }
        }
        private void AreaMenuSelection(int command)
        {
            switch(command)
            {
                case 0:
                    if(Hero!.Area.Name == "Verdant Forest")
                    {
                        CreateEncounter(2, 5);
                    }
                    break;
                case 1:
                    TravelMenu();
                    break;
                case 2:
                    TownMenu();
                    break;
                case 3:
                    ViewInventory();
                    break;
                case 4:
                    ViewStats();
                    break;
                case 5:
                    EquipWeapon();
                    break;
                case 6:
                    EquipArmor();
                    break;
                case 7:
                    SkillPoint();
                    break;
                case 8:
                    ViewCompletion();
                    break;
            }
        }
        private void TravelMenu(int index = 0)
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            Menu travel = new Menu();
            travel.DisplayTravelMenu(index);
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (index == 0)
                {
                    index = Areas.Length;
                }
                else if (index > 0)
                {
                    index--;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (index == Areas.Length)
                {
                    index = 0;
                }
                else if (index < Areas.Length)
                {
                    index++;
                }
            }
            if (key != ConsoleKey.Enter)
            {
                TravelMenu(index);
            }
            else
            {
                TravelMenuSelection(index);
            }
        }
        private void TravelMenuSelection(int command)
        {
            switch(command)
            {
                case 0:
                    Travel(Areas[0], command);
                    break;
                case 1:
                    Travel(Areas[1], command);
                    break;
                case 2:
                    Travel(Areas[2], command);
                    break;
                case 3:
                    Travel(Areas[3], command);
                    break;
                case 4:
                    Travel(Areas[4], command);
                    break;
                case 5:
                    AreaMenu();
                    break;
            }
        }
        private void Travel(Area area, int selection)
        {
            if(Hero!.Level >= area.LevelRequirement)
            {
                Hero.Area = area;
                AreaMenu();
            } else
            {
                TravelMenu(selection);
            }
        }
        private void TownMenu(int index = 0)
        {
            Hero!.InTown = true;
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            Menu town = new Menu();
            town.DisplayTownMenu(index);
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (index == 0)
                {
                    index = 3;
                }
                else if (index > 0)
                {
                    index--;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (index == 3)
                {
                    index = 0;
                }
                else if (index < 3)
                {
                    index++;
                }
            }
            if (key != ConsoleKey.Enter)
            {
                TownMenu(index);
            }
            else
            {
                TownMenuSelection(index);
            }
        }
        private void TownMenuSelection(int command)
        {
            switch(command)
            {
                case 0:
                    ShopMenu();
                    break;
                case 1:
                    if (Hero!.Gold >= Hero.Area.Town.TavernCost)
                    {
                        Clear();
                        PrintTitle();
                        PrintPlayerInfo();
                        Hero.Gold -= Hero.Area.Town.TavernCost;
                        Hero.Hp = Hero.MaxHp;
                        Hero.Sp = Hero.MaxSp;
                        WriteLine("Restored all HP and SP!");
                        WriteLine("> ");
                        ReadKey();
                        TownMenu(command);
                    } else
                    {
                        TownMenu(command);
                    }
                    break;
                case 2:
                    if(Hero!.Gold >= Hero.Area.Town.SpecialCost)
                    {
                        Clear();
                        PrintTitle();
                        PrintPlayerInfo();
                        Hero!.Area.Town.UseSpecial();
                        WriteLine("> ");
                        ReadKey();
                        TownMenu(command);
                    } else
                    {
                        TownMenu(command);
                    }
                    break;
                case 3:
                    Hero!.InTown = false;
                    AreaMenu();
                    break;
            }
        }
        private void ShopMenu(int index = 0)
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            Shop shop = new Shop(
                new Dictionary<Weapon, int>(),
                new Dictionary<Armor, int>(),
                new Dictionary<Item, int>()
            );
            Hero!.Area.RefreshDrops();
            foreach (Weapon weapon in Hero.Area.WeaponDrops)
            {
                shop.Weapons.Add(weapon, weapon.Value);
            }
            foreach(Armor armor in Hero.Area.ArmorDrops)
            {
                shop.Armor.Add(armor, armor.Value);
            }
            foreach(Item item in Hero.Area.ItemDrops)
            {
                shop.Items.Add(item, item.Value);
            }
            int shopLength = shop.Weapons.Count + shop.Armor.Count + shop.Items.Count;
            Menu menu = new Menu();
            menu.DisplayShopMenu(shop, index);
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (index == 0)
                {
                    index = shopLength;
                }
                else if (index > 0)
                {
                    index--;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (index == shopLength)
                {
                    index = 0;
                }
                else if (index < shopLength)
                {
                    index++;
                }
            }
            if (key != ConsoleKey.Enter)
            {
                ShopMenu(index);
            }
            else
            {
                if (index < shop.Weapons.Count)
                {
                    Weapon purchase = shop.Weapons.ElementAt(index).Key;
                    if (Hero.Gold >= purchase.Value)
                    {
                        Hero.Gold -= purchase.Value;
                        Hero.GainWeapon(purchase);
                        Clear();
                        PrintTitle();
                        PrintPlayerInfo();
                        WriteLine($"Purchased {purchase.Name} for {purchase.Value} ⓪.");
                        WriteLine("> ");
                        ReadKey();
                        ShopMenu(index);
                    }
                    else
                    {
                        ShopMenu(index);
                    }
                }
                else if (index < shop.Weapons.Count + shop.Armor.Count)
                {
                    Armor purchase = shop.Armor.ElementAt(index - shop.Weapons.Count).Key;
                    if (Hero.Gold >= purchase.Value)
                    {
                        Hero.Gold -= purchase.Value;
                        Hero.GainArmor(purchase);
                        Clear();
                        PrintTitle();
                        PrintPlayerInfo();
                        WriteLine($"Purchased {purchase.Name} for {purchase.Value} ⓪.");
                        WriteLine("> ");
                        ReadKey();
                        ShopMenu(index);
                    }
                    else
                    {
                        ShopMenu(index);
                    }
                }
                else if (index < shopLength)
                {
                    Item purchase = shop.Items.ElementAt(index - (shop.Weapons.Count + shop.Armor.Count)).Key;
                    if(Hero.Gold >= purchase.Value)
                    {
                        Hero.Gold -= purchase.Value;
                        Hero.GainItem(purchase);
                        Clear();
                        PrintTitle();
                        PrintPlayerInfo();
                        WriteLine($"Purchased {purchase.Name} for {purchase.Value} ⓪.");
                        WriteLine("> ");
                        ReadKey();
                        ShopMenu(index);
                    } else
                    {
                        ShopMenu(index);
                    }
                }
                else
                {
                    TownMenu();
                }
            }
        }
        private void ViewInventory()
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            WriteLine("Inventory:");
            WriteLine("\nWeapons:\n");
            foreach(Weapon weapon in Hero!.WeaponInventory)
            {
                WriteLine(weapon.Name, ForegroundColor = ConsoleColor.DarkGray);
            }
            ResetColor();
            WriteLine("\nArmor:\n");
            foreach (Armor armor in Hero.ArmorInventory)
            {
                WriteLine(armor.Name, ForegroundColor = ConsoleColor.DarkGray);
            }
            ResetColor();
            WriteLine("\nItems:\n");
            foreach (KeyValuePair<Item, int> kvp in Hero.ItemInventory)
            {
                WriteLine($"{kvp.Value}x {kvp.Key.Name}", ForegroundColor = ConsoleColor.DarkGray);
            }
            ResetColor();
            WriteLine($"\nPress any key to exit.");
            ReadKey();
            AreaMenu();
        }
        private void ViewStats()
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            WriteLine($"{Hero!.Name}'s stats:\n");
            WriteLine($"{Hero.Hp}/{Hero.MaxHp} HP");
            WriteLine($"{Hero.Sp}/{Hero.MaxSp} SP");
            WriteLine($"{Hero.BaseDamage} Base Damage");
            WriteLine($"{Hero.BaseDefense} Base Defense");
            WriteLine($"{Hero.GetDefense()} Defense");
            WriteLine($"Equipped Weapon: {Hero.EquippedWeapon.Name}");
            WriteLine($"Equipped Armor: {Hero.EquippedArmor.Name}");
            WriteLine($"{Hero.Gold} Gold");
            WriteLine($"Level {Hero.Level}, {Hero.Experience}/{Hero.XpToNextLevel} XP to next level");
            if(Hero.StatusEffects.Count > 0)
            {
                WriteLine("Status effects:");
                foreach(StatusEffect effect in Hero.StatusEffects)
                {
                    WriteLine(effect.Name);
                }
            } else
            {
                WriteLine("No current status effects");
            }
            WriteLine($"{Hero.GetCritChance()}% Crit Chance");
            WriteLine($"{Hero.DodgeChance}% Dodge Chance\n");
            WriteLine($"Press any key to exit.");
            ReadKey();
            AreaMenu();
        }
        private void EquipWeapon(int index = 0)
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            Menu equip = new Menu();
            equip.DisplayEquipWeaponMenu(index);
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (index == 0)
                {
                    index = Hero!.WeaponInventory.Count - 1;
                }
                else if (index > 0)
                {
                    index--;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (index == Hero!.WeaponInventory.Count - 1)
                {
                    index = 0;
                }
                else if (index < Hero.WeaponInventory.Count - 1)
                {
                    index++;
                }
            }
            if (key != ConsoleKey.Enter)
            {
                EquipWeapon(index);
            }
            else
            {
                if(index == Hero!.WeaponInventory.Count - 1)
                {
                    AreaMenu();
                } else
                {
                    List<Weapon> validWeapons = Hero.WeaponInventory.ToList();
                    validWeapons.Remove(Hero.EquippedWeapon);
                    Hero.EquippedWeapon = validWeapons[index];
                    AreaMenu();
                }
            }
        }
        private void EquipArmor(int index = 0)
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            Menu equip = new Menu();
            equip.DisplayEquipArmorMenu(index);
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (index == 0)
                {
                    index = Hero!.ArmorInventory.Count - 1;
                }
                else if (index > 0)
                {
                    index--;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (index == Hero!.ArmorInventory.Count - 1)
                {
                    index = 0;
                }
                else if (index < Hero.ArmorInventory.Count - 1)
                {
                    index++;
                }
            }
            if (key != ConsoleKey.Enter)
            {
                EquipArmor(index);
            }
            else
            {
                if (index == Hero!.ArmorInventory.Count - 1)
                {
                    AreaMenu();
                }
                else
                {
                    List<Armor> validArmor = Hero.ArmorInventory.ToList();
                    validArmor.Remove(Hero.EquippedArmor);
                    Hero.EquippedArmor = validArmor[index];
                    AreaMenu();
                }
            }
        }
        private void SkillPoint(int index = 0)
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            Menu skillPoint = new Menu();
            skillPoint.DisplaySkillPointMenu(index);
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (index == 0)
                {
                    index = Menu.SkillPointOptions.Count;
                }
                else if (index > 0)
                {
                    index--;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (index == Menu.SkillPointOptions.Count)
                {
                    index = 0;
                }
                else if (index < Menu.SkillPointOptions.Count)
                {
                    index++;
                }
            }
            if (key != ConsoleKey.Enter)
            {
                SkillPoint(index);
            }
            else
            {
                if (index == Menu.SkillPointOptions.Count)
                {
                    AreaMenu();
                }
                else
                {
                    if(index == 0)
                    {
                        BoostStat();
                    } else if(index == 1)
                    {
                        UnlockSkill();
                    } else
                    {
                        UnlockAbility();
                    }
                }
            }
        }
        private void BoostStat(int index = 0)
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            Menu boostStat = new Menu();
            boostStat.DisplayBoostStatMenu(index);
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (index == 0)
                {
                    index = Menu.BoostStatOptions.Count;
                }
                else if (index > 0)
                {
                    index--;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (index == Menu.BoostStatOptions.Count)
                {
                    index = 0;
                }
                else if (index < Menu.BoostStatOptions.Count)
                {
                    index++;
                }
            }
            if (key != ConsoleKey.Enter)
            {
                BoostStat(index);
            }
            else
            {
                if (index == Menu.BoostStatOptions.Count)
                {
                    SkillPoint();
                }
                else
                {
                    if(Hero!.LevelPoints > 0)
                    {
                        Hero.LevelPoints--;
                        switch(index)
                        {
                            case 0:
                                Hero.MaxHp += 5;
                                Hero.Hp += 5;
                                break;
                            case 1:
                                Hero.MaxSp += 3;
                                Hero.Sp += 3;
                                break;
                            case 2:
                                Hero.BaseDamage++;
                                break;
                            case 3:
                                Hero.BaseCritChance++;
                                break;
                        }
                        SkillPoint();
                    }
                    else
                    {
                        BoostStat(index);
                    }
                }
            }
        }
        private void UnlockSkill(int index = 0)
        {

        }
        private void UnlockAbility(int index = 0)
        {

        }
        private void ViewCompletion()
        {

        }
        private void CreateEncounter(int minEnemies, int maxEnemies)
        {
            List<Enemy> enemies = Hero!.Area.Enemies;
            Combat combat = new Combat(Hero, new List<Enemy>());
            for(int i = 0; i < minEnemies; i++)
            {
                combat.Enemies.Add(enemies[new Random().Next(enemies.Count)].Clone());
            }
            for(int i = 0; i < maxEnemies - minEnemies; i++)
            {
                if(new Random().Next(4) == 0)
                {
                    combat.Enemies.Add(enemies[new Random().Next(enemies.Count)].Clone());
                }
            }
            Hero.CurrentCombat = combat;
            TurnMenu(combat);
        }
        public void TurnMenu(Combat combat, int index = 0)
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            PrintEnemyInfo(combat.Enemies);
            Menu turn = new Menu();
            turn.DisplayTurnMenu(index);
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (index == 0)
                {
                    index = Menu.TurnOptions.Count - 1;
                }
                else if (index > 0)
                {
                    index--;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (index == Menu.TurnOptions.Count - 1)
                {
                    index = 0;
                }
                else if (index < Menu.TurnOptions.Count - 1)
                {
                    index++;
                }
            }
            if (key != ConsoleKey.Enter)
            {
                TurnMenu(combat, index);
            }
            else
            {
                TurnMenuSelection(combat, index);
            }
        }
        private void TurnMenuSelection(Combat combat, int command)
        {
            switch(command)
            {
                case 0:
                    Clear();
                    PrintTitle();
                    PrintPlayerInfo();
                    PrintEnemyInfo(combat.Enemies);
                    Enemy? target = TargetMenu(combat);
                    if(target != null)
                    {
                        Hero!.Attack(target);
                        combat.CalculateDeaths();
                        if (combat.Enemies.Count == 0)
                        {
                            WriteLine("> ");
                            ReadKey();
                            EndCombat();
                        }
                        else
                        {
                            EnemyTurn(combat);
                        }
                    } else
                    {
                        TurnMenu(combat);
                    }
                    break;
                case 1:
                    AbilityMenu(combat);
                    break;
                case 2:
                    CombatItemMenu(combat);
                    break;
                case 3:
                    if(new Random().Next(2) == 0)
                    {
                        Clear();
                        PrintTitle();
                        PrintPlayerInfo();
                        WriteLine("Escaped!");
                        Thread.Sleep(1000);
                        AreaMenu();
                    } else
                    {
                        Clear();
                        PrintTitle();
                        PrintPlayerInfo();
                        WriteLine("Can't Escape!");
                        Thread.Sleep(1000);
                        EnemyTurn(combat);
                    }
                    break;
            }
        }
        private Enemy? TargetMenu(Combat combat, int index = 0)
        {
            bool selected = false;
            while(!selected)
            {
                Clear();
                PrintTitle();
                PrintPlayerInfo();
                PrintEnemyInfo(combat.Enemies);
                Menu target = new Menu();
                target.DisplayTargetMenu(combat.Enemies, index);
                ConsoleKey key = ReadKey().Key;
                if (key == ConsoleKey.UpArrow)
                {
                    if (index == 0)
                    {
                        index = combat.Enemies.Count;
                    }
                    else if (index > 0)
                    {
                        index--;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (index == combat.Enemies.Count)
                    {
                        index = 0;
                    }
                    else if (index < combat.Enemies.Count)
                    {
                        index++;
                    }
                }
                if (key == ConsoleKey.Enter)
                {
                    if(index == combat.Enemies.Count)
                    {
                        return null;
                    }
                    selected = true;
                }
            }
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            PrintEnemyInfo(combat.Enemies);
            return combat.Enemies[index];
        }
        private void AbilityMenu(Combat combat, int index = 0)
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            PrintEnemyInfo(combat.Enemies);
            Menu menu = new Menu();
            menu.DisplayAbilityMenu(Hero!.Abilities, index);
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (index == 0)
                {
                    index = Hero.Abilities.Count;
                }
                else if (index > 0)
                {
                    index--;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (index == Hero.Abilities.Count)
                {
                    index = 0;
                }
                else if (index < Hero.Abilities.Count)
                {
                    index++;
                }
            }
            if (key != ConsoleKey.Enter)
            {
                AbilityMenu(combat, index);
            }
            else
            {
                if(index == Hero.Abilities.Count)
                {
                    TurnMenu(combat);
                } else
                {
                    Clear();
                    PrintTitle();
                    PrintPlayerInfo();
                    PrintEnemyInfo(combat.Enemies);
                    Ability chosen = Hero.Abilities[index];
                    if (Hero.Sp >= chosen.SpCost)
                    {
                        Hero.Sp -= chosen.SpCost;
                        WriteLine($"{Hero.Name} uses {chosen.Name}!");
                        chosen.Activate();
                        combat.CalculateDeaths();
                        if (combat.Enemies.Count == 0)
                        {
                            WriteLine("> ");
                            ReadKey();
                            EndCombat();
                        }
                        else
                        {
                            EnemyTurn(combat);
                        }
                    } else
                    {
                        AbilityMenu(combat, index);
                    }
                }
            }
        }
        private void CombatItemMenu(Combat combat, int index = 0)
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            PrintEnemyInfo(combat.Enemies);
            Menu menu = new Menu();
            menu.DisplayCombatItemMenu(index);
            ConsoleKey key = ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (index == 0)
                {
                    index = Hero!.ItemInventory.Count;
                }
                else if (index > 0)
                {
                    index--;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (index == Hero!.ItemInventory.Count)
                {
                    index = 0;
                }
                else if (index < Hero.ItemInventory.Count)
                {
                    index++;
                }
            }
            if (key != ConsoleKey.Enter)
            {
                CombatItemMenu(combat, index);
            } else
            {
                if(index == Hero!.ItemInventory.Count)
                {
                    TurnMenu(combat);
                } else
                {
                    Clear();
                    PrintTitle();
                    PrintPlayerInfo();
                    PrintEnemyInfo(combat.Enemies);
                    Item selected = Hero.ItemInventory.ElementAt(index).Key;
                    WriteLine($"{Hero.Name} uses {selected.Name}!");
                    selected.Use();
                    Hero.ItemInventory[selected]--;
                    if (Hero.ItemInventory[selected] == 0)
                    {
                        Hero.ItemInventory.Remove(selected);
                    }
                    EnemyTurn(combat);
                }
            }
        }
        private void EndCombat()
        {
            Clear();
            PrintTitle();
            PrintPlayerInfo();
            WriteLine("Enemies defeated!");
            Hero!.CurrentCombat = null;
            WriteLine("> ");
            ReadKey();
            AreaMenu();
        }
        private void EnemyTurn(Combat combat)
        {
            combat.EnemyTurn();
            WriteLine("> ");
            ReadKey();
            if(Hero!.Hp <= 0)
            {
                GameOver();
            }
            TurnMenu(combat);
        }
        private void GameOver()
        {
            Clear();
            PrintTitle();
            Write(
                "  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  \n" +
                " ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒\n" +
                "▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒\n" +
                "░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  \n" +
                "░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒\n" +
                " ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░\n" +
                "  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░\n" +
                "░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ \n" +
                "      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     \n" +
                "                                                      ░                  \n\n",
                ForegroundColor = ConsoleColor.DarkRed);
            ResetColor();
            WriteLine("Press any key to begin a new game");
            ReadKey();
            Program.StartNewGame();
        }
    }
}