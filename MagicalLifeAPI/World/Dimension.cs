using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Universal;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// Holds some information about the level of the world.
    /// Could be a dungeon, the starting point, or some other thing.
    /// </summary>
    [ProtoContract]
    public class Dimension : Unique
    {
        /// <summary>
        /// A 2D array that holds every chunk in the current world.
        /// </summary>
        [ProtoMember(1)]
        private ProtoArray<Chunk> Chunks { get; set; }

        /// <summary>
        /// The display name of the dimension.
        /// </summary>
        [ProtoMember(2)]
        public string DimensionName { get; set; }


    }
}
