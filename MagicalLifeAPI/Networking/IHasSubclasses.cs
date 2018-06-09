using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Networking
{
    /// <summary>
    /// Implemented by all classes that must be serialized and have subclasses.
    /// </summary>
    public interface IHasSubclasses
    {
        /// <summary>
        /// Returns information used by the TypeModel to serialize and deserialize an abstract class and its subclasses.
        /// Key: The type of the subclass(es) of the implementing type.
        /// Value: The inheritance ID that is normally used by the <see cref="ProtoBuf.ProtoIncludeAttribute"/>
        /// </summary>
        /// <returns></returns>
        Dictionary<Type, int> GetSubclassInformation();

        /// <summary>
        /// Returns the base type that all the subclasses implement / inherit from.
        /// </summary>
        /// <returns></returns>
        Type GetBaseType();
    }
}