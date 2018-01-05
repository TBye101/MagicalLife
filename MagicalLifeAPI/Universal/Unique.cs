using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Universal
{
    /// <summary>
    /// Gives whatever inherits from this a unique ID.
    /// </summary>
    public class Unique
    {
        public Guid ID { get; } = Guid.NewGuid();
    }
}
