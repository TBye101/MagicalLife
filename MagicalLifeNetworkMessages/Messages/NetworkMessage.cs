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
        public Guid ID { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// The time at which this message was sent.
        /// </summary>
        public DateTime Sent = DateTime.Now;
    }
}
