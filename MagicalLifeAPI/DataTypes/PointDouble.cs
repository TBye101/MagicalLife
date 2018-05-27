using ProtoBuf;
using System;

namespace MagicalLifeAPI.DataTypes
{
    [ProtoBuf.ProtoContract]
    public struct PointDouble
    {
        [ProtoMember(1)]
        public Double X { get; set; }

        [ProtoMember(2)]
        public Double Y { get; set; }

        public PointDouble(Double x, Double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}