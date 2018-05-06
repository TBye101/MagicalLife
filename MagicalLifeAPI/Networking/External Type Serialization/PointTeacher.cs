using MagicalLifeAPI.Protobuf;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking.External_Type_Serialization
{
    public class PointTeacher : ITeachSerialization
    {
        public void Teach()
        {
            MetaType meta = RuntimeTypeModel.Default.Add(typeof(Microsoft.Xna.Framework.Point), false);
            meta.Add(1, "X");
            meta.Add(2, "Y"); 
        }
    }
}
