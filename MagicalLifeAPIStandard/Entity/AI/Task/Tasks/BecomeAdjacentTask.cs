using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task.Qualifications;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Networking.Client;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    [ProtoContract]
    public class BecomeAdjacentTask : MagicalTask
    {
        [ProtoMember(1)]
        public Point2D Target { get; private set; }

        [ProtoMember(3)]
        public Point2D AdjacentLocation { get; private set; }

        public BecomeAdjacentTask(Guid boundID, Point2D target) : base(Dependencies.CreateEmpty(), boundID, new List<Qualification> { new CanMoveQualification() }, PriorityLayers.Default)
        {
            this.Target = target;
        }

        public override void MakePreparations(Living l)
        {
            List<Point2D> result = WorldUtil.GetNeighboringTiles(this.Target, l.Dimension);
            result.RemoveAll(x => !World.Data.World.GetTile(l.Dimension, x.X, x.Y).IsWalkable);

            ComponentSelectable entitySelected = l.GetExactComponent<ComponentSelectable>();
            int closestIndex = Algorithms.GetClosestPoint2D(result, entitySelected.MapLocation);
            this.AdjacentLocation = result[closestIndex];
            List<PathLink> path = MainPathFinder.GetRoute(l.Dimension, entitySelected.MapLocation, result[closestIndex]);

            if (World.Data.World.Mode == Networking.EngineMode.ClientOnly)
            {
                ClientSendRecieve.Send(new RouteCreatedMessage(path, l.ID, l.Dimension));
            }

            l.QueuedMovement.Clear();
            Extensions.EnqueueCollection(l.QueuedMovement, path);
        }

        public override void Reset()
        {
            //We don't need to do anything to reset this.
        }

        public override void Tick(Living l)
        {
            ComponentSelectable selected = l.GetExactComponent<ComponentSelectable>();
            if (selected.MapLocation.Equals(this.AdjacentLocation))
            {
                MasterLog.DebugWriteLine(this.ID.ToString());
                this.CompleteTask();
            }
        }

        public override bool CreateDependencies(Living l)
        {
            return true;
        }
    }
}