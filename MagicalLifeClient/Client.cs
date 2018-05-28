using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Message_Handlers;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeClient.Entity;
using MagicalLifeClient.Message_Handlers;
using MagicalLifeClient.Processing;
using MagicalLifeNetworking.Messages;
using System;
using System.Collections.Generic;

namespace MagicalLifeClient
{
    /// <summary>
    /// Controls some high level functions of the server.
    /// </summary>
    public static class Client
    {
        /// <summary>
        /// The tick the client is executing.
        /// </summary>
        public static UInt64 GameTick = 0;

        /// <summary>
        /// The event that is raised when the game ticks.
        /// </summary>
        public static event EventHandler<UInt64> ClientTick;

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
                new ConcreteTestHandler(),

                //Least important messages
                new WorldTransferMessageHandler()
            };
        }

        /// <summary>
        /// How the server handles tick messages.
        /// </summary>
        /// <param name="msg"></param>
        public static void Tick(ServerTickMessage msg)
        {
            UInt64 ticksBehind = msg.Tick - GameTick - 1;

            if (ticksBehind != 0)
            {
                MasterLog.DebugWriteLine("Running " + ticksBehind.ToString() + " tick(s) behind");
            }

            TickLoop(ticksBehind + 1);
        }

        private static void TickLoop(UInt64 times)
        {
            UInt64 i = 0;

            while (i != times)
            {
                GameTick++;

                if (ClientTick != null)
                {
                    ClientTick(null, GameTick);
                    MasterLog.DebugWriteLine("Client tick!");
                }
                i++;
            }
        }
    }
}