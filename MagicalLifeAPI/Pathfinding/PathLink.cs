using Microsoft.Xna.Framework;

namespace MagicalLifeAPI.Pathfinding
{
    /// <summary>
    /// Used to describe the steps a entity will take between two points for path finding.
    /// </summary>
    public class PathLink
    {
        public Point Origin;
        public Point Destination;

        public PathLink(Point origin, Point destination)
        {
            this.Origin = origin;
            this.Destination = destination;
        }
    }
}