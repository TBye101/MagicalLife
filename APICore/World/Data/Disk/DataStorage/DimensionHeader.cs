using ProtoBuf;
using System;

namespace MagicalLifeAPI.World.Data.Disk.DataStorage
{
    /// <summary>
    /// Holds the header information for a dimension.
    /// </summary>
    [ProtoContract]
    public class DimensionHeader
    {
        /// <summary>
        /// The display name of the dimension.
        /// </summary>
        [ProtoMember(1)]
        public string DimensionName { get; private set; }

        /// <summary>
        /// The unique ID of the dimension.
        /// </summary>
        [ProtoMember(2)]
        public Guid ID { get; private set; }

        /// <summary>
        /// The width of the dimension in chunks.
        /// </summary>
        [ProtoMember(3)]
        public int Width { get; private set; }

        /// <summary>
        /// The height of the dimension in chunks.
        /// </summary>
        [ProtoMember(4)]
        public int Height { get; private set; }

        public DimensionHeader(string dimensionName, Guid id, int width, int height)
        {
            this.DimensionName = dimensionName;
            this.ID = id;
            this.Width = width;
            this.Height = height;
        }

        public DimensionHeader()
        {
            //Protobuf-net constructor.
        }
    }
}