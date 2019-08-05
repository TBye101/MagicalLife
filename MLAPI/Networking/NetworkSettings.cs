namespace MLAPI.Networking
{
    /// <summary>
    /// Contains network settings to be used when setting up the game.
    /// </summary>
    public class NetworkSettings
    {
        /// <summary>
        /// If true, then the game is local and not over the network.
        /// </summary>
        public EngineMode Mode { get; set; }

        /// <summary>
        /// The IP of the server.
        /// </summary>
        public string ServerIp { get; set; }

        /// <summary>
        /// The port the server is listening on.
        /// </summary>
        public int Port { get; set; }

        public NetworkSettings(EngineMode mode)
        {
            this.Mode = mode;
        }

        public NetworkSettings(int port)
        {
            this.Port = port;
            this.Mode = EngineMode.ServerOnly;
        }

        public NetworkSettings(string serverIp, int port)
        {
            this.Mode = EngineMode.ClientOnly;
            this.ServerIp = serverIp;
            this.Port = port;
        }
    }
}