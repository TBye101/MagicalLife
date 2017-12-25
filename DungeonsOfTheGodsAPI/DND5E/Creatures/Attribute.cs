using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND5E.Creatures
{
    /// <summary>
    /// Represents a single attribute of a creature.
    /// </summary>
    public class Attribute
    {
        private double value;

        /// <summary>
        /// The value of this attribute.
        /// </summary>
        public double Value
        {
            get
            {
                return this.value;
            }
        }

        /// <summary>
        /// The constructor for <see cref="Attribute"/>.
        /// </summary>
        /// <param name="value">The value of this attribute in the beginning.</param>
        public Attribute(double value)
        {
            this.value = value;
        }


    }
}
