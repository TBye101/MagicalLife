using MagicalLifeAPI.Asset;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.Map
{
    /// <summary>
    /// Holds rendering information about the map, as well as a few utilities.
    /// </summary>
    public static class RenderingData
    {
        static RenderingData()
        {
            Tile.TileCreated += Tile_TileCreated;
        }

        private static void Tile_TileCreated(object sender, TileEventArg e)
        {
            RenderingData.AssignTextureIndex(e.Tile);
        }

        private static void AssignTextureIndex(Tile tile)
        {
            Point3D location = tile.Location;
            string textureName = tile.GetTextureName();

            List<Texture2D> textures = AssetManager.Textures;
            int length = textures.Count;
            for (int i = 0; i < length; i++)
            {
                if (textures[i].Name == textureName)
                {
                    World.mainWorld.Tiles[location.X, location.Y, location.Z].TextureIndex = i;
                    return;
                }
            }

            throw new Exception("Texture not found!");
        }

        /// <summary>
        /// The z axis level that is currently being displayed on screen.
        /// </summary>
        public static int ZLevel { get; set; } = 0;
    }
}