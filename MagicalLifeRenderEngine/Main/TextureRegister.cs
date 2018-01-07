using MagicalLifeRenderEngine.Util;
using System.Reflection;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeRenderEngine.Main
{
    public static class TextureRegister
    {
        /// <summary>
        /// Contains the name of each texture, and the image that goes along with it.
        /// </summary>
        private static Dictionary<string, Bitmap> NameToTextureBindings = new Dictionary<string, Bitmap>();

        static TextureRegister()
        {

        }

        /// <summary>
        /// Loads internal textures.
        /// </summary>
        private static void DiscoverInternalTextures()
        {
            Assembly resourceAssembly = Assembly.GetAssembly(typeof(TextureRegister));
            string textureFolder = string.Format("{0}.Resource.Texture", resourceAssembly.GetName().Name);

            List<string> textureNames = resourceAssembly.GetManifestResourceNames().Where(r => r.StartsWith(textureFolder)).ToList();
            List<Bitmap> textures = new List<Bitmap>();

            ResourceLoader loader = new ResourceLoader();
            foreach (string item in textureNames)
            {
                textures.Add(loader.LoadImage(textureFolder + "." + item));
            }
        }

        /// <summary>
        /// Adds a texture to the internal texture dictionary.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="texture"></param>
        public static void AddTexture(string filename, Bitmap texture)
        {
            TextureRegister.NameToTextureBindings.Add(filename, texture);
        }
    }
}
