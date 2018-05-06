using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking
{
    /// <summary>
    /// Any class that implements this teaches the serializer how to serialize some external type.
    /// </summary>
    public interface ITeachSerialization
    {
        void Teach(RuntimeTypeModel model);
    }
}
