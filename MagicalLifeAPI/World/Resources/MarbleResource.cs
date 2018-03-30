using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// Stone as a resource.
    /// </summary>
    public class MarbleResource : Resource
    {
        public MarbleResource(int count) : base("Marble", count)
        {
        }
    }
}
