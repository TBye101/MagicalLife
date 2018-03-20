using System;

namespace MagicalLifeAPI.Universal
{
    /// <summary>
    /// Gives whatever inherits from this a unique ID.
    /// </summary>
    public class Unique
    {
        public Guid ID { get; } = Guid.NewGuid();

        public Unique()
        {
        }
    }
}