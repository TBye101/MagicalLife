using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Networking.Serialization;

namespace MagicalLifeAPI.Networking.Test
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