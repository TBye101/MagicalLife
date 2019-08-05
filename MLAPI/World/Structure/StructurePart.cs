using System;
using MLAPI.Visual;
using MLAPI.Visual.Rendering;
using ProtoBuf;

namespace MLAPI.World.Structure
{
    /// <summary>
    /// A part of a structure.
    /// </summary>
    [ProtoContract]
    public class StructurePart : GameObject
    {
        /// <summary>
        /// A constant ID utilized to identify this part of a structure across all games and saves.
        /// </summary>
        [ProtoMember(1)]
        public Guid PartId { get; set; }

        [ProtoMember(2)]
        public int Durability { get; set; }

        [ProtoMember(3)]
        private bool Walkable { get; set; }

        /// <summary>
        /// The unique ID of the structure this part belongs to.
        /// </summary>
        [ProtoMember(4)]
        public Guid UniqueStructureId { get; }

        /// <param name="durability"></param>
        /// <param name="isWalkable"></param>
        /// <param name="visual"></param>
        /// <param name="partId">A constant ID utilized to identify this part of a structure across all games and saves.</param>
        /// <param name="uniqueStructureId">The unique ID of the structure this part belongs to.</param>
        public StructurePart(int durability, bool isWalkable, AbstractVisual visual, Guid partId, Guid uniqueStructureId)
            : base(false)
        {
            this.PartId = partId;
            this.Durability = durability;
            this.Walkable = isWalkable;
            this.UniqueStructureId = uniqueStructureId;

            ComponentHasTexture textureComponent = new ComponentHasTexture(false);
            textureComponent.Visuals.Add(visual);
            this.AddComponent(textureComponent);
        }

        protected StructurePart()
        {
            //Protobuf-net constructor.
        }

        public override bool IsWalkable()
        {
            return this.Walkable;
        }
    }
}