using ProtoBuf;

namespace MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions
{
    /// <summary>
    /// We shall never remove this modifier.
    /// </summary>
    [ProtoContract]
    public class NeverRemoveCondition : IModifierRemoveCondition
    {
        public bool WearOff()
        {
            return false;
        }
    }
}