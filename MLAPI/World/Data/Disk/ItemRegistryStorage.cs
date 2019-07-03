using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Data.Disk.DataStorage;
using System;
using System.IO;

namespace MagicalLifeAPI.World.Data.Disk
{
    /// <summary>
    /// Used to store and load an item registry.
    /// </summary>
    public class ItemRegistryStorage
    {
        internal void SaveItemRegistry(ItemRegistry registry, AbstractWorldSink sink, Guid dimensionID)
        {
            string result = WorldStorage.DimensionPaths[dimensionID];
            sink.Receive(registry, result + Path.DirectorySeparatorChar + dimensionID + ".itemreg", dimensionID);
        }

        internal void SaveItemRegistry(Dimension dimension, AbstractWorldSink sink)
        {
            string result = WorldStorage.DimensionPaths[dimension.ID];
            sink.Receive(dimension.Items, result + Path.DirectorySeparatorChar + dimension.ID + ".itemreg", dimension.ID);
        }

        internal ItemRegistry LoadItemRegistry(Guid dimensionID)
        {
            using (StreamReader sr = new StreamReader(WorldStorage.DimensionPaths[dimensionID] + Path.DirectorySeparatorChar + dimensionID + ".itemreg"))
            {
                ItemRegistry reg = (ItemRegistry)ProtoUtil.TypeModel.DeserializeWithLengthPrefix(sr.BaseStream, null, typeof(ItemRegistry), ProtoBuf.PrefixStyle.Base128, 0);

                return reg;
            }
        }
    }
}