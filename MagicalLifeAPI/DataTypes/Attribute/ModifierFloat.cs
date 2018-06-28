using MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entity.Util
{
    /// <summary>
    /// Used to store a modifier, and some other information for internal use.
    /// </summary>
    [ProtoContract]
    public struct ModifierFloat
    {
        [ProtoMember(1)]
        public float Value;

        [ProtoMember(2)]
        public IModifierRemoveCondition RemoveCondition;

        [ProtoMember(3)]
        public string Explanation;

        public ModifierFloat(float value, IModifierRemoveCondition removeCondition, string explanation)
        {
            this.Value = value;
            this.RemoveCondition = removeCondition;
            this.Explanation = explanation;
        }
    }
}
