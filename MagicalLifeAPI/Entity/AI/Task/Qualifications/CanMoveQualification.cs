using ProtoBuf;

namespace MagicalLifeAPI.Entity.AI.Task.Qualifications
{
    /// <summary>
    /// A creature must be able to move to meet this criteria.
    /// </summary>
    [ProtoContract]
    public class CanMoveQualification : Qualification
    {
        public CanMoveQualification()
        {
        }

        public override bool IsQualified(Living l)
        {
            return l.Movement.GetValue() > 0;
        }
    }
}