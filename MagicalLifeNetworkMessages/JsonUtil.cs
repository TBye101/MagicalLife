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

        /// <summary>
        /// Converts a list of payloads to their actual data type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="payloads"></param>
        /// <returns></returns>
        public static List<T> ConvertPayloads<T>(List<Payload> payloads)
        {
            List<T> ret = new List<T>();

            foreach (Payload item in payloads)
            {
                ret.Add((T)item.GetPayload());
            }

            return ret;
        }

        /// <summary>
        /// Converts an array of payloads to their actual data types.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="payloads"></param>
        /// <returns></returns>
        public static T[,] ConvertPayloads<T>(Payload[,] payloads)
        {
            int x = 0;
            int y = 0;
            int xLength = payloads.GetLength(0);
            int yLength = payloads.GetLength(1);

            T[,] ret = new T[xLength, yLength];

            while (x != xLength)
            {
                while (y != yLength)
                {
                    ret[x, y] = (T)payloads[x, y].GetPayload();

                    y++;
                }

                y = 0;
                x++;
            }

            return ret;
        }

        public static Payload[,] ToPayloads<T>(T[,] objects)
        {
            int x = 0;
            int y = 0;
            int xLength = objects.GetLength(0);
            int yLength = objects.GetLength(1);

            Payload[,] ret = new Payload[xLength, yLength];

            while (x != xLength)
            {
                while (y != yLength)
                {
                    ret[x, y] = new Payload(objects[x, y], objects[x, y].GetType());

                    y++;
                }

                y = 0;
                x++;
            }

            return ret;
        }
    }
}
