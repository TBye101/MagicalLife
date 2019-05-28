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
        [ProtoMember(1)]
        public Structure Parent { get; private set; }

        [ProtoMember(2)]
        public Guid PartID { get; set; }

        [ProtoMember(3)]
        public int Durability { get; set; }

        [ProtoMember(4)]
        public Point2D Location { get; private set; }

        [ProtoMember(5)]
        private bool Walkable { get; set; }

        public StructurePart(Structure parent, int durability, Point2D location, bool isWalkable, AbstractVisual visual)
            : base(false)
        {
            this.Parent = parent;
            this.PartID = Guid.NewGuid();
            this.Durability = durability;
            this.Location = location;
            this.Walkable = isWalkable;

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
