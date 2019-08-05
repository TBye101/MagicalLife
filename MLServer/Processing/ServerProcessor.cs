using System.Collections.Generic;
using MLAPI.Error.InternalExceptions;
using MLAPI.Networking;
using MLAPI.Networking.Serialization;
using MLAPI.Networking.Server;
using MLServer.Processing.Message_Handlers;

namespace MLServer.Processing
{
    public static class ServerProcessor
    {
        /// <summary>
        /// Key: The ID of the message to be handled.
        /// Value: The handler for that ID.
        /// </summary>
        private static Dictionary<NetMessageId, MessageHandler> MessageHandlers = new Dictionary<NetMessageId, MessageHandler>();

        public static void Initialize()
        {
            ServerSendRecieve.MessageRecieved += ServerSendRecieve_MessageRecieved;

            //More important messages
            MessageHandlers.Add(NetMessageId.DisconnectMessage, new DisconnectMessageHandler());
            MessageHandlers.Add(NetMessageId.WorldModifierMessage, new WorldModifierMessageHandler());

            //Least important messages
            MessageHandlers.Add(NetMessageId.RouteCreatedMessage, new RouteCreatedMessageHandler());
            MessageHandlers.Add(NetMessageId.LoginMessage, new LoginMessageHandler());
        }

        private static void ServerSendRecieve_MessageRecieved(object sender, BaseMessage e)
        {
            Process(e);
        }

        public static void Process(BaseMessage msg)
        {
            bool success = MessageHandlers.TryGetValue(msg.Id, out MessageHandler handler);

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
            MessageHandlers.Add(handler.MessageId, handler);
        }
    }
}