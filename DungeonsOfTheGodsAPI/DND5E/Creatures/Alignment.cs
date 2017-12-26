using System.Runtime.CompilerServices;
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
        private AlignmentValue averageAlignment;
        private int HistorySize = 1;

        /// <summary>
        /// The average choices of the creature between chaos, order, good, and evil.
        /// </summary>
        public AlignmentValue AverageAlignment
        {
            get
            {
                return this.averageAlignment;
            }
        }

        public Alignment(AlignmentNames initial)
        {
            this.averageAlignment = this.GetValueForName(initial);
        }

        private AlignmentValue GetValueForName(AlignmentNames name)
        {
            switch (name)
            {
                case AlignmentNames.LawfulGood:
                    return new AlignmentValue(100, 100);
                case AlignmentNames.NeutralGood:
                    return new AlignmentValue(65, 100);
                case AlignmentNames.ChaoticGood:
                    return new AlignmentValue(0, 100);
                case AlignmentNames.LawfulNeutral:
                    return new AlignmentValue(100, 65);
                case AlignmentNames.TrueNeutral:
                    return new AlignmentValue(50, 50);
                case AlignmentNames.ChaoticNeutral:
                    return new AlignmentValue(0, 35);
                case AlignmentNames.LawfulEvil:
                    return new AlignmentValue(100, 0);
                case AlignmentNames.NeutralEvil:
                    return new AlignmentValue(35, 0);
                case AlignmentNames.ChaoticEvil:
                    return new AlignmentValue(0, 0);
            }

            return new AlignmentValue(-1, -1);
        }

        public enum AlignmentNames
        {
            LawfulGood, NeutralGood, ChaoticGood, LawfulNeutral, TrueNeutral, ChaoticNeutral, LawfulEvil, NeutralEvil, ChaoticEvil
        }

        /// <summary>
        /// Adds the impact of a alignment based choice to our current alignment and recalculates the player's alignment.
        /// </summary>
        /// <param name="newChoice"></param>
        public void AddAlignmentValue(AlignmentValue newChoice)
        {
            this.averageAlignment = this.CalculateAlignmentValueAverage(newChoice);
        }

        /// <summary>
        /// Calculates the creature's average choices between good, evil, order, and chaos.
        /// </summary>
        /// <returns></returns>
        private AlignmentValue CalculateAlignmentValueAverage(AlignmentValue newChoices)
        {
            int morals = this.AddToAverage(this.AverageAlignment.Morals, this.HistorySize, newChoices.Morals);
            int ethics = this.AddToAverage(this.AverageAlignment.Ethics, this.HistorySize, newChoices.Ethics);
            this.HistorySize++;

            return new AlignmentValue(ethics, morals);
        }

        /// <summary>
        /// Adds an item to a preaveraged average.
        /// </summary>
        /// <param name="average"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private int AddToAverage(double average, int size, double value)
        {
            return (int)Math.Round(((size * average) + value) / (size + 1));
        }
    }
}
