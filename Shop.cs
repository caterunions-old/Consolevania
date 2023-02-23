using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Shop
    {
        public Dictionary<Weapon, int> Weapons { get; set; }
        public Dictionary<Armor, int> Armor { get; set; }
        public Dictionary<Item, int> Items { get; set; }

        public Shop(Dictionary<Weapon, int> weapons, Dictionary<Armor, int> armor, Dictionary<Item, int> items)
        {
            Weapons = weapons;
            Armor = armor;
            Items = items;
        }
    }
}
