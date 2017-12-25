using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND5E.Creatures
{
    /// <summary>
    /// Used to hold two values about alignment: ethics, and morals.
    /// </summary>
    public class AlignmentValues
    {
        /// <summary>
        /// Holds a value which describes a creature's tendencies between order and chaos.
        /// </summary>
        public int Ethics { get; set; }

        /// <summary>
        /// Holds a value which describes a creature's tendencies between good and evil.
        /// </summary>
        public int Morals { get; set; }

        /// <summary>
        /// Constructs the <see cref="AlignmentValues"/> class.
        /// </summary>
        /// <param name="ethics"></param>
        /// <param name="morals"></param>
        public AlignmentValues(int ethics, int morals)
        {
            this.Ethics = ethics;
            this.Morals = morals;
        }
    }
}
