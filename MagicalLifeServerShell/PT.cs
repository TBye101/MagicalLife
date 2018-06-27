using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeServerShell
{
    public class PT : IEquatable<PT>
    {

        //
        // Summary:
        //     The x coordinate of this Microsoft.Xna.Framework.PT.
        [DataMember]
        public int X;
        //
        // Summary:
        //     The y coordinate of this Microsoft.Xna.Framework.PT.
        [DataMember]
        public int Y;

        //
        // Summary:
        //     Constructs a PT with X and Y set to the same value.
        //
        // Parameters:
        //   value:
        //     The x and y coordinates in 2d-space.
        public PT(int value)
        {
            this.X = value;
            this.Y = value;
        }
        //
        // Summary:
        //     Constructs a PT with X and Y from two values.
        //
        // Parameters:
        //   x:
        //     The x coordinate in 2d-space.
        //
        //   y:
        //     The y coordinate in 2d-space.
        public PT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        //
        // Summary:
        //     Returns a Microsoft.Xna.Framework.PT with coordinates 0, 0.
        public static PT Zero { get; }

        //
        // Summary:
        //     Compares whether current instance is equal to specified System.Object.
        //
        // Parameters:
        //   obj:
        //     The System.Object to compare.
        //
        // Returns:
        //     true if the instances are equal; false otherwise.
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Compares whether current instance is equal to specified Microsoft.Xna.Framework.PT.
        //
        // Parameters:
        //   other:
        //     The Microsoft.Xna.Framework.PT to compare.
        //
        // Returns:
        //     true if the instances are equal; false otherwise.
        public bool Equals(PT other)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Gets the hash code of this Microsoft.Xna.Framework.PT.
        //
        // Returns:
        //     Hash code of this Microsoft.Xna.Framework.PT.
        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode();
        }
        //
        // Summary:
        //     Returns a System.String representation of this Microsoft.Xna.Framework.PT
        //     in the format: {X:[Microsoft.Xna.Framework.PT.X] Y:[Microsoft.Xna.Framework.PT.Y]}
        //
        // Returns:
        //     System.String representation of this Microsoft.Xna.Framework.PT.
        public override string ToString()
        {
            return this.X.ToString();
        }
        //
        // Summary:
        //     Gets a Microsoft.Xna.Framework.Vector2 representation for this object.
        //
        // Returns:
        //     A Microsoft.Xna.Framework.Vector2 representation for this object.
        public Vector2 ToVector2()
        {
            return new Vector2(this.X, this.Y);
        }

        //
        // Summary:
        //     Adds two PTs.
        //
        // Parameters:
        //   value1:
        //     Source Microsoft.Xna.Framework.PT on the left of the add sign.
        //
        //   value2:
        //     Source Microsoft.Xna.Framework.PT on the right of the add sign.
        //
        // Returns:
        //     Sum of the PTs.
        public static PT operator +(PT value1, PT value2)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Subtracts a Microsoft.Xna.Framework.PT from a Microsoft.Xna.Framework.PT.
        //
        // Parameters:
        //   value1:
        //     Source Microsoft.Xna.Framework.PT on the left of the sub sign.
        //
        //   value2:
        //     Source Microsoft.Xna.Framework.PT on the right of the sub sign.
        //
        // Returns:
        //     Result of the subtraction.
        public static PT operator -(PT value1, PT value2)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Multiplies the components of two PTs by each other.
        //
        // Parameters:
        //   value1:
        //     Source Microsoft.Xna.Framework.PT on the left of the mul sign.
        //
        //   value2:
        //     Source Microsoft.Xna.Framework.PT on the right of the mul sign.
        //
        // Returns:
        //     Result of the multiplication.
        public static PT operator *(PT value1, PT value2)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Divides the components of a Microsoft.Xna.Framework.PT by the components of
        //     another Microsoft.Xna.Framework.PT.
        //
        // Parameters:
        //   source:
        //     Source Microsoft.Xna.Framework.PT on the left of the div sign.
        //
        //   divisor:
        //     Divisor Microsoft.Xna.Framework.PT on the right of the div sign.
        //
        // Returns:
        //     The result of dividing the PTs.
        public static PT operator /(PT source, PT divisor)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Compares whether two Microsoft.Xna.Framework.PT instances are equal.
        //
        // Parameters:
        //   a:
        //     Microsoft.Xna.Framework.PT instance on the left of the equal sign.
        //
        //   b:
        //     Microsoft.Xna.Framework.PT instance on the right of the equal sign.
        //
        // Returns:
        //     true if the instances are equal; false otherwise.
        public static bool operator ==(PT a, PT b)
        {
            throw new NotImplementedException();
        }
        //
        // Summary:
        //     Compares whether two Microsoft.Xna.Framework.PT instances are not equal.
        //
        // Parameters:
        //   a:
        //     Microsoft.Xna.Framework.PT instance on the left of the not equal sign.
        //
        //   b:
        //     Microsoft.Xna.Framework.PT instance on the right of the not equal sign.
        //
        // Returns:
        //     true if the instances are not equal; false otherwise.
        public static bool operator !=(PT a, PT b)
        {
            throw new NotImplementedException();
        }
    }
}
