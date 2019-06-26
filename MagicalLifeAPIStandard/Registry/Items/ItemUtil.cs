using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.Base;
using System;
using System.Collections.Generic;

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
        public static void ReserveItems(List<Point3D> locations, Guid reservingID)
        {
            Tile tile;
            foreach (Point3D item in locations)
            {
                tile = World.Data.World.GetTile(item.DimensionID, item.X, item.Y);

                Item tileItem = tile.MainObject as Item;
                tileItem.ReservedID = reservingID;
            }
        }
    }
}