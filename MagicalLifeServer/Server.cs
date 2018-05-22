using MagicalLifeAPI.Load;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
        public static UInt64 GameTick = 0;

        /// <summary>
        /// The event that is raised when the game ticks.
        /// </summary>
        public static event EventHandler ServerTick;

        public static void Load()
        {
            Loader load = new Loader();
            string msg = "";
            load.LoadAll(ref msg, new List<System.Reflection.Assembly>()
            {
                Assembly.GetAssembly(typeof(Server))
            });
        }

        private static void SetupTick()
        {
            Timer a = new Timer(50);
            a.AutoReset = true;
            a.Elapsed += Tick;
        }

        private static void Tick(object sender, ElapsedEventArgs e)
        {
            GameTick++;
            ServerTick(sender, null);
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
