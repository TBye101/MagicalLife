using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeServer.Processing.Message;
using System.Collections.Generic;

namespace MagicalLifeServer.Processing
{
    public static class ServerProcessor
    {
        /// <summary>
        /// Key: The ID of the message to be handled.
        /// Value: The handler for that ID.
        /// </summary>
        private static Dictionary<NetMessageID, MessageHandler> MessageHandlers = new Dictionary<NetMessageID, MessageHandler>();

        public static void Initialize()
        {
            ServerSendRecieve.MessageRecieved += ServerSendRecieve_MessageRecieved;

            //More important messages
            MessageHandlers.Add(NetMessageID.DisconnectMessage, new DisconnectMessageHandler());
            MessageHandlers.Add(NetMessageID.WorldModifierMessage, new WorldModifierMessageHandler());

            //Least important messages
            MessageHandlers.Add(NetMessageID.RouteCreatedMessage, new RouteCreatedMessageHandler());
            MessageHandlers.Add(NetMessageID.LoginMessage, new LoginMessageHandler());
        }

        private static void ServerSendRecieve_MessageRecieved(object sender, BaseMessage e)
        {
            Process(e);
        }

        public static void Process(BaseMessage msg)
        {
            bool success = MessageHandlers.TryGetValue(msg.ID, out MessageHandler handler);

            if (success)
            {
                handler.HandleMessage(msg);
            }
            else
            {
                throw new UnexpectedMessageException();
            }
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