using MLAPI.Networking.Serialization;
using ProtoBuf;

namespace MLAPI.Networking.Messages
{
    /// <summary>
    /// Used by the client to tell the server which player in the game it is.
    /// </summary>
    [ProtoContract]
    public class LoginMessage : BaseMessage
    {
        public LoginMessage() : base(NetMessageId.LoginMessage)
        {
        }
    }
}