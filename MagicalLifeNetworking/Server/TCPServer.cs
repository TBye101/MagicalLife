using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Protobuf;
using MagicalLifeAPI.Protobuf.Serialization;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using SimpleTCP;
using System;
using System.Net.Sockets;

namespace MagicalLifeServer.Networking
{
    /// <summary>
    /// The TCP server for communicating with clients.
    /// This should be initialized and ONLY utilized after the world has been generated.
    /// </summary>
    public class TCPServer
    {
        public SimpleTcpServer Server = new SimpleTcpServer();

        public TCPServer()
        {
        }

        /// <summary>
        /// Starts the network server.
        /// </summary>
        public void Start(int port)
        {
            this.Server.Start(port);

            foreach (System.Net.IPAddress item in this.Server.GetListeningIPs())
            {
                MasterLog.DebugWriteLine("Server listening on: " + item.ToString());
            }

            this.Server.ClientConnected += this.Server_ClientConnected;
            this.Server.ClientDisconnected += this.Server_ClientDisconnected;
            this.Server.DataReceived += this.Server_DataReceived;
        }

        private void Server_DataReceived(object sender, Message e)
        {
        }

        private void Server_ClientDisconnected(object sender, System.Net.Sockets.TcpClient e)
        {
            MasterLog.DebugWriteLine("Client disconnected");
        }

        private void Server_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
        {
            MasterLog.DebugWriteLine("Client connection received");

            //this.Send<ConcreteTest>(new ConcreteTest(), e.Client);
            this.Send<WorldTransferMessage>(new WorldTransferMessage(World.Dimensions), e.Client);
        }

        /// <summary>
        /// Broadcasts the message to a specific client.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="client"></param>
        public void Send<T>(T data, Socket client)
            where T : BaseMessage
        {
            client.Send(Convert.FromBase64String(ProtoUtil.Serialize<T>(data)));
        }

        /// <summary>
        /// Broadcasts the message to all connected clients.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public void Broadcast<T>(T data)
            where T : BaseMessage
        {
            this.Server.Broadcast(Convert.FromBase64String(ProtoUtil.Serialize<T>(data)));
        }
    }
}