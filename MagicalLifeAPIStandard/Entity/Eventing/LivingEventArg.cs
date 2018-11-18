using MagicalLifeAPI.DataTypes;

namespace MagicalLifeAPI.Entity.Eventing
{
    /// <summary>
    /// Used to hold information about a event involving a living entity.
    /// </summary>
    public class LivingEventArg
    {
        public Living Living { get; set; }

        public Point2D Location { get; private set; }

        /// <summary>
        /// Constructs a <see cref="LivingEventArg"/>.
        /// </summary>
        /// <param name="living"></param>
        public LivingEventArg(Living living, Point2D location)
        {
            this.Living = living;
            this.Location = location;
        }
    }
}