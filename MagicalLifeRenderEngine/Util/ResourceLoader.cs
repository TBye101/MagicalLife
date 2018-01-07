using System.IO;
using MagicalLifeRenderEngine.Main;
using System.Reflection;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
