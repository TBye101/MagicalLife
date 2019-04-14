using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Registry.Items
{
    /// <summary>
    /// A Item related utility class.
    /// </summary>
    public static class ItemUtil
    {
        /// <summary>
        /// Reserves the items at the specified locations with the provided ID.
        /// </summary>
        public static void ReserveItems(List<Point2D> locations, Guid reservingID, int dimension)
        {
            Tile tile;
            foreach (Point2D item in locations)
            {
                tile = World.Data.World.GetTile(dimension, item.X, item.Y);
                tile.Item.ReservedID = reservingID;
            }
        }
    }
}
