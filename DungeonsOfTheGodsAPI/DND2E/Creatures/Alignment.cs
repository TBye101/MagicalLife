using System.Runtime.Serialization;
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

        /// <summary>
        /// Gets the name of our current alignment.
        /// </summary>
        /// <returns></returns>
        public AlignmentNames GetAlignment()
        {
            MoralsNames moral = this.GetMoralName();
            EthicsNames ethic = this.GetEthicName();

            if (ethic == EthicsNames.Lawful && moral == MoralsNames.Good)
            {
                return AlignmentNames.LawfulGood;
            }
            if (ethic == EthicsNames.Neutral && moral == MoralsNames.Good)
            {
                return AlignmentNames.NeutralGood;
            }
            if (ethic == EthicsNames.Chaotic && moral == MoralsNames.Good)
            {
                return AlignmentNames.ChaoticGood;
            }
            if (ethic == EthicsNames.Lawful && moral == MoralsNames.Neutral)
            {
                return AlignmentNames.LawfulNeutral;
            }
            if (ethic == EthicsNames.Neutral && moral == MoralsNames.Neutral)
            {
                return AlignmentNames.TrueNeutral;
            }
            if (ethic == EthicsNames.Chaotic && moral == MoralsNames.Neutral)
            {
                return AlignmentNames.ChaoticNeutral;
            }
            if (ethic == EthicsNames.Lawful && moral == MoralsNames.Evil)
            {
                return AlignmentNames.LawfulEvil;
            }
            if (ethic == EthicsNames.Neutral && moral == MoralsNames.Evil)
            {
                return AlignmentNames.NeutralEvil;
            }

            return AlignmentNames.ChaoticEvil;
        }

        /// <summary>
        /// Gets the name of this creature's current morals level.
        /// </summary>
        /// <returns></returns>
        private MoralsNames GetMoralName()
        {
            if (this.AverageAlignment.Morals > 65)
            {
                return MoralsNames.Good;
            }
            if (this.AverageAlignment.Morals < 35)
            {
                return MoralsNames.Evil;
            }
            return MoralsNames.Neutral;
        }

        /// <summary>
        /// Gets the name of this creature's current ethics level.
        /// </summary>
        /// <returns></returns>
        private EthicsNames GetEthicName()
        {
            if (this.AverageAlignment.Ethics > 65)
            {
                return EthicsNames.Lawful;
            }
            if (this.AverageAlignment.Ethics < 35)
            {
                return EthicsNames.Chaotic;
            }
            return EthicsNames.Neutral;
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
        /// Names of value ranges for a creature's ethics.
        /// </summary>
        private enum EthicsNames
        {
            Lawful, Neutral, Chaotic
        }

        /// <summary>
        /// Names of value ranges for a creature's morals.
        /// </summary>
        private enum MoralsNames
        {
            Good, Evil, Neutral
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
        /// <param name="newChoices"></param>
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
