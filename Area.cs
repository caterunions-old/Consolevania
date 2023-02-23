using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Area
    {
        public string Name { get; }
        public Town Town { get; }
        public List<Enemy> Enemies { get; }
        public List<Weapon> WeaponDrops { get; }
        public List<Armor> ArmorDrops { get; }
        public List<Item> ItemDrops { get; }
        public int LevelRequirement { get; }
        public Enemy Boss { get; }
        public ConsoleColor Color { get; }

        public Area(
             string name, Town town, List<Enemy> enemies, List<Weapon> weaponDrops, List<Armor> armorDrops, List<Item> itemDrops,
            int levelRequirement, Enemy boss, ConsoleColor color)
        {
            Town = town;
            Enemies = enemies;
            WeaponDrops = weaponDrops;
            ArmorDrops = armorDrops;
            ItemDrops = itemDrops;
            LevelRequirement = levelRequirement;
            Boss = boss;
            Name = name;
            Color = color;
        }

        public void RefreshDrops()
        {
            foreach(Weapon weapon in WeaponDrops.ToList())
            {
                if(Game.Hero!.WeaponInventory.Contains(weapon))
                {
                    WeaponDrops.Remove(weapon);
                }
            }
            foreach(Armor armor in ArmorDrops.ToList())
            {
                if (Game.Hero!.ArmorInventory.Contains(armor))
                {
                    ArmorDrops.Remove(armor);
                }
            }
        }

        public Weapon GetWeaponDrop()
        {
            RefreshDrops();
            return WeaponDrops[new Random().Next(WeaponDrops.Count)];
        }

        public Armor GetArmorDrop()
        {
            RefreshDrops();
            return ArmorDrops[new Random().Next(ArmorDrops.Count)];
        }

        public Item GetItemDrop()
        {
            return ItemDrops[new Random().Next(ItemDrops.Count)];
        }
    }
}
