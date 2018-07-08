using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.World.Data;
using System.Collections.Generic;

namespace MagicalLifeServer.Message_Handlers
{
    /// <summary>
    /// How the server handles receiving route data for a creature.
    /// </summary>
    public class RouteCreatedMessageHandler : MessageHandler
    {
        public RouteCreatedMessageHandler() : base(3)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            RouteCreatedMessage msg = (RouteCreatedMessage)message;

            if (Validated(msg.Path, msg.Dimension))
            {
                //Living l = World.MainWorld.Chunks[msg.Path[0].Origin.X, msg.Path[0].Origin.Y].Living;
                World.Dimensions[msg.Dimension].GetChunkForLocation(msg.Path[0].Origin.X, msg.Path[0].Origin.Y).GetCreature(msg.Path[0].Origin, out Living l);

                if (l != null && l.ID == msg.LivingID)
                {
                    l.QueuedMovement.Clear();
                    MagicalLifeAPI.Util.Extensions.EnqueueCollection<PathLink>(l.QueuedMovement, msg.Path);
                }
            }
            else
            {
                MasterLog.DebugWriteLine("Server received invalid path");
            }
            //attach path to creature
        }

        private bool Validated(List<PathLink> msg, int dimension)
        {
            foreach (PathLink item in msg)
            {
                bool a = World.Dimensions[dimension][item.Origin.X, item.Origin.Y].IsWalkable;
                bool b = World.Dimensions[dimension][item.Destination.X, item.Destination.Y].IsWalkable;

                if (a == false || b == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}