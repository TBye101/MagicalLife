using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions
{
    /// <summary>
    /// This modifier condition allows remove of the modifier after a certain number of turns.
    /// </summary>
    public class TimeRemoveCondition : IModifierRemoveCondition
    {
        private int Turns;
        /// <param name="turns">The number of turns until the modifier is allowed to expire.</param>
        public TimeRemoveCondition(int turns)
        {
            this.Turns = turns;
        }

        public bool WearOff()
        {
            this.Turns--;

            return this.Turns == 0;
        }
    }
}
