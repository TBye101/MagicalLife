using MLAPI.Networking.Serialization;
using ProtoBuf;

namespace MLAPI.Networking.Messages
{
    [ProtoContract]
    public class ServerTickMessage : BaseMessage
    {
        public ServerTickMessage() : base(NetMessageId.ServerTickMessage)
        {
        }
    }
}