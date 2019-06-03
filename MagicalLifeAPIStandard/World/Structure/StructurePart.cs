using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.GUI;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.World.Base
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
        public Guid PartID { get; set; }

        [ProtoMember(2)]
        public int Durability { get; set; }

        [ProtoMember(3)]
        private bool Walkable { get; set; }

        /// <summary>
        /// The unique ID of the structure this part belongs to.
        /// </summary>
        [ProtoMember(4)]
        public Guid UniqueStructureID { get; }

        /// <param name="durability"></param>
        /// <param name="isWalkable"></param>
        /// <param name="visual"></param>
        /// <param name="partID">A constant ID utilized to identify this part of a structure across all games and saves.</param>
        /// <param name="uniqueStructureID">The unique ID of the structure this part belongs to.</param>
        public StructurePart(int durability, bool isWalkable, AbstractVisual visual, Guid partID, Guid uniqueStructureID)
            : base(false)
        {
            this.PartID = partID;
            this.Durability = durability;
            this.Walkable = isWalkable;
            this.UniqueStructureID = uniqueStructureID;

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
