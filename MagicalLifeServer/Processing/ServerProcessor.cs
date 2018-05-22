using MagicalLifeAPI.Networking;
using MagicalLifeServer.Message_Handlers;
using MagicalLifeServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer.Processing
{
    public static class ServerProcessor
    {
        /// <summary>
        /// Key: The ID of the message to be handled.
        /// Value: The handler for that ID.
        /// </summary>
        private static Dictionary<int, MessageHandler> MessageHandlers = new Dictionary<int, MessageHandler>();

        public static void Initialize()
        {
            ServerSendRecieve.MessageRecieved += ServerSendRecieve_MessageRecieved;

            //More important messages

            //Least important messages
            MessageHandlers.Add(3, new RouteCreatedMessageHandler());
        }

        private static void ServerSendRecieve_MessageRecieved(object sender, BaseMessage e)
        {
            Process(e);
        }

        public static void Process(BaseMessage msg)
        {
            MessageHandlers.TryGetValue(msg.ID, out MessageHandler handler);
            handler.HandleMessage(msg);
        }

        /// <summary>
        /// Properly adds a message handler.
        /// </summary>
        /// <param name="handler"></param>
        public static void AddHandler(MessageHandler handler)
        {
            MessageHandlers.Add(handler.MessageID, handler);
        }
    }
}
