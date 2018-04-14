using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeClient.Networking
{
    /// <summary>
    /// The TCP client for communicating with the server.
    /// </summary>
    public class TCPClient
    {
        public SimpleTcpClient Client;

        public void Start(int port, string ip = "192.168.0.10")
        {
            this.Client = new SimpleTcpClient();
            this.Client.Connect(ip, port);
        }
    }
}
