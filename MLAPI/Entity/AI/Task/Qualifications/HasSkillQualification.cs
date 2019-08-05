using ProtoBuf;

namespace MLAPI.Entity.AI.Task.Qualifications
{
    /// <summary>
    /// Requires a creature to have a certain skill to do something.
    /// </summary>
    [ProtoContract]
    public class HasSkillQualification : Qualification
    {
        [ProtoMember(1)]
        private string InternalSkillName { get; set; }

        public HasSkillQualification(string internalSkillName)
        {
            this.InternalSkillName = internalSkillName;
        }

        protected HasSkillQualification()
        {
            //Protobuf-net constructor
        }

        public override bool IsQualified(Living l)
        {
            return l.CreatureSkills.Find(x => x.InternalName == this.InternalSkillName) != null;
        }

        public override bool ArePreconditionsMet()
        {
            return true;
        }
    }
}