using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicalLifeAPI.Networking.Serialization;
using ProtoBuf;

namespace MagicalLifeAPI.Networking
{
    /// <summary>
    /// Used to buffer Protobuf-net (<see cref="BaseMessage"/>) messages correctly in order to handle a TCP connection.
    /// </summary>
    public class MessageBuffer
    {
        private List<byte> Buffer { get; set; }

        private int NextMessageLength = -1;

        public MessageBuffer()
        {
            this.Buffer = new List<byte>();
        }

        /// <summary>
        /// Handles new data from the TCP connection.
        /// </summary>
        /// <param name="data"></param>
        public void ReceiveData(byte[] data)
        {
            this.Buffer.AddRange(data);

            if (NextMessageLength == -1)
            {
                this.CalculateNextMessageLength();
            }
        }

        private void CalculateNextMessageLength()
        {
                ProtoBuf.Serializer.TryReadLengthPrefix(this.Buffer.ToArray(), 0, this.Buffer.Count, ProtoBuf.PrefixStyle.Base128, out this.NextMessageLength);
        }

        /// <summary>
        /// Returns true if <paramref name="data"/> contains a message to be deserialized.
        /// </summary>
        /// <param name="data">Null if there is no message fully buffered yet.</param>
        /// <returns></returns>
        public bool GetMessageData(out BaseMessage data)
        {
            if (this.NextMessageLength != -1 && this.NextMessageLength <= this.Buffer.Count)
            {
                using (MemoryStream ms = new MemoryStream(this.Buffer.ToArray()))
                {
                    data = (BaseMessage)ProtoUtil.TypeModel.DeserializeWithLengthPrefix(ms, null, typeof(BaseMessage), PrefixStyle.Base128, 0);
                    this.Buffer.RemoveRange(0, Convert.ToInt32(ms.Position));

                    //Remove the trailing 0s from the last message

                    //The starting index of the next message
                    int start = this.Buffer.FindIndex(x => x != 0);

                    if (start == -1)
                    {
                        this.Buffer.Clear();
                    }
                    else
                    {
                        this.Buffer.RemoveRange(0, start);
                    }
                }

                this.NextMessageLength = -1;
                return true;
            }

            data = null;
            return false;
        }
    }
}
