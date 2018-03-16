using MagicalLifeAPI.World;
using MagicalLifeAPI.World.World_Generation.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            int depth = -1;
            bool depthSuccess = int.TryParse(NewWorldMenu.NewWorldMenuM.worldDepth.Text, out depth);

            if (widthSuccess && lengthSuccess && depthSuccess && width > 0 && length > 0 && depth > 0)
            {
                World.Initialize(width, length, depth, new Dirtland());
            }
            else
            {
                throw new Exception("Invalid input!");
            }
        }
    }
}
