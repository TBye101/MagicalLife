using MagicalLifeAPI.Networking;
using MagicalLifeAPI.World;
using MagicalLifeNetworking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer.Networking
{
    /// <summary>
    /// Used to hide the complexity of understanding where to send and receive data from.
    /// </summary>
    public static class ServerSendRecieve
    {
        /// <summary>
        /// If true, then the game is not over the network.
        /// </summary>
        private static bool Local;

        public static TCPServer TCPServer;

        /// <summary>
        /// The messages that have been received and are yet unprocessed. 
        /// </summary>
        public static Queue<BaseMessage> RecievedMessages = new Queue<BaseMessage>();

        /// <summary>
        /// Raised whenever the server receives a message.
        /// </summary>
        public static event EventHandler<BaseMessage> MessageRecieved;

        public static void Initialize(NetworkSettings networkSettings)
        {
            Local = networkSettings.Local;

            if (!Local)
            {
                TCPServer = new TCPServer();
                TCPServer.Start(networkSettings.Port);
            }
        }

        /// <summary>
        /// Sends a message to the client.
        /// </summary>
        /// <param name="message"></param>
        public static void Send<T>(T message, Socket client)
            where T : BaseMessage
        {
            if (Local)
            {
                ClientSendRecieve.Recieve(message);
            }
            else
            {
                TCPServer.Send<T>(message, client);
            }
        }

        /// <summary>
        /// Sends a message to all connected clients.
        /// </summary>
        /// <param name="message"></param>
        public static void SendAll<T>(T message)
            where T : BaseMessage
        {
            if (Local)
            {
                ClientSendRecieve.Recieve(message);
            }
            else
            {
                TCPServer.Broadcast<T>(message);
            }
        }

        /// <summary>
        /// Receives a message.
        /// </summary>
        /// <param name="message"></param>
        public static void Recieve(BaseMessage message)
        {
            RecievedMessages.Enqueue(message);
            RaiseMessageRecieved(null, message);
        }

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        private static void RaiseMessageRecieved(object sender, BaseMessage msg)
        {
            EventHandler<BaseMessage> handler = MessageRecieved;
            if (handler != null)
            {
                handler(sender, msg);
            }
        }
    }
}
