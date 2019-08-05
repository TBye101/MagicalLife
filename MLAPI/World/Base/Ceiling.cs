using MLAPI.Visual;
using MLAPI.Visual.Rendering;
using ProtoBuf;

namespace MLAPI.World.Base
{
    /// <summary>
    /// Represents the ceiling of a tile.
    /// </summary>
    [ProtoContract]
    public class Ceiling : GameObject
    {
        [ProtoMember(1)]
        private bool Walkable { get; set; }

        /// <param name="visual">The visual representation of this floor to render.</param>
        /// <param name="walkable">If true it is possible to walk on this tile.</param>
        public Ceiling(AbstractVisual visual, bool walkable)
        {
            ComponentHasTexture textureComponent = new ComponentHasTexture(false);

            textureComponent.Visuals.Add(visual);
            this.AddComponent(textureComponent);
            this.Walkable = walkable;
        }

        protected Ceiling()
        {
            //Protobuf-net constructor.
        }

        public override bool IsWalkable()
        {
            return this.Walkable;
        }
    }
}