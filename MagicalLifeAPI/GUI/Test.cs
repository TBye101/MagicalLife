using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServerShell
{
    [ProtoBuf.ProtoContract]
    public abstract class Test : MagicalLifeAPI.Universal.Unique
    {
        [ProtoBuf.ProtoMember(1)]
        int test = 3;

        public abstract void GoTEST();
    }
}
