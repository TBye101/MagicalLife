using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entities.Eventing
{
    /// <summary>
    /// Used to hold information about a event involving a living entity.
    /// </summary>
    public class LivingEventArg
    {
        public Living Living { get; private set; }

        /// <summary>
        /// Constructs a <see cref="LivingEventArg"/>.
        /// </summary>
        /// <param name="living"></param>
        public LivingEventArg(Living living)
        {
            this.Living = living;
        }
    }
}
