// <copyright file="MainCreatureGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Creature
{
    using EarthMagicCharacters.Classes.Monk;
    using EarthWithMagic.CreatureGen;
    using EarthWithMagicAPI.API.Util;
    using System;

    /// <summary>
    /// Switches and determines which class generator to launch.
    /// </summary>
    public class MainCreatureGenerator
    {
        public ICreature GetMainCharacter()
        {
            Filing.Writeline("Monk, Wizard, Cleric, or Thief?");
            string input = Filing.ReadLine();

            switch (input.ToLower())
            {
                case "cleric":
                    ClericCharacterGenerator cleric = new ClericCharacterGenerator();
                    return cleric.Generate();

                case "monk":
                    MonkCharacterGeneration gen = new MonkCharacterGeneration();
                    return gen.Generate();

                case "thief":
                    ThiefCharacterGenerator thief = new ThiefCharacterGenerator();
                    return thief.Generate();

                case "wizard":
                    WizardCharacterGenerator wizard = new WizardCharacterGenerator();
                    return wizard.Generate();

                default:
                    Filing.Writeline("Invalid input!");
                    return this.GetMainCharacter();
            }
        }
    }
}