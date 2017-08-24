using EarthWithMagicAPI.API.Story;
// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagic
{
    using EarthMagicCharacters.Classes.Monk.Generic_Monk;
    using EarthMagicDocumentation;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Party;
    using EarthWithMagicAPI.API.Registry;
    using EarthWithMagicAPI.API.Stuff;
    using EarthWithMagicAPI.API.Util;
    using System;
    using System.Collections.Generic;

    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.SetBufferSize(Console.BufferWidth, 32766);
            Util.WriteLine(ResourceGM.GetResource("EarthMagicDocumentation.ASCII_Art.Title.txt"));
            List<IItem> a = ItemRegistry.Items;

            string input;
            MainCreatureGenerator gen = new MainCreatureGenerator();
            Party.TheParty.Add(gen.GetMainCharacter());
            //Party.TheParty[0].Attributes.Health += 100;
            while (true)
            {
                input = Console.ReadLine();

                Encounter continous = new Encounter(Party.TheParty, new System.Collections.Generic.List<ICreature> { new GenericMonk(Gender.Male, Race.Human) });
                Party.TheParty = continous.Fight();
                PeacefulPartyTime peaceful = new PeacefulPartyTime(true, 0);
                peaceful.Go();
            }
        }
    }
}