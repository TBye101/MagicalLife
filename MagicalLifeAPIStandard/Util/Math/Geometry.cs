using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Error.InternalExceptions;
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
                    throw new InvalidDataException("Expected a horizontal line, but got a point instead");
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
                throw new InvalidDataException("Expected a horizontal line, but did not get one");
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
                    throw new InvalidDataException("Expected a vertical line, but got a point instead");
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
                throw new InvalidDataException("Expected a vertical line, but did not get one");
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
    }
}