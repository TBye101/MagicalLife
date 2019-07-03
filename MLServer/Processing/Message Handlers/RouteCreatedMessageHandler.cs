using MagicalLifeAPI.Components.Entity;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeServer.Processing.Message
{
    /// <summary>
    /// How the server handles receiving route data for a creature.
    /// </summary>
    public class RouteCreatedMessageHandler : MessageHandler
    {
        public RouteCreatedMessageHandler() : base(NetMessageID.RouteCreatedMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            RouteCreatedMessage msg = (RouteCreatedMessage)message;

            if (this.Validated(msg.Path, msg.DimensionID))
            {
                Point2D location = msg.Path[0].Origin;
                Point2D chunkLocation = WorldUtil.CalculateChunkLocation(location);
                Chunk chunk = World.GetChunk(msg.DimensionID, chunkLocation.X, chunkLocation.Y);

                Living l = chunk.Creatures.Where(t => t.Value.GetExactComponent<ComponentSelectable>().MapLocation.Equals(location)).ElementAt(0).Value;

                if (l != null && l.ID == msg.LivingID)
                {
                    ComponentMovement movementComponent = l.GetExactComponent<ComponentMovement>();
                    movementComponent.QueuedMovement.Clear();
                    MagicalLifeAPI.Util.Extensions.EnqueueCollection<PathLink>(movementComponent.QueuedMovement, msg.Path);
                }
            }
            else
            {
                MasterLog.DebugWriteLine("Server received invalid path");
            }
        }

        private bool Validated(List<PathLink> msg, Guid dimensionID)
        {
            foreach (PathLink item in msg)
            {
                bool a = World.Dimensions[dimensionID][item.Origin.X, item.Origin.Y].IsWalkable;
                bool b = World.Dimensions[dimensionID][item.Destination.X, item.Destination.Y].IsWalkable;

                if (!a || !b)
                {
                    return false;
                }
            }

            return true;
        }
    }
}