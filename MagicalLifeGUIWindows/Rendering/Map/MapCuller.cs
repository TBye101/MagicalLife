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
        private readonly Point2D TileSize = Tile.GetTileSize();

        //How many tiles can fit left to right on the screen.
        private readonly int ScreenChunksWidth;
        //How many tiles can fit top to bottom on the screen.
        private readonly int ScreenChunksHeight;

        Point2D[,] ChunksInView;

        public MapCuller(Rectangle fullScreenWindow)
        {
            this.ScreenChunksWidth = fullScreenWindow.Width / (this.TileSize.X * Chunk.Width) + 2;
            this.ScreenChunksHeight = fullScreenWindow.Height / (this.TileSize.Y * Chunk.Height) + 2;
            this.InitializeChunksInView();
        }

        /// <summary>
        /// Initializes <see cref="ChunksInView"/>.
        /// </summary>
        private void InitializeChunksInView()
        {
            this.ChunksInView = new Point2D[this.ScreenChunksWidth, this.ScreenChunksHeight];

            for (int x = 0; x < this.ScreenChunksWidth; x++)
            {
                for (int y = 0; y < this.ScreenChunksHeight; y++)
                {
                    this.ChunksInView[x, y] = new Point2D(0, 0);
                }
            }
        }

        public Point2D[,] GetChunksInView(int cameraXOffset, int cameraYOffset)
        {
            //The chunk position of the upper top left.
            int leftChunkX = Math.Abs((cameraXOffset / this.TileSize.X) / Chunk.Width);
            int leftChunkY = Math.Abs((cameraYOffset / this.TileSize.Y) / Chunk.Height);

            for (int x = 0; x < this.ScreenChunksWidth; x++)
            {
                for (int y = 0; y < this.ScreenChunksHeight; y++)
                {
                    this.ChunksInView[x, y].X = leftChunkX + x;
                    this.ChunksInView[x, y].Y = leftChunkY + y;
                }
            }

            return this.ChunksInView;
        }
    }
}
