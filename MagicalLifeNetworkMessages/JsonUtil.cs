using MagicalLifeNetworkMessages.Messages;
using MagicalLifeNetworkMessages.Messages.ServerToClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeNetworkMessages
{
    /// <summary>
    /// Used to convert an object between json and an actual object.
    /// </summary>
    public static class JsonUtil
    {
        /// <summary>
        /// Deserializes an object.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static NetworkMessage Deserialize(string str)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.All;

            Type type = str.GetType();

            NetworkMessage netMsg = JsonConvert.DeserializeObject<NetworkMessage>(str);

            return JsonConvert.DeserializeObject<NetworkMessage>(str, settings);
        }

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Serialize(object t)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.All;

            return JsonConvert.SerializeObject(t, settings);
        }
    }
}
