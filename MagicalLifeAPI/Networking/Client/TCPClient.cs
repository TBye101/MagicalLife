using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using SimpleTCP;

namespace MagicalLifeAPI.Networking.Client
{
    /// <summary>
    /// The TCP client for communicating with the server.
    /// </summary>
    public class TCPClient
    {
        public SimpleTcpClient Client;

        public void Start(int port, string ip)
        {
            this.Client = new SimpleTcpClient();
            this.Client.DataReceived += this.Client_DataReceived;

            this.Client.Connect(ip, port);
            this.Send<LoginMessage>(new LoginMessage());
        }

        private void Client_DataReceived(object sender, Message e)
        {
            BaseMessage msg = (BaseMessage)ProtoUtil.Deserialize(e.Data);
            ClientProcessor.Process(msg);
        }

        public void Send<T>(T message)
            where T : BaseMessage
        {
            this.Client.Write(ProtoUtil.Serialize<T>(message));
        }
    }
}