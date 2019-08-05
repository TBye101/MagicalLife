using System;
using System.Collections.Generic;
using MLAPI.Networking.Serialization;
using MLAPI.Pathfinding;
using ProtoBuf;

namespace MLAPI.Networking.Messages
{
    [ProtoContract]
    public class RouteCreatedMessage : BaseMessage
    {
        [ProtoMember(5)]
        public List<PathLink> Path;

        [ProtoMember(6)]
        public Guid LivingId;

        [ProtoMember(7)]
        public Guid DimensionId;

        public RouteCreatedMessage(List<PathLink> path, Guid livingId, Guid dimensionId) : base(NetMessageId.RouteCreatedMessage)
        {
            this.Path = path;
            this.LivingId = livingId;
            this.DimensionId = dimensionId;
        }

        public RouteCreatedMessage()
        {
            //Protobuf-net constructor.
        }
    }
}