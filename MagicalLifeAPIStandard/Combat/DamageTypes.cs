using MagicalLifeAPI.Properties;
using MonoGUI.MonoLib.CustomTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Combat
{
    public class DamageTypes : Enumeration
    {
        public static readonly DamageTypes Poison = new DamageTypes(1, Lang.Poison);

        public static readonly DamageTypes Magic = new DamageTypes(2, Lang.Magic);

        public static readonly DamageTypes Fire = new DamageTypes(3, Lang.Fire);

        public static readonly DamageTypes Crushing = new DamageTypes(4, Lang.Crushing);

        public static readonly DamageTypes Piercing = new DamageTypes(5, Lang.Piercing);

        protected DamageTypes(int id, string name) : base(id, name)
        {
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DamageTypes))
            {
                return false;
            }

            DamageTypes damageTypes = obj as DamageTypes;

            if (!damageTypes.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (damageTypes.Id != Id)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            const int hash = 397;
            return hash * Id.GetHashCode() * Name.GetHashCode();
        }

        public static bool operator ==(DamageTypes left, DamageTypes right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(DamageTypes left, DamageTypes right)
        {
            return !(left == right);
        }

        public static bool operator <(DamageTypes left, DamageTypes right)
        {
            return left is null ? !(right is null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(DamageTypes left, DamageTypes right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        public static bool operator >(DamageTypes left, DamageTypes right)
        {
            return !(left is null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(DamageTypes left, DamageTypes right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }




    }
}