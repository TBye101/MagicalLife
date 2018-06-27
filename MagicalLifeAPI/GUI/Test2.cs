using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.GUI
{
    [ProtoBuf.ProtoContract]
    public abstract class Test2 : MagicalLifeServerShell.Test
    {
        [ProtoBuf.ProtoMember(1)]
        int b = 4;

        public abstract void ABSTRE();
    }
}
