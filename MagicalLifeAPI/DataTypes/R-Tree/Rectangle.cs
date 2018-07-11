//   Rectangle.java
//   Java Spatial Index Library
//   Copyright (C) 2002 Infomatiq Limited
//  
//  This library is free software; you can redistribute it and/or
//  modify it under the terms of the GNU Lesser General Public
//  License as published by the Free Software Foundation; either
//  version 2.1 of the License, or (at your option) any later version.
//  
//  This library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//  Lesser General Public License for more details.
//  
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307 USA

// Ported to C# By Dror Gluska, April 9th, 2009

using System;
using System.Text;

namespace RTree
{

    /**
     * Currently hardcoded to 2 dimensions, but could be extended.
     * 
     * @author  aled@sourceforge.net
     * @version 1.0b2p1
     */
    public class Rectangle
    {
        /**
         * Number of dimensions in a rectangle. In theory this
         * could be exended to three or more dimensions.
         */
        internal const int DIMENSIONS = 3;

        /**
         * array containing the minimum value for each dimension; ie { min(x), min(y) }
         */
        internal float[] max;

        /**
         * array containing the maximum value for each dimension; ie { max(x), max(y) }
         */
        internal float[] min;

        /**
         * Constructor.
         * 
         * @param x1 coordinate of any corner of the rectangle
         * @param y1 (see x1)
         * @param x2 coordinate of the opposite corner
         * @param y2 (see x2)
         */
        public Rectangle(float x1, float y1, float x2, float y2, float z1, float z2)
        {
            min = new float[DIMENSIONS];
            max = new float[DIMENSIONS];
            set(x1, y1, x2, y2, z1, z2);
        }

        /**
         * Constructor.
         * 
         * @param min array containing the minimum value for each dimension; ie { min(x), min(y) }
         * @param max array containing the maximum value for each dimension; ie { max(x), max(y) }
         */
        public Rectangle(float[] min, float[] max)
        {
            if (min.Length != DIMENSIONS || max.Length != DIMENSIONS)
            {
                throw new Exception("Error in Rectangle constructor: " +
                          "min and max arrays must be of length " + DIMENSIONS);
            }

            this.min = new float[DIMENSIONS];
            this.max = new float[DIMENSIONS];

            set(min, max);
        }

        /**
          * Sets the size of the rectangle.
          * 
          * @param x1 coordinate of any corner of the rectangle
          * @param y1 (see x1)
          * @param x2 coordinate of the opposite corner
          * @param y2 (see x2)
          */
        internal void set(float x1, float y1, float x2, float y2, float z1, float z2)
        {
            min[0] = Math.Min(x1, x2);
            min[1] = Math.Min(y1, y2);
            min[2] = Math.Min(z1, z2);
            max[0] = Math.Max(x1, x2);
            max[1] = Math.Max(y1, y2);
            max[2] = Math.Max(z1, z2);
        }

        /**
         * Sets the size of the rectangle.
         * 
         * @param min array containing the minimum value for each dimension; ie { min(x), min(y) }
         * @param max array containing the maximum value for each dimension; ie { max(x), max(y) }
         */
        internal void set(float[] min, float[] max)
        {
            System.Array.Copy(min, 0, this.min, 0, DIMENSIONS);
            System.Array.Copy(max, 0, this.max, 0, DIMENSIONS);
        }

        /**
         * Make a copy of this rectangle
         * 
         * @return copy of this rectangle
         */
        internal Rectangle copy()
        {
            return new Rectangle(min, max);
        }

        /**
         * Determine whether an edge of this rectangle overlies the equivalent 
         * edge of the passed rectangle
         */
        internal bool edgeOverlaps(Rectangle r)
        {
            for (int i = 0; i < DIMENSIONS; i++)
            {
                if (min[i] == r.min[i] || max[i] == r.max[i])
                {
                    return true;
                }
            }
            return false;
        }

        /**
         * Determine whether this rectangle intersects the passed rectangle
         * 
         * @param r The rectangle that might intersect this rectangle
         * 
         * @return true if the rectangles intersect, false if they do not intersect
         */
        internal bool intersects(Rectangle r)
        {
            // Every dimension must intersect. If any dimension
            // does not intersect, return false immediately.
            for (int i = 0; i < DIMENSIONS; i++)
            {
                if (max[i] < r.min[i] || min[i] > r.max[i])
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * Determine whether this rectangle contains the passed rectangle
         * 
         * @param r The rectangle that might be contained by this rectangle
         * 
         * @return true if this rectangle contains the passed rectangle, false if
         *         it does not
         */
        internal bool contains(Rectangle r)
        {
            for (int i = 0; i < DIMENSIONS; i++)
            {
                if (max[i] < r.max[i] || min[i] > r.min[i])
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * Determine whether this rectangle is contained by the passed rectangle
         * 
         * @param r The rectangle that might contain this rectangle
         * 
         * @return true if the passed rectangle contains this rectangle, false if
         *         it does not
         */
        internal bool containedBy(Rectangle r)
        {
            for (int i = 0; i < DIMENSIONS; i++)
            {
                if (max[i] > r.max[i] || min[i] < r.min[i])
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * Return the distance between this rectangle and the passed point.
         * If the rectangle contains the point, the distance is zero.
         * 
         * @param p Point to find the distance to
         * 
         * @return distance beween this rectangle and the passed point.
         */
        internal float distance(Point p)
        {
            float distanceSquared = 0;
            for (int i = 0; i < DIMENSIONS; i++)
            {
                float greatestMin = Math.Max(min[i], p.coordinates[i]);
                float leastMax = Math.Min(max[i], p.coordinates[i]);
                if (greatestMin > leastMax)
                {
                    distanceSquared += ((greatestMin - leastMax) * (greatestMin - leastMax));
                }
            }
            return (float)Math.Sqrt(distanceSquared);
        }

        /**
         * Return the distance between this rectangle and the passed rectangle.
         * If the rectangles overlap, the distance is zero.
         * 
         * @param r Rectangle to find the distance to
         * 
         * @return distance between this rectangle and the passed rectangle
         */

        internal float distance(Rectangle r)
        {
            float distanceSquared = 0;
            for (int i = 0; i < DIMENSIONS; i++)
            {
                float greatestMin = Math.Max(min[i], r.min[i]);
                float leastMax = Math.Min(max[i], r.max[i]);
                if (greatestMin > leastMax)
                {
                    distanceSquared += ((greatestMin - leastMax) * (greatestMin - leastMax));
                }
            }
            return (float)Math.Sqrt(distanceSquared);
        }

        /**
         * Return the squared distance from this rectangle to the passed point
         */
        internal float distanceSquared(int dimension, float point)
        {
            float distanceSquared = 0;
            float tempDistance = point - max[dimension];
            for (int i = 0; i < 2; i++)
            {
                if (tempDistance > 0)
                {
                    distanceSquared = (tempDistance * tempDistance);
                    break;
                }
                tempDistance = min[dimension] - point;
            }
            return distanceSquared;
        }

        /**
         * Return the furthst possible distance between this rectangle and
         * the passed rectangle. 
         * 
         * Find the distance between this rectangle and each corner of the
         * passed rectangle, and use the maximum.
         *
         */
        internal float furthestDistance(Rectangle r)
        {
            float distanceSquared = 0;

            for (int i = 0; i < DIMENSIONS; i++)
            {
                distanceSquared += Math.Max(r.min[i], r.max[i]);
#warning possible didn't convert properly
                //distanceSquared += Math.Max(distanceSquared(i, r.min[i]), distanceSquared(i, r.max[i]));
            }

            return (float)Math.Sqrt(distanceSquared);
        }

        /**
         * Calculate the area by which this rectangle would be enlarged if
         * added to the passed rectangle. Neither rectangle is altered.
         * 
         * @param r Rectangle to union with this rectangle, in order to 
         *          compute the difference in area of the union and the
         *          original rectangle
         */
        internal float enlargement(Rectangle r)
        {
            float enlargedArea = (Math.Max(max[0], r.max[0]) - Math.Min(min[0], r.min[0])) *
                                 (Math.Max(max[1], r.max[1]) - Math.Min(min[1], r.min[1]));

            return enlargedArea - area();
        }

        /**
         * Compute the area of this rectangle.
         * 
         * @return The area of this rectangle
         */
        internal float area()
        {
            return (max[0] - min[0]) * (max[1] - min[1]);
        }

        /**
         * Computes the union of this rectangle and the passed rectangle, storing
         * the result in this rectangle.
         * 
         * @param r Rectangle to add to this rectangle
         */
        internal void add(Rectangle r)
        {
            for (int i = 0; i < DIMENSIONS; i++)
            {
                if (r.min[i] < min[i])
                {
                    min[i] = r.min[i];
                }
                if (r.max[i] > max[i])
                {
                    max[i] = r.max[i];
                }
            }
        }

        /**
         * Find the the union of this rectangle and the passed rectangle.
         * Neither rectangle is altered
         * 
         * @param r The rectangle to union with this rectangle
         */
        internal Rectangle union(Rectangle r)
        {
            Rectangle union = this.copy();
            union.add(r);
            return union;
        }

        internal bool CompareArrays(float[] a1, float[] a2)
        {
            if ((a1 == null) || (a2 == null))
                return false;
            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;
            return true;
        }

        /**
         * Determine whether this rectangle is equal to a given object.
         * Equality is determined by the bounds of the rectangle.
         * 
         * @param o The object to compare with this rectangle
         */
        public override bool Equals(object obj)
        {
            bool equals = false;
            if (obj.GetType() == typeof(Rectangle))
            {
                Rectangle r = (Rectangle)obj;
#warning possible didn't convert properly
                if (CompareArrays(r.min, min) && CompareArrays(r.max, max))
                {
                    equals = true;
                }
            }
            return equals;
        }

        /** 
         * Determine whether this rectangle is the same as another object
         * 
         * Note that two rectangles can be equal but not the same object, 
         * if they both have the same bounds.
         * 
         * @param o The object to compare with this rectangle.
         */
        internal bool sameObject(object o)
        {
            return base.Equals(o);
        }

        /**
         * Return a string representation of this rectangle, in the form: 
         * (1.2, 3.4), (5.6, 7.8)
         * 
         * @return String String representation of this rectangle.
         */

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // min coordinates
            sb.Append('(');
            for (int i = 0; i < DIMENSIONS; i++)
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }
                sb.Append(min[i]);
            }
            sb.Append("), (");

            // max coordinates
            for (int i = 0; i < DIMENSIONS; i++)
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }
                sb.Append(max[i]);
            }
            sb.Append(')');
            return sb.ToString();
        }
    }
}