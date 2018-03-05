using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Universal
{
    /// <summary>
    /// Implemented by all classes that need a texture.
    /// Used to load that texture at startup.
    /// </summary>
    public interface IRequireTexture
    {
        /// <summary>
        /// Returns the name of the texture used by the implementing class, without the file extension.
        /// </summary>
        /// <returns></returns>
        string GetTextureName();
    }
}
