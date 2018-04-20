using Newtonsoft.Json;
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

        /// <summary>
        /// The payload this message is carrying.
        /// </summary>
        public Payload Payload;

        /// <param name="payload">The data that will be sent via this message.</param>
        /// <param name="type">The class type of the payload.</param>
        public NetworkMessage(object payload, Type type)
        {
            this.ID = Guid.NewGuid();
            this.Payload = new Payload(payload, type);
            this.Created = DateTime.Now;
        }

        /// <summary>
        /// For use by deserializers.
        /// </summary>
        public NetworkMessage()
        {

        }
    }
}
