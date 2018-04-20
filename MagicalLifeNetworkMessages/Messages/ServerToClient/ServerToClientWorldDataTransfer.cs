using MagicalLifeAPI.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeNetworkMessages.Messages.ServerToClient
{
    /// <summary>
    /// Contains information regarding the world that the players will be playing in.
    /// Normally sent after the client has connected to the server, but has not recieved information about the world yet.
    /// </summary>
    public class ServerToClientWorldDataTransfer
    {
        public Payload ID;

        public Payload[,] Tiles;

        public ServerToClientWorldDataTransfer(World world)
        {
            this.ID = new Payload(world.ID, world.ID.GetType());
            this.Tiles = JsonUtil.ToPayloads<Tile>(world.Tiles);
        }
    }
}
