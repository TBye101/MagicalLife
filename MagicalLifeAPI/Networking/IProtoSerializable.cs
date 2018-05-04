using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking
{
    /// <summary>
    /// Implemented by all objects which can be serialized.
    /// </summary>
    public interface IProtoSerializable
    {
        /// <summary>
        /// If true, then this type has subtypes which inherit from this type.
        /// </summary>
        /// <returns></returns>
        bool IHaveSubtypes();
    }
}
