using System;
using ProtoBuf;

namespace MLAPI.Entity.AI.Task.Qualifications
{
    /// <summary>
    /// Used to require that only a certain creature may do a task.
    /// </summary>
    [ProtoContract]
    public class SpecificCreatureQualification : Qualification
    {
        [ProtoMember(1)]
        public Guid CreatureId { get; set; }

        /// <param name="creatureId">The ID of the only creature allowed to do a task.</param>
        public SpecificCreatureQualification(Guid creatureId)
        {
            this.CreatureId = creatureId;
        }

        protected SpecificCreatureQualification()
        {
            //Protobuf-net constructor.
        }

        public override bool IsQualified(Living l)
        {
            return l.Id.Equals(this.CreatureId);
        }

        public override bool ArePreconditionsMet()
        {
            return true;
        }
    }
}