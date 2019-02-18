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
        private int ScreenChunksWidth;
        //How many tiles can fit top to bottom on the screen.
        private int ScreenChunksHeight;

        private List<Point2D> ChunksInView;

        public MapCuller(Rectangle fullScreenWindow)
        {
            this.ScreenChunksWidth = (fullScreenWindow.Width / (this.TileSize.X * Chunk.Width) + 2);
            this.ScreenChunksHeight = (fullScreenWindow.Height / (this.TileSize.Y * Chunk.Height) + 2);
            this.InitializeChunksInView();
        }

        /// <summary>
        /// Initializes <see cref="ChunksInView"/>.
        /// </summary>
        private void InitializeChunksInView()
        {
            int arrayWidth = this.ScreenChunksWidth * 8;
            int arrayHeight = this.ScreenChunksHeight * 8;
            //Multiply by eight in order to compensate for the most zoomed out the map can be.
            //this.ChunksInView = new List<Point2D>(arrayWidth * arrayHeight);
            this.ChunksInView = new List<Point2D>();
        }

        public List<Point2D> GetChunksInView()
        {
            this.ChunksInView.Clear();
            this.ScreenChunksWidth = (int)(RenderInfo.FullScreenWindow.Width / (this.TileSize.X * Chunk.Width) / RenderInfo.Camera2D.Zoom) + 3;
            this.ScreenChunksHeight = (int)(RenderInfo.FullScreenWindow.Height / (this.TileSize.Y * Chunk.Height) / RenderInfo.Camera2D.Zoom) + 3;

            //The chunk position of the upper top left.
            int leftChunkX = (int)(Math.Max(0, Math.Abs(((int)RenderInfo.Camera2D.Position.X / (this.TileSize.X * Chunk.Width))) - 2));//Doesn't handle zoom properly
            int leftChunkY = (int)(Math.Max(0, Math.Abs(((int)RenderInfo.Camera2D.Position.Y / (this.TileSize.Y * Chunk.Height))) - 2));//Doesn't handle zoom properly

            int x = 0;
            int y = 0;
            while (x < this.ScreenChunksWidth)
            {
                while (y < this.ScreenChunksHeight)
                {
                    this.ChunksInView.Add(new Point2D(x + leftChunkX, y + leftChunkY));
                    y++;
                }

                y = 0;
                x++;
            }

            return this.ChunksInView;
        }
    }
}
