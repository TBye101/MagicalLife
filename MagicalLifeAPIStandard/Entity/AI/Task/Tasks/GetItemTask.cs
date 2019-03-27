using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    /// <summary>
    /// Gets the nearest of a certain item.
    /// </summary>
    [ProtoContract]
    public class GetItemTask : MagicalTask
    {
        public GetItemTask(Dependencies preRequisites, Guid boundID, List<Qualification> qualifications, int taskPriority) : base(preRequisites, boundID, qualifications, taskPriority)
        {
            //Use given item to find the nearest
        }

        public override void MakePreparations(Living l)
        {
        }

        public override void Reset()
        {
        }

        public override void Tick(Living l)
        {
            throw new NotImplementedException();
        }
    }
}
