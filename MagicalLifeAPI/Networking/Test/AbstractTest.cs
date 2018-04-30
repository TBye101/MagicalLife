using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking.Test
{
    [ProtoBuf.ProtoContract]
    [ProtoBuf.ProtoInclude(25, typeof(ConcreteTest))]
    public abstract class AbstractTest
    {
        public AbstractTest()
        {

        }

        [ProtoBuf.ProtoMember(1)]
        public int ID = 3;

        public abstract void Test();
    }
}
