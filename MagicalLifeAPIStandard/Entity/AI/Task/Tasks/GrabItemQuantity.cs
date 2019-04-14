using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    /// <summary>
    /// Has the character grab a certain amount of a specific item.
    /// </summary>
    [ProtoContract]
    public class GrabItemQuantity : MagicalTask
    {
        public GrabItemQuantity(Dependencies preRequisites, Guid boundID, List<Qualification> qualifications, int taskPriority)
            : base(preRequisites, boundID, qualifications, taskPriority)
        {
        }

        protected GrabItemQuantity()
        {
            //Protobuf-net constructor.
        }

        public override void MakePreparations(Living l)
        {
            //Need to make a job executor or something
            //Something that will execute a load of jobs in order, and notify you when it's done
        }

        public override void Reset()
        {
        }

        public override void Tick(Living l)
        {
        }
    }
}
