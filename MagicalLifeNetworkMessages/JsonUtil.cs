using Newtonsoft.Json;
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
        public static dynamic Deserialize(string str)
        {
            dynamic results = JsonConvert.DeserializeObject<dynamic>(str);

            return results;
        }

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Serialize(object t)
        {
            return JsonConvert.SerializeObject(t);
        }

        /// <summary>
        /// Serializes an object to bytes.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static byte[] SerializeToBytes(object t)
        {
            return Encoding.ASCII.GetBytes(JsonUtil.Serialize(t));
        }
    }
}
