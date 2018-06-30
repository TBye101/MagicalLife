using MagicalLifeAPI.Filing.Logging;
using ProtoBuf.Meta;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;

namespace MagicalLifeAPI.Networking.Serialization
{
    /// <summary>
    /// Used to serialize and deserialize using https://github.com/mgravell/protobuf-net.
    /// </summary>
    public static class ProtoUtil
    {
        public static RuntimeTypeModel TypeModel;

        /// <summary>
        /// Value: The ID of a base message.
        /// Key: The type of the base message that the ID is connected with.
        /// </summary>
        public static Dictionary<int, Type> IDToMessage = new Dictionary<int, Type>();

        /// <summary>
        /// Serializes the object to string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Serialize<T>(T data)
        {
            try
            {
                using (MemoryStream outputStream = new MemoryStream())
                {
                    TypeModel.Serialize(outputStream, data);

                    return Convert.ToBase64String(outputStream.GetBuffer(),
                        0, (int)outputStream.Length);
                }
            }
            catch (Exception e)
            {
                MasterLog.DebugWriteLine(e.Message);
                return null;
            }
        }

        public static byte[] SerializeToByte<T>(T data)
        {
            try
            {
                using (MemoryStream outputStream = new MemoryStream())
                {
                    TypeModel.Serialize(outputStream, data);

                    return outputStream.GetBuffer();
                }
            }
            catch (Exception e)
            {
                MasterLog.DebugWriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Deserializes the message from bytes.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static BaseMessage Deserialize(byte[] data)
        {
            try
            {
                using (MemoryStream ms = new System.IO.MemoryStream(data))
                {
                    BaseMessage Base = (BaseMessage)TypeModel.Deserialize(ms, null, typeof(BaseMessage));

                    ms.Position = 0;
                    BaseMessage message = (BaseMessage)TypeModel.Deserialize(ms, null, IDToMessage[Base.ID]);
                    MasterLog.DebugWriteLine("Deserialized Message ID: " + message.ID.ToString());
                    return message;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Log.Debug(e, "Unknown message type!");
                return null;
            }
            catch (StackOverflowException e)
            {
                Log.Debug(e, "Possible message structure recursion!");
                return null;
            }
        }

        public static T Deserialize<T>(string data)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(data)))
                {
                    return (T)TypeModel.Deserialize(ms, null, typeof(T));
                }
            }
            catch (Exception e)
            {
                MasterLog.DebugWriteLine(e.Message);
                return default(T);
            }
        }
    }
}