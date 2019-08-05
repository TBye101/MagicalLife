using System.Collections.Generic;
using MLAPI.Networking.Client;
using MLAPI.Networking.Serialization;
using MLAPI.Pathfinding;
using MLClient.Entity;
using MLClient.Message_Handlers;

namespace MLClient
{
    /// <summary>
    /// Controls some high level functions of the server.
    /// </summary>
    public static class Client
    {
        public static void Load()
        {
            MainPathFinder.Initialize();
            ClientProcessor.Initialize(GetMessageHandlers());
            EntityTicking.Initialize();
        }

        private static List<MessageHandler> GetMessageHandlers()
        {
            return new List<MessageHandler>()
            {
                new ServerTickMessageHandler(),
                new WorldModifierMessageHandler(),

                //Least important messages
                new WorldTransferHeaderMessageHandler(),
                new WorldTransferBodyMessageHandler(),
                new WorldTransferRegistryMessageHandler()
            };
        }
    }
}