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


            }
        }
    }
}