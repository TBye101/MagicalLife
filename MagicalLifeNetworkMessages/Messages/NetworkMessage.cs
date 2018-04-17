using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeNetworkMessages.Messages
{
    /// <summary>
    /// A base class for messages between server and client.
    /// </summary>
    public class NetworkMessage
    {
        public Guid ID { get; private set; }

        /// <summary>
        /// The time at which this message was sent.
        /// </summary>
        public DateTime Sent;

        /// <summary>
        /// The time at which this message was created.
        /// </summary>
        public DateTime Created;

        public Type MessageType;

        public NetworkMessage()
        {
            this.MessageType = this.GetType();
            this.ID = Guid.NewGuid();
            this.Created = DateTime.Now;
        }
    }
}
