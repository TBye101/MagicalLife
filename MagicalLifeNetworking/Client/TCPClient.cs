using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Protobuf;
using MagicalLifeAPI.Protobuf.Serialization;
using MagicalLifeClient.Processing;
using SimpleTCP;
using System;

namespace MagicalLifeClient.Networking
{
    /// <summary>
    /// The TCP client for communicating with the server.
    /// </summary>
    public class TCPClient
    {
        public SimpleTcpClient Client;

        public void Start(int port, string ip = "192.168.0.15")
        {
            this.Client = new SimpleTcpClient();
            this.Client.DataReceived += this.Client_DataReceived;

            this.Client.Connect(ip, port);
        }

        private void Client_DataReceived(object sender, Message e)
        {
            BaseMessage msg = (BaseMessage)ProtoUtil.Deserialize(e.Data);
            ClientProcessor.Process(msg);
        }

        public void Send<T>(T message)
            where T : BaseMessage
        {
            this.Client.Write(Convert.FromBase64String(ProtoUtil.Serialize<T>(message)));
        }
    }
}