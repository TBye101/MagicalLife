using MagicalLifeAPI.Universal;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// A base class for all resources.
    /// Resources in tiles are things such as minerals.
    /// </summary>
    public abstract class Resource : Unique
    {
        /// <summary>
        /// The display name of the resource.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// How much of the resources is left.
        /// </summary>
        public double Count { get; }
    }
}