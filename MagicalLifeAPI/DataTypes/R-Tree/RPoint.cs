//   Point2D.java
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
namespace RTree
{
    /// <summary>
    /// Currently hardcoded to 2 dimensions, but could be extended.
    /// author  aled@sourceforge.net
    /// version 1.0b2p1
    /// </summary>
    public class RPoint2D
    {
        /// <summary>
        /// Number of dimensions in a Point2D. In theory this
        /// could be exended to three or more dimensions.
        /// </summary>
        private const int DIMENSIONS = 2;

        /// <summary>
        /// The (x, y) coordinates of the Point2D.
        /// </summary>
        internal float[] coordinates;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">The x coordinate of the Point2D</param>
        /// <param name="y">The y coordinate of the Point2D</param>
        /// <param name="z">The z coordinate of the Point2D</param>
        public RPoint2D(float x, float y)
        {
            coordinates = new float[DIMENSIONS];
            coordinates[0] = x;
            coordinates[1] = y;
        }
    }
}