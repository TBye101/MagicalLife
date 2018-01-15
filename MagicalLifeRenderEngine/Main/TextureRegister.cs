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
        private static Assembly resourceAssembly;

        /// <summary>
        /// Contains the name of each texture, and the image that goes along with it.
        /// </summary>
        private static Dictionary<string, Bitmap> NameToTextureBindings = new Dictionary<string, Bitmap>();

        static TextureRegister()
        {
            TextureRegister.resourceAssembly = Assembly.GetAssembly(typeof(TextureRegister));
            TextureRegister.DiscoverInternalTextures();
        }

        /// <summary>
        /// Loads internal textures.
        /// </summary>
        private static void DiscoverInternalTextures()
        {
            string textureFolder = string.Format("{0}.Resource.Texture", resourceAssembly.GetName().Name);

            List<string> textureNames = resourceAssembly.GetManifestResourceNames().Where(r => r.StartsWith(textureFolder)).ToList();
            List<Bitmap> textures = new List<Bitmap>();

            ResourceLoader loader = new ResourceLoader();
            foreach (string item in textureNames)
            {
                TextureRegister.NameToTextureBindings.Add(item, loader.LoadImage(item));
            }

        }

        public static Bitmap GetTexture(string name)
        {
            string textureFolder = string.Format("{0}.Resource.Texture", resourceAssembly.GetName().Name);

            Bitmap ret;
            TextureRegister.NameToTextureBindings.TryGetValue(textureFolder + "." + name, out ret);

            if (ret != null)
            {
                return new Bitmap(ret);
            }
            else
            {
                throw new Exception("Invalid texture request!");
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
