using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entity.AI.Task
{
    /// <summary>
    /// Holds tasks that must be completed before another task can begin.
    /// </summary>
    [ProtoContract]
    public class Dependencies
    {
        [ProtoMember(1)]
        public List<MagicalTask> PreRequisite { get; private set; }

        public Dependencies(List<MagicalTask> dependencies)
        {
            this.PreRequisite = dependencies;
        }

        public Dependencies()
        {
            //Protobuf-net constructor.
        }
    }
}
