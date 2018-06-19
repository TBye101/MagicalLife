using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Pathfinding;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeNetworking.Messages
{
    [ProtoContract]
    public class RouteCreatedMessage : BaseMessage
    {
        [ProtoMember(1)]
        public List<PathLink> Path;

        [ProtoMember(2)]
        public Guid LivingID;

        [ProtoMember(3)]
        public int Dimension;

        public RouteCreatedMessage(List<PathLink> path, Guid livingID, int dimension) : base(3)
        {
            this.Path = path;
            this.LivingID = livingID;
            this.Dimension = dimension;
        }

        public RouteCreatedMessage() : base(3)
        {
        }
    }
}