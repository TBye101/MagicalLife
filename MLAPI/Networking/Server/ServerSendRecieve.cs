using System;
using System.Collections.Generic;
using System.Net.Sockets;
using MLAPI.Filing.Logging;
using MLAPI.Networking.Client;
using MLAPI.Networking.Serialization;

namespace MLAPI.Networking.Server
{
    /// <summary>
    /// Used to hide the complexity of understanding where to send and receive data from.
    /// </summary>
    public static class ServerSendRecieve
    {
        /// <summary>
        /// If true, then the game is not over the network.
        /// </summary>
        private static EngineMode Local;

        internal static TcpServer TcpServer;

        /// <summary>
        /// The messages that have been received and are yet unprocessed.
        /// </summary>
        internal static Queue<BaseMessage> RecievedMessages { get; set; } = new Queue<BaseMessage>();

        /// <summary>
        /// Raised whenever the server receives a message.
        /// </summary>
        public static event EventHandler<BaseMessage> MessageRecieved;

        public static void Initialize(NetworkSettings networkSettings)
        {
            Local = networkSettings.Mode;

            if (Local == EngineMode.ServerAndClient || Local == EngineMode.ServerOnly)
            {
                TcpServer = new TcpServer();
                TcpServer.Start(networkSettings.Port);
            }
        }

        /// <summary>
        /// Sends a message to the client.
        /// </summary>
        /// <param name="message"></param>
        public static void Send<T>(T message, Socket client)
            where T : BaseMessage
        {
            if (Local == EngineMode.ServerAndClient)
            {
                ClientSendRecieve.Recieve(message);
            }
            else
            {
                TcpServer.Send<T>(message, client);
            }
        }

        public static void Send<T>(T message, Guid player)
            where T : BaseMessage
        {
            if (Local == EngineMode.ServerAndClient)
            {
                ClientSendRecieve.Recieve(message);
            }
            else
            {
                TcpServer.Send(message, player);
            }
        }

        /// <summary>
        /// Sends a message to all connected clients.
        /// </summary>
        /// <param name="message"></param>
        public static void SendAll<T>(T message)
            where T : BaseMessage
        {
            if (Local == EngineMode.ServerAndClient)
            {
                ClientSendRecieve.Recieve(message);
            }
            else
            {
                TcpServer.Broadcast<T>(message);
            }
        }

        /// <summary>
        /// Sends a message to all connected clients except for one.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="playerException"></param>
        public static void SendAllExcept<T>(T message, Guid playerException)
            where T : BaseMessage
        {
            if (Local == EngineMode.ServerAndClient)
            {
            }
            else
            {
                foreach (KeyValuePair<Guid, Socket> item in TcpServer.PlayerToSocket)
                {
                    if (item.Key != playerException)
                    {
                        TcpServer.Send(message, item.Key);
                    }
                }
            }
        }

        private static int TotalReceived = 0;

        /// <summary>
        /// Receives a message.
        /// </summary>
        /// <param name="message"></param>
        public static void Recieve(BaseMessage message)
        {
            TotalReceived++;
            MasterLog.DebugWriteLine("Total received: " + TotalReceived.ToString());
            RecievedMessages.Enqueue(message);
            RaiseMessageRecieved(null, message);
        }

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        private static void RaiseMessageRecieved(object sender, BaseMessage msg)
        {
            MessageRecieved?.Invoke(sender, msg);
        }
    }
}