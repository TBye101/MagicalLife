using EarthMagicCharacters.Classes.Monk.Generic_Monk;
using EarthWithMagicAPI.API.Party;
using EarthWithMagicAPI.API.Creature;
using EarthWithMagicAPI.API.Stuff;
using System;

namespace EarthWithMagic
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            string input;
            MainCreatureGenerator gen = new MainCreatureGenerator();
            Party.TheParty.Add(gen.GetMainCharacter());
            while (true)
            {
                input = Console.ReadLine();

                Encounter continous = new Encounter(Party.TheParty, new System.Collections.Generic.List<ICreature> { new GenericMonk(Gender.Male, Race.Human) });
                Party.TheParty = continous.Fight();
            }
        }
    }
}