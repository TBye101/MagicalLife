using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using MLAPI.Filing.Logging;
using MLAPI.Networking.Messages;
using MLAPI.Networking.Serialization;
using MLAPI.World.Data.Disk;
using MLAPI.World.Data.Disk.DataStorage;
using SimpleTCP;

namespace MLAPI.Networking.Server
{
    /// <summary>
    /// The TCP server for communicating with clients.
    /// This should be initialized and ONLY utilized after the world has been generated.
    /// </summary>
    public class TcpServer
    {
        internal SimpleTcpServer Server = new SimpleTcpServer();

        public Dictionary<Guid, Socket> PlayerToSocket { get; private set; } = new Dictionary<Guid, Socket>();

        private MessageBuffer MsgBuffer { get; } = new MessageBuffer();

        public TcpServer()
        {
        }

        /// <summary>
        /// Starts the network server.
        /// </summary>
        internal void Start(int port)
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
            this.MsgBuffer.ReceiveData(e.Data);

            while (this.MsgBuffer.IsMessageAvailible())
            {
                BaseMessage msg = this.MsgBuffer.GetMessageData();
                if (msg is LoginMessage login)
                {
                    this.PlayerToSocket.Add(login.PlayerId, e.TcpClient.Client);
                }

                ServerSendRecieve.Recieve(msg);
            }
        }

        private void Server_ClientDisconnected(object sender, System.Net.Sockets.TcpClient e)
        {
            KeyValuePair<Guid, Socket> result = this.PlayerToSocket.First(x => x.Value == e.Client);
            this.PlayerToSocket.Remove(result.Key);
            ServerSendRecieve.Recieve(new DisconnectMessage(result.Key));

            MasterLog.DebugWriteLine("Client disconnected: " + e.Client.RemoteEndPoint.ToString());
        }

        private void Server_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
        {
            MasterLog.DebugWriteLine("Client connected: " + e.Client.RemoteEndPoint.ToString());

            WorldStorage.NetSerializeWorld(WorldStorage.SaveName, new WorldNetSink(e.Client));
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
            byte[] buffer = ProtoUtil.Serialize<T>(data);
            client.Send(buffer);
        }

        public void Send<T>(T data, Guid player)
            where T : BaseMessage
        {
            byte[] buffer = ProtoUtil.Serialize<T>(data);
            this.PlayerToSocket[player].Send(buffer);
        }

        /// <summary>
        /// Broadcasts the message to all connected clients.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public void Broadcast<T>(T data)
            where T : BaseMessage
        {
            byte[] buffer = ProtoUtil.Serialize<T>(data);
            this.Server.Broadcast(buffer);
        }
    }
}