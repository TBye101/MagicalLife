namespace MagicalLifeDedicatedServer.API.Settings
{
    public class ServerNetworkSettings
    {
        /// <summary>
        /// The port to host the server on.
        /// </summary>
        public int Port { get; set; }

        public ServerNetworkSettings(bool setDefault)
        {
            this.Port = 58902;
        }

        public ServerNetworkSettings()
        {
        }
    }
}