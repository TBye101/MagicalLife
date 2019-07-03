using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeClient.Entity;
using MagicalLifeClient.Message;
using System.Collections.Generic;

namespace MagicalLifeClient
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