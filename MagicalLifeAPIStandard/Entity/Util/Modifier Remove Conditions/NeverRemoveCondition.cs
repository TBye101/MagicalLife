using ProtoBuf;

namespace MagicalLifeAPI.Entity.Util.Modifier
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