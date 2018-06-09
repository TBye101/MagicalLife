using MagicalLifeAPI.World;
using MagicalLifeServer.ServerWorld.World_Generation.Generators;
using System;

namespace MagicalLifeGUIWindows.GUI.New_World_Menu
{
    /// <summary>
    /// Handles all input from the new world menu.
    /// </summary>
    public class NewGameInputHandler
    {
        /// <summary>
        /// Handles the input in the world size input boxes, and starts a new game.
        /// </summary>
        public void StartNewGame()
        {
            int width = -1;
            bool widthSuccess = int.TryParse(NewWorldMenu.NewWorldMenuM.worldWidth.Text, out width);

            int length = -1;
            bool lengthSuccess = int.TryParse(NewWorldMenu.NewWorldMenuM.worldLength.Text, out length);

            if (widthSuccess && lengthSuccess && width > 0 && length > 0)
            {
                World.Initialize(width, length, new Dirtland());
                //World.Initialize(width, length, new StoneSprinkle());
            }
            else
            {
                throw new Exception("Invalid input!");
            }
        }
    }
}