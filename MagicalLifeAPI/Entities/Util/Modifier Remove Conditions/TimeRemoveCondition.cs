namespace MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions
{
    /// <summary>
    /// This modifier condition allows remove of the modifier after a certain number of turns.
    /// </summary>
    public class TimeRemoveCondition : IModifierRemoveCondition
    {
        private int Turns;

        /// <summary>
        ///The constructor for the <see cref="TimeRemoveCondition"/> class.
        /// </summary>
        /// <param name="turns">The number of turns until the modifier is allowed to expire.</param>
        public TimeRemoveCondition(int turns)
        {
            this.Turns = turns;
        }

        public bool WearOff()
        {
            this.Turns--;

            return this.Turns == 0;
        }
    }
}