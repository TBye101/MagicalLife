using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// Keeps track of what priority things have when rendering.
    /// </summary>
    public static class RenderLayer
    {
        public static readonly int DirtBase;
        public static readonly int GrassBase = 1;

        public static readonly int Items = 500;

        public static readonly int Stone = 1000;


        public static readonly int Character = 20000;
    }
}
