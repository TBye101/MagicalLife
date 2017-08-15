using EarthMagicCharacters.Classes.Monk;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Switches and determines which class generator to launch.
    /// </summary>
    public class MainCreatureGenerator
    {
        public ICreature GetMainCharacter()
        {
            Util.Util.WriteLine("Monk?");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "monk":
                    MonkCharacterGeneration gen = new MonkCharacterGeneration();
                    return gen.Generate();
                default:
                    Util.Util.WriteLine("Invalid input!");
                    return GetMainCharacter();
            }
        }
    }
}
