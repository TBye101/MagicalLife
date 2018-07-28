using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Components.Resource
{
    /// <summary>
    /// Used to hold a <see cref="AbstractMinable"/> component.
    /// </summary>
    public interface IMinable
    {
        AbstractMinable MiningBehavior { get; set; }
    }
}
