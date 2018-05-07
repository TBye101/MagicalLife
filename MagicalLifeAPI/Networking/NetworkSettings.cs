using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking
{
    /// <summary>
    /// Contains network settings to be used when setting up the game.
    /// </summary>
    public class NetworkSettings
    {
        /// <summary>
        /// If true, then the game is local and not over the network.
        /// </summary>
        public bool Local { get; set; }

        /// <summary>
        /// The IP of the server.
        /// </summary>
        public string ServerIP { get; set; }

        /// <summary>
        /// The port the server is listening on.
        /// </summary>
        public int Port { get; set; }

        public NetworkSettings(bool local)
        {
            this.Local = local;
        }

        public NetworkSettings(string serverIP, int port)
        {
            this.Local = false;
            this.ServerIP = serverIP;
            this.Port = port;
        }
    }
}
