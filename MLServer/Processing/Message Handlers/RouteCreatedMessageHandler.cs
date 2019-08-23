using System;
using System.Collections.Generic;
using System.Linq;
using MLAPI.Components;
using MLAPI.Components.Entity;
using MLAPI.DataTypes;
using MLAPI.Entity;
using MLAPI.Filing.Logging;
using MLAPI.Networking;
using MLAPI.Networking.Messages;
using MLAPI.Networking.Serialization;
using MLAPI.Pathfinding;
using MLAPI.Util;
using MLAPI.World;
using MLAPI.World.Data;

namespace MLServer.Processing.Message_Handlers
{
    /// <summary>
    /// How the server handles receiving route data for a creature.
    /// </summary>
    public class RouteCreatedMessageHandler : MessageHandler
    {
        public RouteCreatedMessageHandler() : base(NetMessageId.RouteCreatedMessage)
        {
        }

        public override void HandleMessage(BaseMessage message)
        {
            RouteCreatedMessage msg = (RouteCreatedMessage)message;

            if (this.Validated(msg.Path, msg.DimensionId) &&
                msg.Path.Count > 0)
            {
                Point2D location = msg.Path[0].Origin;
                Point2D chunkLocation = WorldUtil.CalculateChunkLocation(location);
                Chunk chunk = World.GetChunk(msg.DimensionId, chunkLocation.X, chunkLocation.Y);

                Living l = chunk.Creatures.Where(t => t.Value.GetExactComponent<ComponentSelectable>().MapLocation.Equals(location)).ElementAt(0).Value;

                if (l != null && l.Id == msg.LivingId)
                {
                    ComponentMovement movementComponent = l.GetExactComponent<ComponentMovement>();
                    movementComponent.QueuedMovement.Clear();
                    Extensions.EnqueueCollection<PathLink>(movementComponent.QueuedMovement, msg.Path);
                }
            }
            else
            {
                MasterLog.DebugWriteLine("Server received invalid path");
            }
        }

        private bool Validated(List<PathLink> msg, Guid dimensionId)
        {
            foreach (PathLink item in msg)
            {
                bool a = World.DefaultWorldProvider.GetTile(item.Origin).IsWalkable;
                bool b = World.DefaultWorldProvider.GetTile(item.Destination).IsWalkable;

                if (!a || !b)
                {
                    return false;
                }
            }

            return true;
        }
    }
}