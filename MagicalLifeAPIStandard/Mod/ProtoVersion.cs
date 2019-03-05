using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Mod
{
    /// <summary>
    /// A protobuf-net compatible version class.
    /// </summary>
    [ProtoContract]
    public class ProtoVersion
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }
        public int Build { get; private set; }
        public int Revision { get; private set; }

        public ProtoVersion(int major, int minor, int build, int revision)
        {
            this.Major = major;
            this.Minor = minor;
            this.Build = build;
            this.Revision = revision;
        }

        protected ProtoVersion()
        {
            //Protobuf-net constructor
        }
    }
}
