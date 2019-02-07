using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Rendering.Map
{
    /// <summary>
    /// Utilized to Perform some calculations that essentially cull 
    /// what is to be rendered down to only what is on screen to the current client.
    /// </summary>
    public class MapCuller
    {
        public Point2D[,] GetChunksInView(int cameraXOffset, int cameraYOffset, Rectangle fullScreenWindow)
        {
            Point2D tileSize = Tile.GetTileSize();

            //How many tiles can fit left to right on the screen.
            int screenChunksWidth = fullScreenWindow.Width / (tileSize.X * Chunk.Width) + 2;
            //How man tiles can fit top to bottom on the screen.
            int screenChunksHeight = fullScreenWindow.Height / (tileSize.Y * Chunk.Height) + 2;

            //The chunk position of the upper top left.
            int leftChunkX = Math.Abs((cameraXOffset / tileSize.X) / Chunk.Width);
            int leftChunkY = Math.Abs((cameraYOffset / tileSize.Y) / Chunk.Height);

            Point2D[,] chunksInView = new Point2D[screenChunksWidth, screenChunksHeight];

            for (int x = 0; x < screenChunksWidth; x++)
            {
                for (int y = 0; y < screenChunksHeight; y++)
                {
                    chunksInView[x, y] = new Point2D(leftChunkX + x, leftChunkY + y);
                }
            }

            return chunksInView;
        }
    }
}
