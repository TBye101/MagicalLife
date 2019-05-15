using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MonoGUI.MonoLib.CustomTypes
{
    public abstract class Enumeration : IComparable, IEquatable<Enumeration>
    {
        public string Name { get; private set; }

        public int Id { get; private set; }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue))
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }


        public int CompareTo(object obj) => Id.CompareTo(((Enumeration)obj).Id);

        public bool Equals(Enumeration other)
        {
            return other != null
                   && Name == other.Name
                   && Id == other.Id;
        }

        public override int GetHashCode()
        {
            var hashCode = 1460282102;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = (hashCode * -1521134295) + Id.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Enumeration left, Enumeration right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Enumeration left, Enumeration right)
        {
            return !(left == right);
        }

        public static bool operator <(Enumeration left, Enumeration right)
        {
            return left is null ? !(right is null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Enumeration left, Enumeration right)
        {
            return (left is null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Enumeration left, Enumeration right)
        {
            return !(left is null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Enumeration left, Enumeration right)
        {
            return (left is null) ? (right is null) : left.CompareTo(right) >= 0;
        }

      


        //public static Enumeration FromString(string roleString)
        //{
        //    return new List<Enumeration>().Single(r => string.Equals(r.Name, roleString, StringComparison.OrdinalIgnoreCase));
        //}

        //public abstract 

        // Other utility methods ...
    }
}
