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
        internal SimpleTcpClient Client;

        private MessageBuffer MsgBuffer { get; } = new MessageBuffer();

        internal void Start(int port, string ip)
        {
            this.Client = new SimpleTcpClient();
            this.Client.DataReceived += this.Client_DataReceived;

            this.Client.Connect(ip, port);
            this.Send<LoginMessage>(new LoginMessage());
        }

        private void Client_DataReceived(object sender, Message e)
        {
            this.MsgBuffer.ReceiveData(e.Data);

            while (this.MsgBuffer.IsMessageAvailible())
            {
                BaseMessage msg = this.MsgBuffer.GetMessageData();

                ClientProcessor.Process(msg);
            }
        }

        public void Send<T>(T message)
            where T : BaseMessage
        {
            byte[] buffer = ProtoUtil.Serialize<T>(message);
            this.Client.Write(buffer);
        }
    }
}