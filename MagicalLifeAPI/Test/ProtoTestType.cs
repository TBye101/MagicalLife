using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Test
{
    [ProtoBuf.ProtoContract]
    public class ProtoTestType
    {
        [ProtoBuf.ProtoMember(1)]
        public int a { get; set; } = 3;

        [ProtoBuf.ProtoMember(2)]
        public string b { get; set; } = "Test";
    }
}
