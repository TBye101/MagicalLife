using MagicalLifeAPI.Universal;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.Asset
{
    /// <summary>
    /// Used to handle assets.
    /// </summary>
    public class AssetManager : IGameLoader
    {
        /// <summary>
        /// Holds all of the textures for the game.
        /// </summary>
        public static List<Texture2D> Textures { get; private set; }

        public int GetTotalOperations()
        {
            return 1;
        }

        public void InitialStartup(ref int progress)
        {
            Textures = new List<Texture2D>();
            progress++;
        }

        /// <summary>
        /// Adds the specified texture to the registry.
        /// </summary>
        /// <param name="texture">The texture to add to the registry.</param>
        /// <returns>Returns the index at which the texture can be retrieved from.</returns>
        public static int RegisterTexture(Texture2D texture)
        {
            Textures.Add(texture);
            return Textures.Count - 1;
        }
    }
}