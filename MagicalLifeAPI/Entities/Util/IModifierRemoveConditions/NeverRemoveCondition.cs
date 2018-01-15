namespace MagicalLifeAPI.Entities.Util.IModifierRemoveConditions
{
    /// <summary>
    /// We shall never remove this modifier.
    /// </summary>
    public class NeverRemoveCondition : IModifierRemoveCondition
    {
        public bool WearOff()
        {
            return false;
        }
    }
}