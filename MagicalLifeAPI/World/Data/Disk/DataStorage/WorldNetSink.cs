using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Registry.ItemRegistry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Data.Disk.DataStorage
{
    /// <summary>
    /// Used to send the parts of the world to the client piece by piece.
    /// This sink was meant to be used by the server only.
    /// </summary>
    public class WorldNetSink : AbstractWorldSink
    {
        private Socket Client;

        public WorldNetSink(Socket client)
        {
            this.Client = client;
        }

        private void Send(BaseMessage msg)
        {
            byte[] data = ProtoUtil.Serialize(msg);
            this.Client.Send(data);
        }

        public override void Receive<T>(T data, string filePath)
        {
            switch (data)
            {
                case Chunk chunk:
                    this.Send(new WorldTransferBodyMessage(chunk));
                    break;
                case List<DimensionHeader> header:
                    this.Send(new WorldTransferHeaderMessage(header));
                    break;
                case ItemRegistry registry:
                    this.Send(new WorldTransferRegistryMessage(registry));
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
