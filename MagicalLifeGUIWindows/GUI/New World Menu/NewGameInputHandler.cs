using MagicalLifeAPI.World.Data;
using MagicalLifeServer.ServerWorld.World;
using System;

namespace MagicalLifeGUIWindows.GUI.New
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
            bool widthSuccess = int.TryParse(NewWorldMenu.NewWorldMenuM.worldWidth.Text, out int width);

            bool lengthSuccess = int.TryParse(NewWorldMenu.NewWorldMenuM.worldLength.Text, out int length);

            if (widthSuccess && lengthSuccess && width > 0 && length > 0)
            {
                //World.Initialize(width, length, new Dirtland(0));
                //World.Initialize(width, length, new StoneSprinkle(0));
                World.Initialize(width, length, new GrassAndDirt(0));
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }
        }
    }
}