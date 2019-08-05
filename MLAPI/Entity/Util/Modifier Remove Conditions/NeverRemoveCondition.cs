using ProtoBuf;

namespace MLAPI.Entity.Util.Modifier_Remove_Conditions
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