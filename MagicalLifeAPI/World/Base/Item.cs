using MagicalLifeAPI.Universal;

namespace MagicalLifeAPI.World.Base
{
    /// <summary>
    /// Represents almost everything in a movable/harvested form.
    /// </summary>
    public abstract class Item : Unique, IGameLoader
    {
        /// <summary>
        /// The name of this <see cref="Item"/>;
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// See <see cref="IGameLoader.GetTotalOperations"/> for information.
        /// </summary>
        /// <returns></returns>
        public abstract int GetTotalOperations();

        /// <summary>
        /// See <see cref="IGameLoader.InitialStartup(ref int)"/> for information.
        /// </summary>
        /// <returns></returns>
        public abstract void InitialStartup(ref int progress);
    }
}