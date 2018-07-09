using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Data
{
    /// <summary>
    /// Used to hold and manage groups of items that have specific and differing data.
    /// </summary>
    [ProtoContract]
    public class ComplexItemStack
    {
        /// <summary>
        /// The items in this item stack.
        /// </summary>
        [ProtoMember(1)]
        public List<Item> Items { get; set; }
    }
}
