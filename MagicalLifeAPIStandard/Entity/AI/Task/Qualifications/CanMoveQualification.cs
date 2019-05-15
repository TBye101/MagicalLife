using MagicalLifeAPI.Components.Entity;
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

        public override bool ArePreconditionsMet()
        {
            return true;
        }

        public override bool IsQualified(Living l)
        {
            ComponentMovement movementComponent = l.GetExactComponent<ComponentMovement>();
            return movementComponent.Movement.GetValue() > 0;
        }
    }
}