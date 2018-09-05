namespace MagicalLifeAPI.World.Base
{
    /// <summary>
    /// A base class used by anything that can grow, and is alive.
    /// </summary>
    public abstract class Vegetation
    {
        /// <summary>
        /// The constructor for <see cref="Vegetation"/>.
        /// </summary>
        /// <param name="name">The name of this vegetation.</param>
        protected Vegetation(string name)
        {
            this.Name = name;
        }

        public string Name { get; protected set; }

        ///// <summary>
        ///// Returns the movement cost that this vegetation adds to the tile.
        ///// </summary>
        //public double MovementCost { get; protected set; }

        ///// <summary>
        ///// The percent that this vegetation has currently grown.
        ///// </summary>
        //private double PercentGrown { get; set; }

        ///// <summary>
        ///// The minimum amount of precipitation for this plant to survive.
        ///// </summary>
        //public double PrecipitationMin { get; protected set; }

        ///// <summary>
        ///// The maximum amount of precipitation that this plant can survive in centimeters.
        ///// </summary>
        //public double Precipitationmax { get; protected set; }

        ///// <summary>
        ///// The chance that this vegetation will reproduce and create a immature version of itself nearby.
        ///// </summary>
        //public double ReproductionChance { get; protected set; }

        ///// <summary>
        ///// The minimum amount of offspring this vegetation is allowed to create.
        ///// </summary>
        //public int OffSpringMin { get; protected set; }

        ///// <summary>
        ///// The maximum amount of offspring this vegetation is allowed to create.
        ///// </summary>
        //public int OffSpringMax { get; protected set; }

        ///// <summary>
        ///// The minimum amount of days between reproduction attempts.
        ///// </summary>
        //public int MinDaysBetweenReproduction { get; protected set; }

        ///// <summary>
        ///// If true, this vegetation is dormant. This is most likely due to winter.
        ///// </summary>
        //public bool IsDorment { get; set; }

        ///// <summary>
        ///// The range at which this plant could possibly create a immature version of itself.
        ///// </summary>
        //public int ReproductionRange { get; protected set; }

        ///// <summary>
        ///// The chance that the offspring of this vegetation will be slightly different due to a mutation.
        ///// </summary>
        //public double MutationChance { get; protected set; }

        ///// <summary>
        ///// The lowest amount of yield this vegetation can produce when fully grown.
        ///// </summary>
        //public double MinYield { get; protected set; }

        ///// <summary>
        ///// The highest amount of yield this vegetation can produce when fully grown.
        ///// </summary>
        //public double MaxYield { get; protected set; }

        ///// <summary>
        ///// Returns the percent that this vegetation has currently grown.
        ///// </summary>
        ///// <returns></returns>
        //public double GetPercentGrown()
        //{
        //    return this.PercentGrown;
        //}

        ///// <summary>
        ///// Gets the current yield of this vegatation.
        ///// </summary>
        ///// <returns></returns>
        //public abstract List<Item> GetCurrentYield();
    }
}