using FastBitmapLib;
using MagicalLifeAPI.World;
using MagicalLifeRenderEngine.Main.GUI;
using System.Drawing;

namespace MagicalLifeRenderEngine.Main
{
    /// <summary>
    /// <see cref="Pipe"/> is used to generate images on demand about various in game things.
    /// </summary>
    public class Pipe
    {
        /// <summary>
        /// The z level of the last map drawing rendered.
        /// </summary>
        public static int RenderedHeight = 0;

        /// <summary>
        /// Generates the entire screen. The tiles as well as the gui.
        /// </summary>
        /// <param name="height">The level (z axis) that we should generate an image of all the tiles at.</param>
        /// <param name="world"></param>
        /// <returns></returns>
        public Bitmap GetScreen(int height)
        {
            Bitmap tiles = this.GetTiles(height);
            EndTurnButtonGUI.Draw(ref tiles);

            return tiles;
        }

        /// <summary>
        /// Returns what each tile on the map at a specified height looks like.
        /// This is a 2D array.
        /// </summary>
        /// <param name="height">The level (z axis) that we should generate an image of all the tiles at. </param>
        /// <param name="world"></param>
        /// <returns></returns>
        public Bitmap GetTiles(int height)
        {
            int x = 0;
            int y = 0;
            int z = height;
            Pipe.RenderedHeight = height;
            int xSize = World.mainWorld.Tiles.GetLength(0);
            int ySize = World.mainWorld.Tiles.GetLength(1);

            Tile[,,] tiles = World.mainWorld.Tiles;

            //The entire map, at the specified height.
            Bitmap entireMap = new Bitmap(Tile.GetTileSize().Y * xSize, Tile.GetTileSize().X * ySize);
            FastBitmap fastMap = new FastBitmap(entireMap);
            fastMap.Lock();

            //Iterate over each row.
            for (int i = 0; i < xSize; i++)
            {
                //Iterate over each column
                for (int ii = 0; ii < ySize; ii++)
                {
                    //Draw constructed tile onto "entireMap" at the proper section.
                    Bitmap temp = new Bitmap(TileImageGenerator.GenerateTileImage(tiles[x, y, z]));
                    Rectangle destination = new Rectangle(new Point(Tile.GetTileSize().Y * x, Tile.GetTileSize().X * y), Tile.GetTileSize());
                    fastMap.CopyRegion(temp, new Rectangle(new Point(0, 0), Tile.GetTileSize()), destination);
                    y++;
                }
                y = 0;
                x++;
            }

            fastMap.Unlock();
            return entireMap;
        }
    }
}