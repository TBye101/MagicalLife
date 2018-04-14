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
    public class JsonUtil
    {
        /// <summary>
        /// Deserializes an object.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public dynamic Deserialize(string str)
        {
            dynamic results = JsonConvert.DeserializeObject<dynamic>(str);

            return results;
        }

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public string Serialize(object t)
        {
            return JsonConvert.SerializeObject(t);
        }
    }
}
