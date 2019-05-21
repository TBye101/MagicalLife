using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MagicalLifeAPI.Combat
{
    [DebuggerDisplay("DamageType = {DamageTypes} \n DamageAmount = {DamageAmount} ")]
    public class Resistance : DamageBase
    {
        public Resistance() :base()
        {

        }

        public Resistance(DamageTypes damageTypes, float damageAmount ) :base(damageTypes,damageAmount)
        {

        }
    }
}
