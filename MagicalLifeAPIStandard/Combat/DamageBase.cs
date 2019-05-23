using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Combat
{
    public abstract class DamageBase : IEquatable<DamageBase>
    {

        public readonly DamageTypes DamageTypes;

        public DamageBase()
        {
            DamageTypes = DamageTypes.FromValue(0);
            DamageAmount = 10;
        }

        public DamageBase(DamageTypes type, float damageAmount)
        {
            DamageTypes = type;
            DamageAmount = damageAmount;
        }

        public float DamageAmount { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is DamageBase)
            {
                return Equals(obj as DamageBase);
            }
            return false;

        }

        public bool Equals(DamageBase other)
        {
            return EqualityComparer<DamageTypes>.Default.Equals(DamageTypes, other.DamageTypes) &&
                   DamageAmount == other.DamageAmount;
        }

        public override int GetHashCode()
        {
            var hashCode = -424489883;
            hashCode = hashCode * -1521134295 + EqualityComparer<DamageTypes>.Default.GetHashCode(DamageTypes);
            hashCode = hashCode * -1521134295 + DamageAmount.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(DamageBase left, DamageBase right)
        {
            return EqualityComparer<DamageBase>.Default.Equals(left, right);
        }

        public static bool operator !=(DamageBase left, DamageBase right)
        {
            return !(left == right);
        }



    }
}
