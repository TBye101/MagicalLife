using System;

namespace MagicalLifeAPI.Networking.Serialization
{
    /// <summary>
    /// Used to discover which class is a protobuf-net surrogate for which class.
    /// </summary>
    public class Surrogate : Attribute
    {
        public Type NeedsSurrogate { get; set; }
        public Type SurrogateType { get; set; }

        public Surrogate(Type needsSurrogate, Type surrogateType)
        {
            this.NeedsSurrogate = needsSurrogate;
            this.SurrogateType = surrogateType;
        }
    }
}