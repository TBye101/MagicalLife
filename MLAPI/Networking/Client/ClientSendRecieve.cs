using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.Server;
using System.Collections.Generic;

namespace MagicalLifeAPI.Networking.Client
{
    /// <summary>
    /// Used to hide the complexity of understanding where to send and receive data from.
    /// </summary>
    public static class ClientSendRecieve
    {
        /// <summary>
        /// If true, then the game is not over the network.
        /// </summary>
        private static NetworkSettings NetworkSettings;

        private static TCPClient TCPClient;

        /// <summary>
        /// Raised whenever a message is received
        /// </summary>
        internal static Queue<BaseMessage> RecievedMessages { get; set; } = new Queue<BaseMessage>();

        internal static void Initialize(NetworkSettings networkSettings)
        {
            NetworkSettings = networkSettings;

            if (networkSettings.Mode == EngineMode.ClientOnly)
            {
                TCPClient = new TCPClient();
                TCPClient.Start(NetworkSettings.Port, NetworkSettings.ServerIP);
            }
            else
            {
                ServerSendRecieve.Recieve(new LoginMessage());
            }
        }

        private static int TotalSent = 0;

        /// <summary>
        /// Sends a message to the server.
        /// </summary>
        /// <param name="message"></param>
        public static void Send<T>(T message)
            where T : BaseMessage
        {
            TotalSent++;
            MasterLog.DebugWriteLine("Sent total: " + TotalSent.ToString());
            if (NetworkSettings.Mode == EngineMode.ServerAndClient)
            {
                ServerSendRecieve.Recieve(message);
            }
            else
            {
                TCPClient.Send<T>(message);
            }
        }

        /// <summary>
        /// Receives a message.
        /// </summary>
        /// <param name="message"></param>
        public static void Recieve(BaseMessage message)
        {
            ClientProcessor.Process(message);
        }
    }
}