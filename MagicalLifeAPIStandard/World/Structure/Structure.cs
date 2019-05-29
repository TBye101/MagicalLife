using MagicalLifeAPI.DataTypes;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.World.Base
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
        public Guid OwnerID { get; private set; }

        /// <summary>
        /// Holds the location of all the parts of this structure.
        /// </summary>
        [ProtoMember(3)]
        public List<Point2D> Parts { get; private set; }

        /// <param name="name">The display name of this structure.</param>
        /// <param name="ownerID">The unique ID of the player/faction that "owns" this structure. Should be equal to <see cref="Guid.Empty"/> if unowned.</param>
        /// <param name="parts">Holds all of the locations of the parts of this structure.</param>
        public Structure(string name, Guid ownerID, List<Point2D> parts)
        {
            this.Name = name;
            this.OwnerID = ownerID;
            this.Parts = parts;
        }

        protected Structure()
        {
            //Protobuf-net constructor.
        }
    }
}
