﻿using MagicalLifeAPI.Networking;
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
        /// <summary>
        /// Key: The ID of the message to be handled.
        /// Value: The handler for that ID.
        /// </summary>
        private static Dictionary<int, MessageHandler> MessageHandlers = new Dictionary<int, MessageHandler>();

        public static void Initialize()
        {
            ConcreteTestHandler test = new ConcreteTestHandler();

            AddHandler(test);
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
