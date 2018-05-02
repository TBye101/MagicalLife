using MagicalLifeAPI.Filing.Logging;

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