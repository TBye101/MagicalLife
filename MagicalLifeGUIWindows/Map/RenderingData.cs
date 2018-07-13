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
        /// <summary>
        /// The value of the last assigned priority to a GUI pop-up.
        /// </summary>
        private static int CurrentPriority = int.MinValue;

        /// <summary>
        /// Returns an ever increasing number for pop-up window priorities.
        /// </summary>
        /// <returns></returns>
        public static int GetGUIContainerPriority()
        {
            CurrentPriority += 1;
            return CurrentPriority;
        }

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
            Point2D location = tile.Location;
            string textureName = tile.GetTextureName();

            List<Texture2D> textures = AssetManager.Textures;
            int length = textures.Count;
            for (int i = 0; i < length; i++)
            {
                if (textures[i].Name == textureName)
                {
                    tile.TextureIndex = i;
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