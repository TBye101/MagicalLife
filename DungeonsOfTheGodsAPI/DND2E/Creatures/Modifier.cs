using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND2E.Creatures
{
    /// <summary>
    /// A <see cref="Modifier"/> changes or adjusts an <see cref="Attribute"/> for a amount of time or indefinetly.
    /// </summary>
    public class Modifier : ITimeDependent
    {
        private int duration;

        /// <summary>
        /// The effect (adding or subtracting) this modifer has on whatever it is applied to.
        /// </summary>
        public double Effect { get; }

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
        /// Some text so we know why this was applied.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The unique ID of this modifier.
        /// </summary>
        public Guid ID { get; } = Guid.NewGuid();

        /// <summary>
        /// The constructor for the <see cref="Modifier"/> class.
        /// </summary>
        /// <param name="effect">The additive or subtractive effect this modifier will have on something else.</param>
        /// <param name="duration">How many rounds this modifier will effect what it is applied to. If this is -1, then this modifier will last forever.</param>
        public Modifier(double effect, int duration, string name)
        {
            this.Effect = effect;
            this.duration = duration;
            this.Name = name;
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
