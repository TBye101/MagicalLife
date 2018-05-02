using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Test;
using ProtoBuf.Meta;
using System;
using System.IO;

namespace MagicalLifeAPI.Protobuf
{
    /// <summary>
    /// Used to serialize and deserialize using https://github.com/mgravell/protobuf-net.
    /// </summary>
    public static class ProtoUtil
    {
        public static TypeModel TypeModel;

        /// <summary>
        /// Serializes the object to string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Serialize<T>(T data)
        {
            using (MemoryStream outputStream = new MemoryStream())
            {
                TypeModel.Serialize(outputStream, data);

                return Convert.ToBase64String(outputStream.GetBuffer(),
                    0, (int)outputStream.Length);
            }
        }

        public static object Deserialize(byte[] data)
        {
            using (MemoryStream ms = new System.IO.MemoryStream(data))
            {
                BaseMessage Base = (BaseMessage)TypeModel.Deserialize(ms, null, typeof(BaseMessage));
                if (Base.ID == 1)
                {
                    ms.Position = 0;
                    ConcreteTest test = (ConcreteTest)TypeModel.Deserialize(ms, null, typeof(ConcreteTest));
                    return test;
                }
            }

            throw new Exception("Unknown message type!");
        }
    }
}