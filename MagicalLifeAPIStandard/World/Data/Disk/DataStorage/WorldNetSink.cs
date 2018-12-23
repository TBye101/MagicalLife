using MagicalLifeAPI.Error.InternalExceptions;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Registry.ItemRegistry;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MagicalLifeAPI.World.Data.Disk.DataStorage
{
    /// <summary>
    /// Used to send the parts of the world to the client piece by piece.
    /// This sink was meant to be used by the server only.
    /// </summary>
    public class WorldNetSink : AbstractWorldSink
    {
        private readonly Socket Client;

        public WorldNetSink(Socket client)
        {
            this.Client = client;
        }

        private void Send(BaseMessage msg)
        {
            byte[] data = ProtoUtil.Serialize(msg);
            this.Client.Send(data);
        }

        public override void Receive<T>(T data, string filePath, Guid dimensionID)
        {
            switch (data)
            {
                case Chunk chunk:
                    this.Send(new WorldTransferBodyMessage(chunk, dimensionID));
                    break;

                case List<DimensionHeader> headers:
                    this.Send(new WorldTransferHeaderMessage(headers));
                    break;

                case ItemRegistry registry:
                    this.Send(new WorldTransferRegistryMessage(registry, dimensionID));
                    break;

                case DimensionHeader header:
                    WorldDiskSink sink = new WorldDiskSink();
                    sink.Receive(header, filePath, dimensionID);
                    break;

                default:
                    throw new UnexpectedTypeException();
            }
        }
    }
}