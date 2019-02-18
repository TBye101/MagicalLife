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

        /// <summary>
        /// The visible area on the screen.
        /// </summary>
        private Rectangle VisibleArea = new Rectangle(0, 0, 0, 0);

        /// <summary>
        /// The bounds of the camera.
        /// </summary>
        private Rectangle CameraBounds = new Rectangle(0, 0, 0, 0);

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
            this.ChunksInView = new List<Point2D>();
        }

        private void UpdateVisibleArea()
        {
            this.CameraBounds.X = (int)RenderInfo.Camera2D.Position.X;
            this.CameraBounds.Y = (int)RenderInfo.Camera2D.Position.Y;
            this.CameraBounds.Width = RenderInfo.Camera2D.ViewportWidth;
            this.CameraBounds.Height = RenderInfo.Camera2D.ViewportHeight;

            Matrix inverseViewMatrix = Matrix.Invert(RenderInfo.Camera2D.TranslationMatrix);

            Vector2 tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            Vector2 tr = Vector2.Transform(new Vector2(this.CameraBounds.X, 0), inverseViewMatrix);
            Vector2 bl = Vector2.Transform(new Vector2(0, this.CameraBounds.Y), inverseViewMatrix);
            Vector2 br = Vector2.Transform(new Vector2(this.CameraBounds.Width, this.CameraBounds.Height), inverseViewMatrix);

            Vector2 min = new Vector2(
                MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
                MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
            Vector2 max = new Vector2(
                MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
                MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));
            this.VisibleArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }

        public List<Point2D> GetChunksInView()
        {
            this.ChunksInView.Clear();
            this.UpdateVisibleArea();
            this.ScreenChunksWidth = (int)(RenderInfo.FullScreenWindow.Width / (this.TileSize.X * Chunk.Width) / RenderInfo.Camera2D.Zoom) + 3;
            this.ScreenChunksHeight = (int)(RenderInfo.FullScreenWindow.Height / (this.TileSize.Y * Chunk.Height) / RenderInfo.Camera2D.Zoom) + 3;

            //The chunk position of the upper top left.
            //int leftChunkX = (int)(Math.Max(0, Math.Abs(((int)RenderInfo.Camera2D.Position.X / (this.TileSize.X * Chunk.Width))) - 2));//Doesn't handle zoom properly
            //int leftChunkY = (int)(Math.Max(0, Math.Abs(((int)RenderInfo.Camera2D.Position.Y / (this.TileSize.Y * Chunk.Height))) - 2));//Doesn't handle zoom properly
            int leftChunkX = Math.Max(0, this.VisibleArea.X / (this.TileSize.X * Chunk.Width));
            int leftChunkY = Math.Max(0, this.VisibleArea.Y / (this.TileSize.Y * Chunk.Height));

            int dimensionWidth = RenderInfo.Camera2D.DimensionWidth;
            int dimensionHeight = RenderInfo.Camera2D.DimensionHeight;

            int x = 0;
            int y = 0;
            while (x < this.ScreenChunksWidth)
            {
                while (y < this.ScreenChunksHeight)
                {
                    int newChunkX = x + leftChunkX;
                    int newChunkY = y + leftChunkY;

                    if (newChunkX < dimensionWidth && newChunkY < dimensionHeight)
                    {
                        this.ChunksInView.Add(new Point2D(x + leftChunkX, y + leftChunkY));
                    }
                    y++;
                }

                y = 0;
                x++;
            }

            return this.ChunksInView;
        }
    }
}
