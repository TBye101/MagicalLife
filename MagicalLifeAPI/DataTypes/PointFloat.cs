using ProtoBuf;
using System;

namespace MagicalLifeAPI.DataTypes
{
    [ProtoBuf.ProtoContract]
    public struct PointFloat
    {
        [ProtoMember(1)]
        public float X { get; set; }

        [ProtoMember(2)]
        public float Y { get; set; }

        public PointFloat(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}