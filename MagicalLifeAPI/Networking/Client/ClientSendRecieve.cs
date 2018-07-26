using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Networking.Server;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public static Queue<BaseMessage> RecievedMessages = new Queue<BaseMessage>();

        public static void Initialize(NetworkSettings networkSettings)
        {
            NetworkSettings = networkSettings;

            if (networkSettings.Mode == EngineMode.ClientOnly)
            {
                TCPClient = new TCPClient();
                TCPClient.Start(NetworkSettings.Port, NetworkSettings.ServerIP);
            }
        }

        /// <summary>
        /// Sends a message to the client.
        /// </summary>
        /// <param name="message"></param>
        public static void Send<T>(T message)
            where T : BaseMessage
        {
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
            //RecievedMessages.Enqueue(message);
            Task.Run(() => ClientProcessor.Process(message));
        }
    }
}