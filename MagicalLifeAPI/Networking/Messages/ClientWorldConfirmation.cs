using MagicalLifeAPI.Networking.Serialization;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Networking.Messages
{
    /// <summary>
    /// This message is sent to the server from the client signifying that the client has received and processed a <see cref="WorldTransferMessage"/>.
    /// </summary>
    [ProtoContract]
    public class ClientWorldConfirmation : BaseMessage
    {
        public ClientWorldConfirmation() : base(5)
        {
        }
    }
}