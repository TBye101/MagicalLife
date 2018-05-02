namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// The base class for all stone-like resources.
    /// </summary>
    public abstract class StoneBase : Resource
    {
        public StoneBase(string name, int count) : base(name, count)
        {
        }

        /// <summary>
        /// Gets the name of the texture to use when this stone is not adjacent to any other tile with a stone resource.
        /// </summary>
        /// <returns></returns>
        public abstract string GetUnconnectedTexture();

        /// <summary>
        /// Gets the name of the texture to use when this stone is connected to another stone.
        /// </summary>
        /// <returns></returns>
        public abstract string GetConnectedOneTexture();

        /// <summary>
        /// Gets the name of the texture to use when this stone is connected to two stone resources in adjacent tiles.
        /// </summary>
        /// <returns></returns>
        public abstract string GetConnectedTwoTexture();

        /// <summary>
        /// Gets the name of the texture to use when this stone is connected to three stone resources in adjacent tiles.
        /// </summary>
        /// <returns></returns>
        public abstract string GetConnectedThreeTexture();

        /// <summary>
        /// Gets the name of the texture to use when this stone is connected to four stone resources in adjacent tiles.
        /// </summary>
        /// <returns></returns>
        public abstract string GetConnectedFourTexture();
    }
}