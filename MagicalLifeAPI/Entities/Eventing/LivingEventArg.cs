namespace MagicalLifeAPI.Entities.Eventing
{
    /// <summary>
    /// Used to hold information about a event involving a living entity.
    /// </summary>
    public class LivingEventArg
    {
        public Living Living { get; set; }

        public Microsoft.Xna.Framework.Point Location { get; private set; }

        /// <summary>
        /// Constructs a <see cref="LivingEventArg"/>.
        /// </summary>
        /// <param name="living"></param>
        public LivingEventArg(Living living, Microsoft.Xna.Framework.Point location)
        {
            this.Living = living;
            this.Location = location;
        }
    }
}