using MagicalLifeAPI.Util;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.World;

namespace MagicalLifeAPI.Entities.Entity_Components.Movement_Rules
{
    /// <summary>
    /// Holds the standard rules for movement.
    /// </summary>
    public class StandardMovement : IMovementRule
    {
        public bool CanMoveHere(Tile destination, Tile start, World.World world, Living creature)
        {
            Point3D One = start.Location;
            Point3D Two = destination.Location;
            Point A = new Point((int)One.X, (int)One.Y);
            Point B = new Point((int)Two.X, (int)Two.Y);

            int distance = MathUtil.GetDistance(A, B);

            return distance <= 1;
        }
    }
}
