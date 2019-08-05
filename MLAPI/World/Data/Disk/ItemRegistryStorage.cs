using System;
using System.IO;
using MLAPI.GameRegistry.Items;
using MLAPI.Networking.Serialization;
using MLAPI.World.Data.Disk.DataStorage;

namespace MLAPI.World.Data.Disk
{
    /// <summary>
    /// Used to store and load an item registry.
    /// </summary>
    public class ItemRegistryStorage
    {
        internal void SaveItemRegistry(ItemRegistry registry, AbstractWorldSink sink, Guid dimensionId)
        {
            string result = WorldStorage.DimensionPaths[dimensionId];
            sink.Receive(registry, result + Path.DirectorySeparatorChar + dimensionId + ".itemreg", dimensionId);
        }

        internal void SaveItemRegistry(Dimension dimension, AbstractWorldSink sink)
        {
            string result = WorldStorage.DimensionPaths[dimension.Id];
            sink.Receive(dimension.Items, result + Path.DirectorySeparatorChar + dimension.Id + ".itemreg", dimension.Id);
        }

        internal ItemRegistry LoadItemRegistry(Guid dimensionId)
        {
            using (StreamReader sr = new StreamReader(WorldStorage.DimensionPaths[dimensionId] + Path.DirectorySeparatorChar + dimensionId + ".itemreg"))
            {
                ItemRegistry reg = (ItemRegistry)ProtoUtil.TypeModel.DeserializeWithLengthPrefix(sr.BaseStream, null, typeof(ItemRegistry), ProtoBuf.PrefixStyle.Base128, 0);

                return reg;
            }
        }
    }
}