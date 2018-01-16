using MagicalLifeAPI.Util;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.World;
using DijkstraAlgorithm.Pathing;

namespace MagicalLifeAPI.Entities.Entity_Components.Movement_Rules
{
    /// <summary>
    /// Holds the standard rules for movement.
    /// </summary>
    public class StandardMovement : IMovementRule
    {
        public Path GetOptimalPath(Tile start, Tile destination, World.World world, Living creature, out bool isPossible)
        {
            throw new NotImplementedException();
        }
    }
}
