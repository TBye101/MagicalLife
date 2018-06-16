using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Serialization;
using System.Collections.Generic;

namespace MagicalLifeClient.Processing
{
    /// <summary>
    /// Handles client side message processing.
    /// </summary>
    public class ClientProcessor
    {
        /// <summary>
        /// Key: The ID of the message to be handled.
        /// Value: The handler for that ID.
        /// </summary>
        private static Dictionary<int, MessageHandler> MessageHandlers = new Dictionary<int, MessageHandler>();

        public static void Initialize(List<MessageHandler> handlers)
        {
            foreach (MessageHandler item in handlers)
            {
                AddHandler(item);
            }
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