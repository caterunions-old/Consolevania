using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Town
    {
        public Shop Shop { get; }
        public Action Special { get; }
        public KeyValuePair<string, string> SpecialDescription { get; }
        public int TavernCost { get; }
        public int SpecialCost { get; }
        public List<string> NPCDialogue { get; }

        public Town(Shop shop, Action special, int tavernCost, int specialCost, List<string> npcDialogue, KeyValuePair<string, string> specialDescription)
        {
            Shop = shop;
            Special = special;
            TavernCost = tavernCost;
            SpecialCost = specialCost;
            NPCDialogue = npcDialogue;
            SpecialDescription = specialDescription;
        }

        public void UseSpecial()
        {
            Special();
        }
        public static void WishingWell()
        {
            Game.Hero!.Gold--;
            WriteLine("You toss a coin into the well...");
            Thread.Sleep(1000);
            int effect = new Random().Next(20);
            if(effect == 0)
            {
                WriteLine("You feel blessed!");
                StatusEffect.Blessing.BlessingAquire(Game.Hero!);
                Game.Hero!.StatusEffects.Add(StatusEffect.Blessing);
            } else if (effect == 1)
            {
                WriteLine("You feel your wounds start to heal!");
                Game.Hero!.StatusEffects.Add(StatusEffect.Regeneration);
            } else if (effect == 2)
            {
                WriteLine("You feel refreshed!");
                WriteLine($"{Game.Hero!.Name} restored 5 SP!");
                Game.Hero.RestoreSP(5);
            } else if (effect == 3)
            {
                WriteLine("Two more float to the surface!");
                WriteLine("+2 ⓪");
                Game.Hero!.Gold += 2;
            } else
            {
                WriteLine("...And nothing happened.");
            }
        }
    }
}
