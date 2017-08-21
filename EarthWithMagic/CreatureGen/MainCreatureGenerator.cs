using EarthMagicCharacters.Classes.Monk;
using EarthWithMagic.CreatureGen;
using System;

namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Switches and determines which class generator to launch.
    /// </summary>
    public class MainCreatureGenerator
    {
        public ICreature GetMainCharacter()
        {
            Util.Util.WriteLine("Monk, Wizard, or Thief?");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
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
                    Util.Util.WriteLine("Invalid input!");
                    return GetMainCharacter();
            }
        }
    }
}