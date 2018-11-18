using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Networking.Serialization;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;

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
            if (this.Buffer.Count > 0)
            {
                ProtoBuf.Serializer.TryReadLengthPrefix(this.Buffer.ToArray(), 0, this.Buffer.Count, ProtoBuf.PrefixStyle.Base128, out this.NextMessageLength);
            }
            else
            {
                this.NextMessageLength = -1;
            }
        }

        /// <summary>
        /// Determines if there is a message to be taken.
        /// </summary>
        /// <returns></returns>
        public bool IsMessageAvailible()
        {
            return (this.NextMessageLength != -1 && this.NextMessageLength <= this.Buffer.Count);
        }

        /// <summary>
        /// Returns the next message. Returns null if no message is ready.
        /// </summary>
        /// <returns></returns>
        public BaseMessage GetMessageData()
        {
            BaseMessage data = null;
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

                MasterLog.DebugWriteLine("Message Buffer: " + this.Buffer.Count);
                this.CalculateNextMessageLength();
            }

            return data;
        }
    }
}