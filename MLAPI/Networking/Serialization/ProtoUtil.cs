using MagicalLifeAPI.Filing.Logging;
using ProtoBuf;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MagicalLifeAPI.Networking.Serialization
{
    /// <summary>
    /// Used to serialize and deserialize using https://github.com/mgravell/protobuf-net.
    /// </summary>
    public static class ProtoUtil
    {
        public static RuntimeTypeModel TypeModel { get; set; }

        /// <summary>
        /// Value: The ID of a base message.
        /// Key: The type of the base message that the ID is connected with.
        /// </summary>
        public static Dictionary<NetMessageID, Type> IDToMessage { get; private set; } = new Dictionary<NetMessageID, Type>();

        /// <summary>
        /// Serializes the object to string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Serialize<T>(T data)
        {
            try
            {
                using (MemoryStream outputStream = new MemoryStream())
                {
                    TypeModel.SerializeWithLengthPrefix(outputStream, data, typeof(T), ProtoBuf.PrefixStyle.Base128, 0);
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
                    BaseMessage Base = (BaseMessage)TypeModel.DeserializeWithLengthPrefix(ms, null, typeof(BaseMessage), ProtoBuf.PrefixStyle.Base128, 0);
                    return Base;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                MasterLog.DebugWriteLine(e, "Unknown message type!");
                return null;
            }
        }

        public static T Deserialize<T>(byte[] data)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return (T)TypeModel.DeserializeWithLengthPrefix(ms, null, typeof(T), PrefixStyle.Base128, 0);
                }
            }
            catch (Exception e)
            {
                MasterLog.DebugWriteLine(e.Message);
                return default;
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
                return default;
            }
        }

        /// <summary>
        /// Registers a type as serializable.
        /// </summary>
        /// <param name="serializableClassType"></param>
        internal static void RegisterSerializableClass(Type serializableClassType)
        {
            MasterLog.DebugWriteLine("Registering type with Protobuf-net: " + serializableClassType.AssemblyQualifiedName);
            TypeModel.Add(serializableClassType, true);
        }

        /// <summary>
        /// Registers a type as the subclass of another type.
        /// </summary>
        /// <param name="subclass"></param>
        /// <param name="baseClass"></param>
        internal static void RegisterSubclass(Type subclass, Type baseClass)
        {
            MasterLog.DebugWriteLine("Registering subtype with Protobuf-net: " + subclass.AssemblyQualifiedName);
            MasterLog.DebugWriteLine("Base class name: " + baseClass.AssemblyQualifiedName);
            MetaType meta = TypeModel.Add(baseClass, true);

            int largestFieldNumber = 0;
            SubType[] subtypes = meta.GetSubtypes();
            ValueMember[] baseFields = meta.GetFields();

            foreach (ValueMember item in baseFields)
            {
                if (item.FieldNumber > largestFieldNumber)
                {
                    largestFieldNumber = item.FieldNumber;
                }
            }

            foreach (SubType item in subtypes)
            {
                if (item.FieldNumber > largestFieldNumber)
                {
                    largestFieldNumber = item.FieldNumber;
                }
            }

            meta.AddSubType(largestFieldNumber + 1, subclass);
            MasterLog.DebugWriteLine("Subclass ID: " + (subtypes.Length + 1).ToString());
        }

        /// <summary>
        /// Registers all serializable types found within an assembly.
        /// While this is slower than <see cref="RegisterSerializableClass(Type)"/> and <see cref="RegisterSubclass(Type, Type)"/>, this is more convenient.
        /// </summary>
        /// <param name="assembly"></param>
        internal static void RegisterAssembly(Assembly assembly)
        {
            Type[] allTypes = assembly.GetExportedTypes();

            foreach (Type item in allTypes)
            {
                Attribute attribute = item.GetCustomAttribute(typeof(ProtoContractAttribute));

                if (attribute != null)
                {
                    RegisterSerializableClass(item);

                    if (item.BaseType != null)
                    {
                        Attribute baseAttribute = item.BaseType.GetCustomAttribute(typeof(ProtoContractAttribute));

                        if (baseAttribute != null)
                        {
                            RegisterSubclass(item, item.BaseType);
                        }
                    }

                    Type[] interfaces = item.GetInterfaces();
                    foreach (Type iface in interfaces)
                    {
                        Attribute protoAttribute = iface.GetCustomAttribute(typeof(ProtoContractAttribute));
                        if (protoAttribute != null && !item.BaseType.GetInterfaces().Contains(iface))
                        {
                            RegisterSubclass(item, iface);
                        }
                    }

                    if (item.GetCustomAttribute(typeof(Surrogate)) is Surrogate surrogateAttribute)
                    {
                        MasterLog.DebugWriteLine("Setting a surrogate:");
                        MasterLog.DebugWriteLine("Class that needs a surrogate: " + surrogateAttribute.NeedsSurrogate.Name);
                        MasterLog.DebugWriteLine("Surrogate: " + surrogateAttribute.SurrogateType.Name);
                        TypeModel.Add(surrogateAttribute.NeedsSurrogate, true).SetSurrogate(surrogateAttribute.SurrogateType);
                    }
                }
            }
        }
    }
}