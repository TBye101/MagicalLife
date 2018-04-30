using MagicalLifeAPI.Filing.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking.Test
{
    [ProtoBuf.ProtoContract]
    public class ConcreteTest : BaseMessage
    {
        [ProtoBuf.ProtoMember(2)]
        public int ID2 = 4;

        public ConcreteTest() : base(1)
        {
        }
        public void Test()
        {
            MasterLog.DebugWriteLine("It worked!");
        }
    }
}
