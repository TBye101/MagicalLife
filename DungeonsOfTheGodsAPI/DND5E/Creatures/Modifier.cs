using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND5E.Creatures
{
    /// <summary>
    /// A <see cref="Modifier"/> changes or adjusts an <see cref="Attribute"/> for a amount of time or indefinetly.
    /// </summary>
    public class Modifier : ITimeDependent
    {
        private double effect;
        private int duration;

        /// <summary>
        /// The effect (adding or subtracting) this modifer has on whatever it is applied to.
        /// </summary>
        public double Effect
        {
            get
            {
                return this.effect;
            }
        }

        /// <summary>
        /// The duration of this modifier in rounds.
        /// </summary>
        public int Duration
        {
            get
            {
                return this.duration;
            }
        }

        /// <summary>
        /// The constructor for the <see cref="Modifier"/> class.
        /// </summary>
        /// <param name="effect">The additive or subtractive effect this modifier will have on something else.</param>
        /// <param name="duration">How many rounds this modifier will effect what it is applied to. If this is -1, then this modifier will last forever.</param>
        public Modifier(double effect, int duration)
        {
            this.effect = effect;
            this.duration = duration;
        }

        public void RoundEnd()
        {
            if (this.duration != -1)
            {
                this.duration--;
            }
        }

        public void RoundStart()
        {
        }

        public void TurnEnd()
        {
        }

        public void TurnStart()
        {
        }
    }
}
