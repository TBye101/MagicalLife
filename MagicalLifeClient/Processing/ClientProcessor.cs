using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Message_Handlers;
using System.Collections.Generic;

namespace MagicalLifeClient.Processing
{
    /// <summary>
    /// Handles client side message processing.
    /// </summary>
    public static class ClientProcessor
    {
        /// <summary>
        /// Key: The ID of the message to be handled.
        /// Value: The handler for that ID.
        /// </summary>
        private static Dictionary<int, MessageHandler> MessageHandlers = new Dictionary<int, MessageHandler>();

        public static void Initialize()
        {
            AddHandler(new ConcreteTestHandler());

            //Least important messages
            AddHandler(new WorldTransferMessageHandler());
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