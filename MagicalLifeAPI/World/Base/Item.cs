using MagicalLifeAPI.Universal;

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