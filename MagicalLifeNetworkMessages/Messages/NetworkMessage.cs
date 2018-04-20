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
        /// The type of the payload.
        /// </summary>
        public Type PayloadType;

        /// <summary>
        /// The payload in its serialized form.
        /// </summary>
        public string SerializedPayload { get; set; }

        /// <summary>
        /// The deserialized version of the object. 
        /// If null, no one has gotten the payload yet, so this has not been calculated yet.
        /// </summary>
        private object Deserialized = null;

        /// <param name="Payload">The data that will be sent via this message.</param>
        /// <param name="type">The class type of the payload.</param>
        public NetworkMessage(object Payload, Type type)
        {
            this.PayloadType = type;
            this.ID = Guid.NewGuid();
            this.Created = DateTime.Now;
            this.SerializedPayload = JsonUtil.Serialize(Payload);
        }

        /// <summary>
        /// For use by deserializers.
        /// </summary>
        public NetworkMessage()
        {

        }

        /// <summary>
        /// Returns the payload.
        /// </summary>
        /// <returns></returns>
        public object GetPayload()
        {
            if (this.Deserialized == null)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.All;

                this.Deserialized = JsonConvert.DeserializeObject(this.SerializedPayload, this.PayloadType, settings);
            }

            return this.Deserialized;
        }
    }
}
