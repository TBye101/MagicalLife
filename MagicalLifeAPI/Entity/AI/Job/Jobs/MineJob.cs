using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;

namespace MagicalLifeAPI.Entity.AI.Job.Jobs
{
    /// <summary>
    /// Has the creature mine something.
    /// </summary>
    public class MineJob : Job
    {
        public Point2D Target { get; private set; }

        public Point2D WorkStation { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target">The tile that contains the object to mine up.</param>
        /// <param name="workStation">The position at which the creature will be at when it begins mining.</param>
        public MineJob(Point2D target) : base(GetDependencies(target))
        {
            this.Target = target;
        }

        protected static Dictionary<Guid, Job> GetDependencies(Point2D target)
        {
            Dictionary<Guid, Job> ret = new Dictionary<Guid, Job>();
            BecomeAdjacentJob dependency = new BecomeAdjacentJob(target);

            ret.Add(dependency.ID, dependency);

            return ret;
        }

        public override void BeginJob(Living living)
        {
        }

        public override void DoJob(Living living)
        {
        }

        public override void ReevaluateDependencies()
        {
            //Evaluate that something needs to be mined first or something.
        }
    }
}
