using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MagicalLifeAPI.Asset
{
    /// <summary>
    /// Used to handle assets.
    /// </summary>
    public static class AssetManager
    {
        public static bool isServerOnly = false;

        /// <summary>
        /// Holds all of the textures for the game.
        /// </summary>
        public static List<Texture2D> Textures { get; set; } = new List<Texture2D>();

        /// <summary>
        /// Holds information allowing tiles among other things to look up the texture ID for themselves.
        /// The string value is the name of the texture,
        /// while the int value is the index in the <see cref="Textures"/> list that the texture is stored at.
        /// </summary>
        public static Dictionary<string, int> NameToIndex { get; set; } = new Dictionary<string, int>();

        /// <summary>
        /// The name of the texture to find the index of.
        /// </summary>
        /// <param name="name"></param>
        public static int GetTextureIndex(string name)
        {
            //MasterLog.DebugWriteLine("Textures in texture index: ");
            foreach (KeyValuePair<string, int> item in NameToIndex)
            {
                //MasterLog.DebugWriteLine(item.Key);
                if (item.Key == name)
                {
                    return item.Value;
                }
            }

            throw new System.Exception("Texture index not found! Texture: " + name);
        }

        /// <summary>
        /// Adds the specified texture to the registry.
        /// </summary>
        /// <param name="texture">The texture to add to the registry.</param>
        /// <returns>Returns the index at which the texture can be retrieved from.</returns>
        //public static int RegisterTexture(Texture2D texture)
        //{
        //    bool Exists = false;

        //    foreach (Texture2D item in Textures)
        //    {
        //        if (item.Name == texture.Name)
        //        {
        //            Exists = true;
        //            break;
        //        }
        //    }

        //    if (!Exists)
        //    {
        //        Textures.Add(texture);
        //        int count = Textures.Count - 1;
        //        NameToIndex.Add(texture.Name, count);
        //        return count;
        //    }
        //    else
        //    {
        //        return AssetManager.GetTextureIndex(texture.Name);
        //    }
        //}
    }
}