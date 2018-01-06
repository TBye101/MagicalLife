using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Base
{
    /// <summary>
    /// Represents almost everything in a movable/harvested form.
    /// </summary>
    public abstract class Item : Unique
    {
        /// <summary>
        /// The name of this <see cref="Item"/>;
        /// </summary>
        public string Name { get; }
    }
}
