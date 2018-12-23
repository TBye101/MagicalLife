using ProtoBuf;
using System;

namespace MagicalLifeAPI.Entity.AI.Task.Qualifications
{
    /// <summary>
    /// Used to require that only a certain creature may do a task.
    /// </summary>
    [ProtoContract]
    public class SpecificCreatureQualification : Qualification
    {
        [ProtoMember(1)]
        public Guid CreatureID { get; set; }

        /// <param name="creatureID">The ID of the only creature allowed to do a task.</param>
        public SpecificCreatureQualification(Guid creatureID)
        {
            this.CreatureID = creatureID;
        }

        public SpecificCreatureQualification()
        {
            //Protobuf-net constructor.
        }

        public override bool IsQualified(Living l)
        {
            return l.ID.Equals(this.CreatureID);
        }
    }
}