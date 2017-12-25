using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND5E.Creatures
{
    /// <summary>
    /// Used to handle alignment, and the shifts between alignments.
    /// </summary>
    public class Alignment
    {
        /// <summary>
        /// This is the value behind whether or not the creature is Lawful, chaotic, or neutral.
        /// </summary>
        public int Ethics { get; set; }

        /// <summary>
        /// This is the value behind whether or not the creature is good, neutral, or evil.
        /// </summary>
        public int Morals { get; set; }

        public Alignment()
        {

        }

        public enum AlignmentNames
        {
            LawfulGood, NeutralGood, ChaoticGood, LawfulNeutral, TrueNeutral, ChaoticNeutral, LawfulEvil, NeutralEvil, ChaoticEvil
        }
    }
}
