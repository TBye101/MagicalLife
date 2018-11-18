using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Pathfinding;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Networking.Messages
{
    [ProtoContract]
    public class RouteCreatedMessage : BaseMessage
    {
        [ProtoMember(5)]
        public List<PathLink> Path;

        [ProtoMember(6)]
        public Guid LivingID;

        [ProtoMember(7)]
        public int Dimension;

        public RouteCreatedMessage(List<PathLink> path, Guid livingID, int dimension) : base(NetMessageID.RouteCreatedMessage)
        {
            this.Path = path;
            this.LivingID = livingID;
            this.Dimension = dimension;
        }

        public RouteCreatedMessage() : base(NetMessageID.RouteCreatedMessage)
        {
        }
    }
}