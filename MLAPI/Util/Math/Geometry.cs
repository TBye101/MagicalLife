using MagicalLifeAPI.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeAPI.Util.Math
{
    /// <summary>
    /// Does some basic geometry.
    /// </summary>
    public static class Geometry
    {
        /// <summary>
        /// Returns all of the points on the actual lines that make up the rectangle.
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static List<Point2D> GetAllPointsOnRectangle(MagicRectangle rectangle)
        {
            Point2D TopRight = new Point2D(rectangle.BottomRight.X, rectangle.TopLeft.Y);
            Point2D BottomLeft = new Point2D(rectangle.TopLeft.X, rectangle.BottomRight.Y);

            HashSet<Point2D> TopLine = new HashSet<Point2D>(GetPointsOnHorizontalLine(rectangle.TopLeft, TopRight));
            HashSet<Point2D> RightLine = new HashSet<Point2D>(GetPointsOnVerticalLine(TopRight, rectangle.BottomRight));
            HashSet<Point2D> BottomLine = new HashSet<Point2D>(GetPointsOnHorizontalLine(BottomLeft, rectangle.BottomRight));
            HashSet<Point2D> LeftLine = new HashSet<Point2D>(GetPointsOnVerticalLine(rectangle.TopLeft, BottomLeft));

            TopLine.UnionWith(RightLine);
            TopLine.UnionWith(BottomLine);
            TopLine.UnionWith(LeftLine);

            return TopLine.ToList();
        }

        /// <summary>
        /// Returns all of the points that fall on the horizontal line.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<Point2D> GetPointsOnHorizontalLine(Point2D start, Point2D end)
        {
            if (start.Y == end.Y)
            {
                if (start.X == end.X)
                {
                    throw new ArgumentException("Expected a horizontal line, but got a point instead");
                }
                else
                {
                    List<Point2D> ret = new List<Point2D>(end.X - start.X + 1);

                    for (int i = start.X; i < end.X; i++)
                    {
                        ret.Add(new Point2D(i, start.Y));
                    }

                    return ret;
                }
            }
            else
            {
                throw new ArgumentException("Expected a horizontal line, but did not get one");
            }
        }

        /// <summary>
        /// Returns all of the points that fall on the vertical line.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<Point2D> GetPointsOnVerticalLine(Point2D start, Point2D end)
        {
            if (start.X == end.X)
            {
                if (start.Y == end.Y)
                {
                    throw new ArgumentException("Expected a vertical line, but got a point instead");
                }
                else
                {
                    List<Point2D> ret = new List<Point2D>(end.Y - start.Y + 1);

                    for (int i = start.Y; i < end.Y; i++)
                    {
                        ret.Add(new Point2D(start.X, i));
                    }

                    return ret;
                }
            }
            else
            {
                throw new ArgumentException("Expected a vertical line, but did not get one");
            }
        }

        /// <summary>
        /// Returns the slope of the line.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CalculateSlopeFromLine(Point2D start, Point2D end)
        {
            // (Y2 - Y1) / (X2 - X1) = Rise/Run = Slope
            return (end.Y - start.Y) / (end.X - start.X);
        }

        /// <param name="origin">The point to calculate distance to all points being ordered.</param>
        /// <param name="points">The points to order by how close they are to the origin point.</param>
        public static void OrderPointsByProximity(Point2D origin, List<Point2D> points)
        {
            points.Sort((pointA, pointB) => MathUtil.GetDistanceFast(pointA, origin).CompareTo(MathUtil.GetDistanceFast(pointB, origin)));
        }

        /// <param name="origin">The point to calculate distance to all points being ordered.</param>
        /// <param name="points">The points to order by how close they are to the origin point.</param>
        public static void OrderPointsByProximity(Point3D origin, List<Point3D> points)
        {
            points.Sort((pointA, pointB) => MathUtil.GetDistanceFast(pointA, origin).CompareTo(MathUtil.GetDistanceFast(pointB, origin)));
        }

        /// <summary>
        /// If in the inequation, results comes less than 1 then the point lies within, 
        /// else if it comes exact 1 then the point lies on the ellipse, 
        /// and if the inequation is unsatisfied then point lies outside of the ellipse.
        /// </summary>
        private static int ElipseCheckPoint(int h, int k, int x,
                  int y, int a, int b)
        {
            //Courtesy of:
            //https://www.geeksforgeeks.org/check-if-a-point-is-inside-outside-or-on-the-ellipse/
            //int p = ((int)System.Math.Pow((x - h), 2) /
            //         (int)System.Math.Pow(a, 2)) +
            //        ((int)System.Math.Pow((y - k), 2) /
            //         (int)System.Math.Pow(b, 2));
            int p = (int)(System.Math.Pow((x - h), 2) /
                     (System.Math.Pow(a, 2)) +
                    ((System.Math.Pow((y - k), 2) /
                     (System.Math.Pow(b, 2)))));

            return p;
        }

        /// <summary>
        /// Returns a list of the points within the elipse of specified thickness and origin.
        /// </summary>
        public static List<Point3D> GetPointsOnElipse(int elipseWidth, int elipseHeight, int elipseThickness, Guid dimensionID, int dimensionWidth, int dimensionHeight, Point3D origin)
        {
            //(((x - h)^2) / a^2) + (((y - k)^2) / b^2) = 1
            //ellipse center at (h, k)
            //Horizontal radius is 'a' and vertical radius is 'b'

            //Elipse 1 is the smaller inner elipse
            //Elipse 2 is the larger outer elipse
            //The distance between the two is roughly the thickness property of the elipse
            //This allows for the checking of the points in a thick elipse

            int elipse2Width = elipseWidth + (2 * elipseThickness);
            int elipse2Height = elipseHeight + (2 * elipseThickness);
            int a1 = elipseWidth / 2;
            int a2 = elipse2Width / 2;
            int b1 = elipseHeight / 2;
            int b2 = elipse2Height / 2;
            int h = origin.X;
            int k = origin.Y;
            int leftBoundX = origin.X - (elipse2Width / 2);
            int rightBoundX = origin.X + (elipse2Width / 2);
            int topBoundY = origin.Y - (elipse2Height / 2);
            int bottomBoundY = origin.Y + (elipse2Height / 2);

            List<Point3D> points = new List<Point3D>();

            //Check elipse bounds for non-existant positions
            leftBoundX = System.Math.Max(0, leftBoundX);
            rightBoundX = System.Math.Min(dimensionWidth, rightBoundX);
            topBoundY = System.Math.Max(0, topBoundY);
            bottomBoundY = System.Math.Min(dimensionHeight, bottomBoundY);

            for (int x = leftBoundX; x < rightBoundX; x++)
            {
                for (int y = topBoundY; y < bottomBoundY; y++)
                {
                    //Check each point in elipse bounds to see if it's within the two elipses
                    int elipse2Result = ElipseCheckPoint(h, k, x, y, a2, b2);
                    int elipse1Result = ElipseCheckPoint(h, k, x, y, a1, b1);

                    //if (elipse2Result <= 1 && elipse1Result > 1)
                    //{
                    //    points.Add(new Point3D(x, y, dimensionID));
                    //}

                    if (elipse2Result <= 1)
                    {
                        //inside or on elipse2
                        if (elipse1Result >= 1)
                        {
                            //On or outside elipse1
                            points.Add(new Point3D(x, y, dimensionID));
                        }
                    }
                }
            }

            return points;
        }
    }
}