using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Test;
using MagicalLifeAPI.Protobuf;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Tiles;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServer.Networking
{
    /// <summary>
    /// The TCP server for communicating with clients.
    /// This should be initialized and ONLY utilized after the world has been generated.
    /// </summary>
    public class TCPServer
    {
        public SimpleTcpServer Server = new SimpleTCP.SimpleTcpServer();

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
            MasterLog.DebugWriteLine("Client connection recieved");
            //e.Client.Send(JsonUtil.SerializeToBytes(new ServerToClientWorldDataTransfer(World.mainWorld)));

            ////string test = ProtoUtil.Serialize<MagicalLifeAPI.Networking.BaseMessage>(new MagicalLifeAPI.Networking.BaseMessage());
            ////string test = ProtoUtil.Serialize<TileMessage>(new TileMessage(new Dirt(3, 9)));
            string test = ProtoUtil.Serialize<ConcreteTest>(new ConcreteTest());
            e.Client.Send(Convert.FromBase64String(test));

            //TestRunner a = new TestRunner();
            //a.Go();
        }
    }
}
