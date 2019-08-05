using System;
using System.Collections.Generic;
using MLAPI.DataTypes;
using ProtoBuf;

namespace MLAPI.World.Structure
{
    /// <summary>
    /// Represents an entire structure in the world.
    /// </summary>
    [ProtoContract]
    public class Structure
    {
        /// <summary>
        /// The display name of this structure.
        /// </summary>
        [ProtoMember(1)]
        public string Name { get; private set; }

        /// <summary>
        /// The unique ID of the player/faction that "owns" this structure. Should be equal to <see cref="Guid.Empty"/> if unowned.
        /// </summary>
        [ProtoMember(2)]
        public Guid OwnerId { get; private set; }

        /// <summary>
        /// Holds the location of all the parts of this structure.
        /// </summary>
        [ProtoMember(3)]
        public List<Point3D> Parts { get; private set; }

        /// <summary>
        /// The id that is shared by all instances of this structure.
        /// </summary>
        [ProtoMember(4)]
        public Guid StructureId { get; private set; }

        /// <summary>
        /// The unique ID of this specific structure.
        /// </summary>
        [ProtoMember(5)]
        public Guid UniqueId { get; private set; }

        /// <param name="name">The display name of this structure.</param>
        /// <param name="ownerId">The unique ID of the player/faction that "owns" this structure. Should be equal to <see cref="Guid.Empty"/> if unowned.</param>
        /// <param name="parts">Holds all of the locations of the parts of this structure.</param>
        /// <param name="structureId">Should be a constant ID that is usable to identify a structure across all games and saves.</param>
        public Structure(string name, Guid ownerId, List<Point3D> parts, Guid structureId)
        {
            this.Name = name;
            this.OwnerId = ownerId;
            this.Parts = parts;
            this.StructureId = structureId;
            this.UniqueId = Guid.NewGuid();
        }

        protected Structure()
        {
            //Protobuf-net constructor.
        }
    }
}