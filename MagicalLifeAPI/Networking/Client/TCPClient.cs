using MagicalLifeAPI.Filing.Logging;
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

        private MessageBuffer MsgBuffer { get; set; } = new MessageBuffer();

        public void Start(int port, string ip)
        {
            this.Client = new SimpleTcpClient();
            this.Client.DataReceived += this.Client_DataReceived;

            this.Client.Connect(ip, port);
            this.Send<LoginMessage>(new LoginMessage());
        }

        private void Client_DataReceived(object sender, Message e)
        {
            MasterLog.DebugWriteLine("Receiving " + e.Data.Length + " bytes");
            this.MsgBuffer.ReceiveData(e.Data);

            while (this.MsgBuffer.GetMessageData(out BaseMessage msg))
            {
                ClientProcessor.Process(msg);
            }
        }

        public void Send<T>(T message)
            where T : BaseMessage
        {
            byte[] buffer = ProtoUtil.Serialize<T>(message);
            MasterLog.DebugWriteLine("Sending " + buffer.Length + " bytes");
            this.Client.Write(buffer);
        }
    }
}