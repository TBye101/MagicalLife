using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using System;
using System.IO;

namespace MagicalLifeAPI.World.Data.Disk
{
    /// <summary>
    /// Knows how to serialize a dimension.
    /// </summary>
    public class DimensionStorage
    {
        /// <summary>
        /// Creates folders for a new dimension.
        /// </summary>
        public void PrepareForDimension(Guid dimensionID)
        {
            DirectoryInfo info = Directory.CreateDirectory(WorldStorage.GameSaveRoot + Path.DirectorySeparatorChar + dimensionID);
            WorldStorage.DimensionPaths.Add(dimensionID, info.FullName);
        }

        /// <summary>
        /// Loads the dimension, without actually loading any chunks.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal Dimension Load(Guid id)
        {
            Dimension dimension; //need name, and chunks
            DimensionHeader header = this.LoadDimensionHeader(id);

            //A array of unloaded chunks.
            ProtoArray<Chunk> chunks = new ProtoArray<Chunk>(header.Width, header.Height);

            dimension = new Dimension(header.DimensionName, chunks, header.ID, WorldStorage.ItemStorage.LoadItemRegistry(id));

            return dimension;
        }

        /// <summary>
        /// Serializes the dimension.
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="sink"></param>
        internal void Serialize(Dimension dimension, AbstractWorldSink sink)
        {
            this.SerializeDimensionHeader(dimension, sink);
            this.SerializeItemRegistry(dimension, sink);

            int width = dimension.Width;
            int height = dimension.Height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Chunk chunk = dimension.GetChunk(x, y);
                    WorldStorage.ChunkStorage.SaveChunk(chunk, dimension.ID, sink);
                }
            }
        }

        private void SerializeItemRegistry(Dimension dimension, AbstractWorldSink sink)
        {
            WorldStorage.ItemStorage.SaveItemRegistry(dimension, sink);
        }

        /// <summary>
        /// Loads the dimension header for the specified dimension.
        /// </summary>
        /// <param name="id">The ID of the dimension.</param>
        /// <param name="dimensionRoot">The path to the dimension's root directory.</param>
        /// <returns></returns>
        internal DimensionHeader LoadDimensionHeader(Guid id, string dimensionRoot)
        {
            using (StreamReader sr = new StreamReader(dimensionRoot + Path.DirectorySeparatorChar + id + ".header"))
            {
                DimensionHeader result = (DimensionHeader)ProtoUtil.TypeModel.DeserializeWithLengthPrefix(sr.BaseStream, null, typeof(DimensionHeader), ProtoBuf.PrefixStyle.Base128, 0);

                return result;
            }
        }

        /// <summary>
        /// Loads the dimension header for the specified dimension.
        /// </summary>
        /// <param name="id">The ID of the dimension.</param>
        /// <returns></returns>
        internal DimensionHeader LoadDimensionHeader(Guid id)
        {
            string dimensionRoot = WorldStorage.DimensionPaths[id];
            return this.LoadDimensionHeader(id, dimensionRoot);
        }

        private void SerializeDimensionHeader(Dimension dimension, AbstractWorldSink sink)
        {
            string dimensionRoot = WorldStorage.DimensionPaths[dimension.ID];
            DimensionHeader header = new DimensionHeader(dimension.DimensionName, dimension.ID, dimension.Width, dimension.Height);
            SerializeDimensionHeader(header, sink, dimensionRoot);
        }

        internal void SerializeDimensionHeader(DimensionHeader header, AbstractWorldSink sink, string dimensionRoot)
        {
            sink.Receive(header, dimensionRoot + Path.DirectorySeparatorChar + header.ID + ".header", header.ID);
        }
    }
}