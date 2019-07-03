namespace MagicalLifeAPI.Entity.AI.Task
{
    /// <summary>
    /// Holds priority levels for various tasks.
    /// </summary>
    public static class PriorityLayers
    {
        public static readonly int Default = 10000;

        /// <summary>
        /// Any task that requires a specific creature to complete it should be completed first, almost always.
        /// </summary>
        public static readonly int SpecificCreature = 20000;
    }
}