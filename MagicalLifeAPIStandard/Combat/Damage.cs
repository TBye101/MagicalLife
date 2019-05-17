using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MagicalLifeAPI.Combat
{
    [DebuggerDisplay("DamageType = {DamageTypes} \n DamageAmount = {DamageAmount} ")]
    public class Damage : IEquatable<Damage>
    {
        public readonly DamageTypes DamageTypes;

        public Damage()
        {
            DamageTypes = DamageTypes.FromValue(0);
            DamageAmount = 10;
        }

        public Damage(DamageTypes type, float damageAmount)
        {
            DamageTypes = type;
            DamageAmount = damageAmount;
        }

        public float DamageAmount { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Damage)
            {
                return Equals(obj as Damage);
            }
            return false;

        }

        public bool Equals(Damage other)
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

        public static bool operator ==(Damage left, Damage right)
        {
            return EqualityComparer<Damage>.Default.Equals(left, right);
        }

        public static bool operator !=(Damage left, Damage right)
        {
            return !(left == right);
        }

        public static Damage operator +(Damage damage, float amount)
        {
            return new Damage(damage.DamageTypes, damage.DamageAmount + amount);
        }

        public static Damage operator -(Damage damage, float amount)
        {
            return new Damage(damage.DamageTypes, damage.DamageAmount - amount);
        }

        public static Damage operator -(Damage damage, Damage resistance)
        {
           if(resistance.DamageTypes != damage.DamageTypes)
           {
                throw new ArgumentException("Damage Types do not match. Cannot subtract.");
           }
           else
            {
                return new Damage(damage.DamageTypes, damage.DamageAmount - resistance.DamageAmount);
            }
        }


        public static Damage operator *(Damage damage, float amount)
        {
            return new Damage(damage.DamageTypes, damage.DamageAmount * amount);
        }

        public static Damage operator /(Damage damage, float amount)
        {
            return new Damage(damage.DamageTypes, damage.DamageAmount / amount);
        }



    }
}
