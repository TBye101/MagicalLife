using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Entity.AI.Task.Tasks
{
    public class CraftSimpleItemTask : MagicalTask
    {
        protected CraftSimpleItemTask()
        {
        }

        public CraftSimpleItemTask(Dependencies preRequisites, Guid boundID, List<Qualification> qualifications, int taskPriority) : base(preRequisites, boundID, qualifications, taskPriority)
        {
        }

        public override void MakePreparations(Living l)
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override void Tick(Living l)
        {
            throw new NotImplementedException();
        }
    }
}
