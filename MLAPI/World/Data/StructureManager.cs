using System;
using System.Collections.Generic;
using MLAPI.World.Data.Disk;
using ProtoBuf;

namespace MLAPI.World.Data
{
    /// <summary>
    /// Handles entire structure knowledge in a similar fashion to the chunk manager.
    /// </summary>
    public class StructureManager
    {
        /// <summary>
        /// Holds all currently loaded structures.
        /// </summary>
        [ProtoMember(1)]
        public Dictionary<Guid, ObjectAccess<Structure.Structure>> StructureStorage { get; private set; }

        /// <summary>
        /// The ID of the dimension that this chunk manager services.
        /// </summary>
        [ProtoMember(2)]
        private readonly Guid DimensionID;

        public StructureManager(Guid dimensionID)
        {
            this.DimensionID = dimensionID;
            this.StructureStorage = new Dictionary<Guid, ObjectAccess<Structure.Structure>>();
        }

        public StructureManager()
        {
            //Protobuf-net constructor.
        }

        /// <summary>
        /// Attempts to return a structure. Returns null if no structure was found.
        /// </summary>
        /// <returns></returns>
        public Structure.Structure GetStructure(Guid structureID)
        {
            ObjectAccess<Structure.Structure> storage = this.StructureStorage[structureID];
            storage.Recorder.Access();

            if (storage.Object == null)
            {
                return WorldStorage.StructureStorage.LoadStructure(structureID, this.DimensionID);
            }
            else
            {
                return storage.Object;
            }
        }
    }
}