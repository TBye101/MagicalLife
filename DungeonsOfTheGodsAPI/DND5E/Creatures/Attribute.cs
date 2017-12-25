using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND5E.Creatures
{
    /// <summary>
    /// Represents a single attribute of a creature.
    /// </summary>
    public class Attribute : ITimeDependent
    {
        /// <summary>
        /// The actual value of this attribute.
        /// </summary>
        private double value;

        /// <summary>
        /// The current <see cref="Modifer"/>s that are effecting this attribute.
        /// </summary>
        public ObservableCollection<Modifier> Modifiers { get; set; } = new ObservableCollection<Modifier>();

        /// <summary>
        /// The value of this attribute.
        /// </summary>
        public double Value
        {
            get
            {
                return this.CalculateAttribute();
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

        /// <summary>
        /// Calculates the value of this attribute, and takes <see cref="Modifier"/>s into account.
        /// </summary>
        private double CalculateAttribute()
        {
            double ret = this.value;

            foreach (Modifier item in this.Modifiers)
            {
                ret += item.Effect;
            }

            return ret;
        }

        /// <summary>
        /// Removes expired modifiers.
        /// </summary>
        private void FilterModifiers()
        {
            List<Modifier> remove = new List<Modifier>();

            foreach (Modifier item in this.Modifiers)
            {
                if (item.Duration <= 0)
                {
                    remove.Add(item);
                }
            }

            foreach (Modifier item in remove)
            {
                this.Modifiers.Remove(item);
            }
        }

        public void RoundStart()
        {
            foreach (Modifier item in this.Modifiers)
            {
                item.RoundStart();
            }
        }

        public void RoundEnd()
        {
            foreach (Modifier item in this.Modifiers)
            {
                item.RoundEnd();
            }
            this.FilterModifiers();
        }

        public void TurnStart()
        {
            foreach (Modifier item in this.Modifiers)
            {
                item.TurnStart();
            }
        }

        public void TurnEnd()
        {
            foreach (Modifier item in this.Modifiers)
            {
                item.TurnEnd();
            }
        }
    }
}
