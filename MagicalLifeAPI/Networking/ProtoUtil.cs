using MagicalLifeAPI.Networking;
using MagicalLifeAPI.World.Tiles;
using ProtoBuf;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Protobuf
{
    /// <summary>
    /// Used to serialize and deserialize using https://github.com/mgravell/protobuf-net.
    /// </summary>
    public static class ProtoUtil
    {
        //Need a container to reference quickly for both serialization and deserialization of types

        /// <summary>
        /// Serializes the object to string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Serialize<T>(T data)
        {
            MemoryStream outputStream = new MemoryStream();
            Serializer.Serialize<T>(outputStream, data);

            StreamReader outputReader = new StreamReader(outputStream);
            return outputReader.ReadToEnd();
        }

        public static object Deserialize(Stream data)
        {
            BaseMessage Base = Serializer.Deserialize<BaseMessage>(data);
            
            if (Base.MessageType == 0)
            {
                Dirt dirt = Serializer.Deserialize<Dirt>(data);
            }

            return null;
            //maybe preregister each type with something that just looks up at the reference table for what the type's id says it is, then deserializes to that.
        }
    }
}
