using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeNetworking.Serialization;

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