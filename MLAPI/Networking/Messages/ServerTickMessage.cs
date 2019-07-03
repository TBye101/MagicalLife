using MagicalLifeAPI.Networking.Serialization;
using ProtoBuf;

namespace MagicalLifeAPI.Networking.Messages
{
    [ProtoContract]
    public class ServerTickMessage : BaseMessage
    {
        public ServerTickMessage() : base(NetMessageID.ServerTickMessage)
        {
        }
    }
}