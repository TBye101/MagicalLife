using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Networking.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking.Message_Handlers
{
    public class ConcreteTestHandler : MessageHandler
    {
        public ConcreteTestHandler() : base(1)
        {

        }

        public override void HandleMessage(BaseMessage message)
        {
            MasterLog.DebugWriteLine("It worked!");
        }
    }
}
