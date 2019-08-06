using System;
using System.Collections.Generic;
using System.Text;
using MLAPI.DataTypes;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator.ForceDirectedGraph
{
    internal struct ForceVector
    {
        /// <summary>
        /// The magnitude of the vector.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The direction of the vector, in radians.
        /// </summary>
        public double Y { get; set; }

        /// <param name="magnitude">The magnitude of the vector.</param>
        /// <param name="direction">The direction of the vector, in radians.</param>
        public ForceVector(double magnitude, double direction)
        {
            this.X = magnitude * Math.Cos((Math.PI / 180.0) * direction);
            this.Y = magnitude * Math.Sin((Math.PI / 180.0) * direction);
        }

        /// <summary>
        /// Adds two vectors together.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static ForceVector operator +(ForceVector a, ForceVector b) {
            return new ForceVector
            {
                X = a.X + b.X, 
                Y = a.Y + b.Y
            };
        }

        /// <summary>
        /// Multiplies a vector by a scalar value.
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static ForceVector operator *(ForceVector vector, double multiplier)
        {
            return new ForceVector
            {
                X = vector.X * multiplier,
                Y = vector.Y * multiplier
            };
        }

        /// <summary>
        /// Returns a <see cref="System.Drawing.Point"/> that is equivalent to the vector.
        /// </summary>
        /// <returns></returns>
        public Point2D ToPoint() 
        {
            return new Point2D((int)this.X, (int)this.Y);
        }
    }
}
