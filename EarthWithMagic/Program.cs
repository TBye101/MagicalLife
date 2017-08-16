using System.Diagnostics;
using EarthWithMagicAPI.API.Util;
using EarthMagicDocumentation;
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
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Util.WriteLine(ResourceGM.GetResource("EarthMagicDocumentation.ASCII_Art.Title.txt"));
            //Util.WriteLine(ResourceGM.GetResource("EarthMagicDocumentation.ASCII_Art.Dragon_Breathing_Fire.txt"));

            string input;
            MainCreatureGenerator gen = new MainCreatureGenerator();
            Party.TheParty.Add(gen.GetMainCharacter());
            Party.TheParty[0].Attributes.Health += 100;
            while (true)
            {
                input = Console.ReadLine();

                Encounter continous = new Encounter(Party.TheParty, new System.Collections.Generic.List<ICreature> { new GenericMonk(Gender.Male, Race.Human) });
                Party.TheParty = continous.Fight();
            }
        }
    }
}