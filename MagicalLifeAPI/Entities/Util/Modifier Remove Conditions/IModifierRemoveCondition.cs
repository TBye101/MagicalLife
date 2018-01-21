namespace MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions
{
    /// <summary>
    /// Utilized to allow for custom events/circumstances to be used to determine when a modifier wears off.
    /// </summary>
    public interface IModifierRemoveCondition
    {
        /// <summary>
        /// Returns true if this modifier should be removed from the attribute it is effecting.
        /// </summary>
        /// <returns></returns>
        bool WearOff();
    }
}