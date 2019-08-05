using System.Collections.Generic;
using MLAPI.DataTypes;
using ProtoBuf;

namespace MLAPI.Components
{
    /// <summary>
    /// This component specifies an extra link between the containing tile's location and another spot on the map in terms of pathfinding as added by the containing <see cref="GameObject"/>.
    /// AKA teleportation/portal/dimension transfer ect...
    /// </summary>
    [ProtoContract]
    public class PortalComponent : Component
    {
        [ProtoMember(1)]
        public List<Point3D> Connections { get; set; }

        /// <param name="connections">The extra connections from this tile.</param>
        public PortalComponent(List<Point3D> connections)
        {
            this.Connections = connections;
        }

        protected PortalComponent()
        {
            //Protobuf-net constructor.
        }
    }
}