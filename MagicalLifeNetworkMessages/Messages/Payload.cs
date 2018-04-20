using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeNetworkMessages.Messages
{
    public class Payload
    {

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

        public Payload(object Payload, Type type)
        {
            this.SerializedPayload = JsonUtil.Serialize(Payload);
            this.PayloadType = type;
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
            //Tiles are abstract, thats why they don't deserialize properly. 
            //Need to write a wrapper around that like we wrote a wrapper around NetworkMessage's payload.
            return this.Deserialized;
        }
    }
}
