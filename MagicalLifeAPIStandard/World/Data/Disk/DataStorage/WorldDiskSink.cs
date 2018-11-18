using MagicalLifeAPI.Networking.Serialization;
using System;
using System.Diagnostics;
using System.IO;

namespace MagicalLifeAPI.World.Data.Disk.DataStorage
{
    /// <summary>
    /// Serializes Protobuf-net objects to disk.
    /// </summary>
    public class WorldDiskSink : AbstractWorldSink
    {
        public override void Receive<T>(T data, string filePath, Guid dimensionID)
        {
            this.ValidateData(data);
            byte[] worldData = ProtoUtil.Serialize(data);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                fs.Write(worldData, 0, worldData.Length);
            }
        }

        [Conditional("DEBUG")]
        private void ValidateData<T>(T data)
        {
            //Checking to see if the object passed in is serializable by Protobuf-net.
            //Otherwise, blow sky high!
            if (!data.GetType().IsDefined(typeof(ProtoBuf.ProtoContractAttribute), false))
            {
                throw new InvalidDataException();
            }
        }
    }
}