using MagicalLifeAPI.Load;
using MagicalLifeNetworking.Messages;
using MagicalLifeServer.Networking;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Timers;

namespace MagicalLifeServer
{
    /// <summary>
    /// Commands some high level functions of a server.
    /// </summary>
    public static class Server
    {
        /// <summary>
        /// The tick the server is executing.
        /// </summary>
        public static UInt64 GameTick { get; private set; } = 0;

        private static Timer TickTimer = new Timer(50);

        /// <summary>
        /// The event that is raised when the game ticks.
        /// </summary>
        public static event EventHandler<UInt64> ServerTick;

        public static void Load()
        {
            Loader load = new Loader();
            string msg = "";
            load.LoadAll(ref msg, new List<System.Reflection.Assembly>()
            {
                Assembly.GetAssembly(typeof(Server))//App is not allowed through the firewall, need to reprompt or something. 
            });
        }

        private static void SetupTick()
        {
            TickTimer.AutoReset = true;
            TickTimer.Elapsed += Tick;
            TickTimer.Start();
        }

        private static void Tick(object sender, ElapsedEventArgs e)
        {
            GameTick++;
            ServerSendRecieve.SendAll(new ServerTickMessage(GameTick));
            RaiseServerTick(sender, GameTick);
        }

        private static void RaiseServerTick(object sender, UInt64 tick)
        {
            EventHandler<UInt64> eventHandler = ServerTick;

            if (eventHandler != null)
            {
                eventHandler(sender, tick);
            }
        }

        /// <summary>
        /// Starts the internal tick system, and begins running game logic.
        /// </summary>
        public static void StartGame()
        {
            SetupTick();
        }
    }
}