using System;
using System.Collections.Generic;
using MLAPI.Components;
using MLAPI.DataTypes;
using MLAPI.Entity.AI.Task.Qualifications;
using MLAPI.Pathfinding;
using MLAPI.World;
using ProtoBuf;

namespace MLAPI.Entity.AI.Task.Tasks
{
    [ProtoContract]
    public class BecomeAdjacentTask : MagicalTask
    {
        [ProtoMember(1)]
        public Point3D Target { get; private set; }

        public BecomeAdjacentTask(Guid boundId, Point3D target) : base(Dependencies.CreateEmpty(), boundId, new List<Qualification> { new CanMoveQualification() }, PriorityLayers.Default)
        {
            this.Target = target;
        }

        public override void MakePreparations(Living living)
        {
        }

        public override void Reset()
        {
            //We don't need to do anything to reset this.
        }

        public override void Tick(Living l)
        {
            this.CompleteTask();
        }

        public override bool CreateDependencies(Living l)
        {
            List<Point3D> result = WorldUtil.GetNeighboringTiles(this.Target);
            result.RemoveAll(x => !World.Data.World.GetTile(l.DimensionId, x.X, x.Y).IsWalkable);

            ComponentSelectable entitySelected = l.GetExactComponent<ComponentSelectable>();
            Point3D adjacentLocation = PathUtil.GetFirstReachable(result, entitySelected.MapLocation);

            if (adjacentLocation == null)
            {
                return false;
            }
            else
            {
                MoveTask task = new MoveTask(this.BoundId, adjacentLocation);
                this.Dependencies.PreRequisite.Add(task);
                return true;
            }
        }
    }
}