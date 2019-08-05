using System;
using System.Collections.Generic;
using MLAPI.DataTypes;
using MLAPI.World.Base;

namespace MLAPI.GameRegistry.Items
{
    /// <summary>
    /// A Item related utility class.
    /// </summary>
    public static class ItemUtil
    {
        /// <summary>
        /// Reserves the items at the specified locations with the provided ID.
        /// </summary>
        public static void ReserveItems(List<Point3D> locations, Guid reservingId)
        {
            Tile tile;
            foreach (Point3D item in locations)
            {
                tile = World.Data.World.GetTile(item.DimensionId, item.X, item.Y);

                Item tileItem = tile.MainObject as Item;
                tileItem.ReservedId = reservingId;
            }
        }
    }
}