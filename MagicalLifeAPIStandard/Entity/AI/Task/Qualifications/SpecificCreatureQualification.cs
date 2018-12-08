using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

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
        public SpecificCreatureQualification(Guid creatureID) : base()
        {
            this.CreatureID = creatureID;
        }

        public SpecificCreatureQualification() : base()
        {
            //Protobuf-net constructor.
        }

        public override bool IsQualified(Living l)
        {
            return l.ID.Equals(this.CreatureID);
        }
    }
}
