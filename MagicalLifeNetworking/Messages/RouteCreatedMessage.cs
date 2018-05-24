using MagicalLifeAPI.Networking;
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

        public RouteCreatedMessage(List<PathLink> path, Guid livingID) : base(3)
        {
            this.Path = path;
            this.LivingID = livingID;
        }

        public RouteCreatedMessage() : base(3)
        {
        }
    }
}