using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Hero
    {
        public string Name { get; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int BaseDamage { get; set; }
        public int BaseDefense { get; set; }
        public int Defense { get; set; }
        public int MaxSp { get; set; }
        public int Sp { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public int Gold { get; set; } = new Random().Next(4,9);
        public Class Class { get; set; }
        public List<Weapon> WeaponInventory { get; set; }
        public List<Armor> ArmorInventory { get; set; }
        public Dictionary<Item, int> ItemInventory { get; set; }
        public int Experience { get; set; } = 0;
        public int Level { get; set; } = 1;
        public HashSet<Enemy> Bestiary { get; set; } = new HashSet<Enemy>();
        public List<StatusEffect> StatusEffects { get; set; } = new List<StatusEffect>();
        public Area Area { get; set; }
        public HashSet<Skill> Skills { get; set; }
        public List<Ability> Abilities { get; set; }
        public int BaseCritChance { get; set; }
        public int CritChance { get; set; }
        public int DodgeChance { get; set; }
        public bool InTown { get; set; } = false;
        public int XpToNextLevel { get; set; } = 25;
        public Combat? CurrentCombat { get; set; }
        public int LevelPoints { get; set; } = 0;

        public Hero(
            string name, int hp, int baseDamage, int baseDefense, Weapon equippedWeapon, Armor equippedArmor,
            Class @class, List<Weapon> weaponInventory, List<Armor> armorInventory, Dictionary<Item, int> itemInventory,
            Area area, HashSet<Skill> skills, List<Ability> abilities, int sp, int baseCritChance, int dodgeChance)
        {
            Name = name;
            MaxHp = hp;
            Hp = hp;
            BaseDamage = baseDamage;
            BaseDefense = baseDefense;
            EquippedWeapon = equippedWeapon;
            EquippedArmor = equippedArmor;
            Class = @class;
            WeaponInventory = weaponInventory;
            ArmorInventory = armorInventory;
            ItemInventory = itemInventory;
            Area = area;
            Skills = skills;
            Abilities = abilities;
            MaxSp = sp;
            Sp = sp;
            BaseCritChance = baseCritChance;
            DodgeChance = dodgeChance;
            Defense = BaseDefense + EquippedArmor.Defense;
            CritChance = BaseCritChance + EquippedWeapon.ExtraCrit;
            CurrentCombat = null;
        }

        public int GetDefense()
        {
            Defense = BaseDefense + EquippedArmor.Defense;
            return Defense;
        }

        public int GetCritChance()
        {
            CritChance = BaseCritChance + EquippedWeapon.ExtraCrit;
            return CritChance;
        }

        public void Attack(Enemy target)
        {
            WriteLine($"{Name} attacks {target.Name}!");
            Thread.Sleep(1000);
            if(new Random().Next(100) > EquippedWeapon.Accuracy)
            {
                WriteLine("Missed!");
            } else
            {
                int crit = GetCritChance();
                int damage = BaseDamage + EquippedWeapon.Damage + Convert.ToInt32(new Random().Next(BaseDamage / 4));
                if(EquippedWeapon.Type == Class.FavoredWeaponType)
                {
                    damage = Convert.ToInt32(damage * 1.2);
                }
                if(new Random().Next(100) < crit)
                {
                    WriteLine("Critical Hit!", ForegroundColor = ConsoleColor.Yellow);
                    ResetColor();
                    damage *= 2;
                }
                WriteLine($"{target.TakeDamage(damage)} Damage dealt!");
                if(EquippedWeapon.Effects.Count > 0)
                {
                    foreach(StatusEffect effect in EquippedWeapon.Effects)
                    {
                        WriteLine($"{target.Name} was {effect.Name.ToLower()}!");
                        target.StatusEffects.Add(effect);
                    }
                }
            }
            ResetColor();
        }

        public int TakeDamage(int damage)
        {
            damage -= GetDefense();
            damage = Math.Clamp(damage, 1, MaxHp);
            Hp -= damage;
            return damage;
        }

        public int TakeDamage(int damage, bool ignoresArmor)
        {
            if(!ignoresArmor)
            {
                damage -= GetDefense();
                damage = Math.Clamp(damage, 1, MaxHp);
            }
            Hp -= damage;
            return damage;
        }

        public int Heal(int heal)
        {
            Hp = Math.Clamp(Hp + heal, 0, MaxHp);
            return heal;
        }

        public int RestoreSP(int sp)
        {
            Sp = Math.Clamp(Sp + sp, 0, MaxSp);
            return sp;
        }

        public void GainWeapon(Weapon weapon)
        {
            WeaponInventory.Add(weapon);
        }

        public void GainArmor(Armor armor)
        {
            ArmorInventory.Add(armor);
        }

        public void GainItem(Item item)
        {
            ItemInventory.TryAdd(item, 0);
            ItemInventory[item]++;
        }

        public void LevelUp()
        {
            WriteLine($"{Name} levelled up!", ForegroundColor = ConsoleColor.Cyan);
            Experience -= XpToNextLevel;
            XpToNextLevel = Convert.ToInt32(XpToNextLevel * 1.2);
            Level++;
            int levelUpHp = Convert.ToInt32(2 + Math.Clamp(MaxHp / 20, 1, int.MaxValue));
            MaxHp += levelUpHp;
            Hp += levelUpHp;
            WriteLine($"{Name} gained {levelUpHp} max HP!", ForegroundColor = ConsoleColor.White);
            int levelUpSp = Convert.ToInt32(1 + Math.Clamp(MaxSp / 20, 1, int.MaxValue));
            MaxSp += levelUpSp;
            Sp += levelUpSp;
            WriteLine($"{Name} gained {levelUpSp} max SP!", ForegroundColor = ConsoleColor.White);
            int levelUpDefense = Convert.ToInt32(Math.Clamp(BaseDefense / 20, 1, int.MaxValue));
            BaseDefense += levelUpDefense;
            WriteLine($"{Name} gained {levelUpDefense} defense!");
            int levelUpDamage = Convert.ToInt32(Math.Clamp(BaseDamage / 20, 1, int.MaxValue));
            BaseDamage += levelUpDamage;
            WriteLine($"{Name} gained {levelUpDamage} damage!");
            LevelPoints++;
            WriteLine($"{Name} gained 1 Skill Point!");
            ResetColor();
        }
    }
}
