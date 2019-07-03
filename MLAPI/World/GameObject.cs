using MagicalLifeAPI.Components;
using ProtoBuf;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// All game objects implement this.
    /// Examples of a game object would be items, resources, structure parts, floors, and ceilings.
    /// </summary>
    [ProtoContract]
    public abstract class GameObject : HasComponents
    {
        public GameObject(bool irrelevant) : base(irrelevant)
        {
        }

        protected GameObject()
        {
            //Protobuf-net constructor.
        }

        /// <summary>
        /// If true, then this game object allows creatures to walk through the tile.
        /// </summary>
        /// <returns></returns>
        public abstract bool IsWalkable();
    }
}