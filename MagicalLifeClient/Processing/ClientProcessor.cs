using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Message_Handlers;
using MagicalLifeAPI.Networking.Test;
using MagicalLifeClient.Processing.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeClient.Processing
{
    /// <summary>
    /// Handles client side message processing.
    /// </summary>
    public static class ClientProcessor
    {
        private static List<MessageHandler> Handlers = new List<MagicalLifeAPI.Networking.MessageHandler>();

        public static void Initialize()
        {
            ConcreteTestHandler test = new ConcreteTestHandler();

            Handlers.Insert(test.MessageID, test);

        }

        public static void Process(BaseMessage msg)
        {
            Handlers[msg.ID].HandleMessage(msg);
        }
    }
}
