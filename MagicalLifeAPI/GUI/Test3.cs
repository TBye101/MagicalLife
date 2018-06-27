using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.GUI
{
    [ProtoBuf.ProtoContract]
    public class Test3 : Test2
    {
        [ProtoBuf.ProtoMember(1)]
        public int ID = 32;

        public override void ABSTRE()
        {
            throw new NotImplementedException();
        }

        public override void GoTEST()
        {
            throw new NotImplementedException();
        }
    }
}
