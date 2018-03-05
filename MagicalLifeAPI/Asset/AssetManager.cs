using MagicalLifeAPI.Universal;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MagicalLifeAPI.Asset
{
    /// <summary>
    /// Used to handle assets.
    /// </summary>
    public class AssetManager
    {
        /// <summary>
        /// Holds all of the textures for the game.
        /// </summary>
        public static List<Texture2D> Textures { get; private set; } = new List<Texture2D>();

        /// <summary>
        /// Holds information allowing tiles among other things to look up the texture ID for themselves.
        /// The string value is the name of the texture,
        /// while the int value is the index in the <see cref="Textures"/> list that the texture is stored at.
        /// </summary>
        public static Dictionary<string, int> NameToIndex { get; private set; } = new Dictionary<string, int>();

        /// <summary>
        /// The name of the texture to find the index of.
        /// </summary>
        /// <param name="name"></param>
        public static int GetTextureIndex(string name)
        {
            foreach (KeyValuePair<string, int> item in NameToIndex)
            {
                if (item.Key == name)
                {
                    return item.Value;
                }
            }

            throw new System.Exception("Texture index not found!");
        }

        /// <summary>
        /// Adds the specified texture to the registry.
        /// </summary>
        /// <param name="texture">The texture to add to the registry.</param>
        /// <returns>Returns the index at which the texture can be retrieved from.</returns>
        public static int RegisterTexture(Texture2D texture)
        {
            Textures.Add(texture);

            int count = Textures.Count - 1;
            NameToIndex.Add(texture.Name, count);
            return count;
        }
    }
}