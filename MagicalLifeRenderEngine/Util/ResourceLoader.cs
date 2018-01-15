using MagicalLifeRenderEngine.Main;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace MagicalLifeRenderEngine.Util
{
    /// <summary>
    /// Loads resources from embedded resources.
    /// </summary>
    public class ResourceLoader
    {
        private Assembly ResourceAssembly = Assembly.GetAssembly(typeof(TextureRegister));

        /// <summary>
        /// Loads a bitmap image from the specified path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Bitmap LoadImage(string path)
        {
            Stream loader = this.ResourceAssembly.GetManifestResourceStream(path);

            if (loader != null)
            {
                return new Bitmap(loader);
            }
            else
            {
                throw new Exception("Resource loading error!");
            }
        }
    }
}