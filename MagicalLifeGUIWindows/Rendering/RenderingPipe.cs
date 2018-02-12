using MagicalLifeAPI.World;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Rendering
{
    /// <summary>
    /// Handles drawing the entire screen.
    /// </summary>
    public static class RenderingPipe
    {
        /// <summary>
        /// Draws the screen.
        /// </summary>
        /// <param name="spBatch"></param>
        public static void DrawScreen(ref SpriteBatch spBatch)
        {
            if (World.mainWorld != null)
            {
                RenderingPipe.DrawMap(ref spBatch);
            }
        }

        private static void DrawMap(ref SpriteBatch spBatch)
        {
            Tile[,,] tiles = World.mainWorld.Tiles;


        }
    }
}
