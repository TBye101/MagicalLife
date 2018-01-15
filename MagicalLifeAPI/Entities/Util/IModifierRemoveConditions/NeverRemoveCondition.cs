using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entities.Util.IModifierRemoveConditions
{
    /// <summary>
    /// We shall never remove this modifier.
    /// </summary>
    public class NeverRemoveCondition : IModifierRemoveCondition
    {
        public bool WearOff()
        {
            return false;
        }
    }
}
