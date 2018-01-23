using FastBitmapLib;
using MagicalLifeAPI.World;
using System.Drawing;

namespace MagicalLifeRenderEngine.Main
{
    /// <summary>
    /// <see cref="Pipe"/> is used to generate images on demand about various in game things.
    /// </summary>
    public class Pipe
    {
        /// <summary>
        /// Generates the entire screen. The tiles as well as the gui.
        /// </summary>
        /// <param name="height">The level (z axis) that we should generate an image of all the tiles at.</param>
        /// <param name="world"></param>
        /// <returns></returns>
        public Bitmap GetScreen(int height, World world)
        {
            Bitmap tiles = this.GetTiles(height, world);

            

            return tiles;
        }

        /// <summary>
        /// Draws the end turn button onto the passed in screen bitmap.
        /// </summary>
        /// <param name="screen">The screen to draw the end turn button onto.</param>
        /// <returns></returns>
        private void DrawEndTurnButton(ref Bitmap screen)
        {
            
        }

        /// <summary>
        /// Returns what each tile on the map at a specified height looks like.
        /// This is a 2D array.
        /// </summary>
        /// <param name="height">The level (z axis) that we should generate an image of all the tiles at. </param>
        /// <param name="world"></param>
        /// <returns></returns>
        public Bitmap GetTiles(int height, World world)
        {
            int x = 0;
            int y = 0;
            int z = height;
            int xSize = world.Tiles.GetLength(0);
            int ySize = world.Tiles.GetLength(1);

            Tile[,,] tiles = world.Tiles;

            //The entire map, at the specified height.
            Bitmap entireMap = new Bitmap(Tile.GetTileSize().Height * xSize, Tile.GetTileSize().Width * ySize);
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
                    Rectangle destination = new Rectangle(new Point(Tile.GetTileSize().Height * x, Tile.GetTileSize().Width * y), Tile.GetTileSize());
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