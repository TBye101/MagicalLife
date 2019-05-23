using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MagicalLifeAPI.Combat
{
    [DebuggerDisplay("DamageType = {DamageTypes} \n DamageAmount = {DamageAmount} ")]
    public class Damage : DamageBase
    {
        public Damage(DamageTypes type, float damageAmount) : base(type, damageAmount)
        {
        }

        public static Damage operator +(Damage damage, float amount)
        {
            return new Damage(damage.DamageTypes, damage.DamageAmount + amount);
        }

        public static Damage operator -(Damage damage, float amount)
        {
            return new Damage(damage.DamageTypes, damage.DamageAmount - amount);
        }

        public static Damage operator -(Damage damage, Resistance resistance)
        {
            if (resistance.DamageTypes == damage.DamageTypes)
            {
                return new Damage(damage.DamageTypes, damage.DamageAmount - resistance.DamageAmount);
            }
            else
            {
                throw new ArgumentException("Damage types of damage and resistance are not equal.");
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
