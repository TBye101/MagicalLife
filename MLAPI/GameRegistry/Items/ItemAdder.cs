using System;
using System.Collections.Generic;
using MLAPI.Components;
using MLAPI.DataTypes;
using MLAPI.DataTypes.Collection;
using MLAPI.Error.InternalExceptions;
using MLAPI.Networking.Client;
using MLAPI.Networking.Messages;
using MLAPI.Networking.Server;
using MLAPI.Networking.World.Modifiers;
using MLAPI.World;
using MLAPI.World.Base;
using MLAPI.World.Data;
using Dimension = MLAPI.World.Data.Dimension;

namespace MLAPI.GameRegistry.Items
{
    /// <summary>
    /// Used to add items to the world, via the <see cref="ItemRegistry"/>.
    /// </summary>
    public static class ItemAdder
    {
        /// <summary>
        /// Lets a chunk know that there is an item of the specified type in the specified tile position.
        /// </summary>
        private static void RememberWhichTile(Item item, Point2D mapLocation, Chunk chunk)
        {
            if (!chunk.Items.ContainsKey(item.ItemId))
            {
                //chunk.Items doesn't store one key and value for every item in the game upfront.
                chunk.Items.Add(item.ItemId, new RTree<Point2D>());
            }

            RTree<Point2D> itemLocations = chunk.Items[item.ItemId];
            List<Point2D> result = itemLocations.Contains(new Rectangle(mapLocation.X, mapLocation.Y, mapLocation.X, mapLocation.Y));

            if (result.Count > 0)
            {
                //The chunk already knows that there is an item of the specified type in the specified position.
            }
            else
            {
                Rectangle r = new Rectangle(mapLocation.X, mapLocation.Y, mapLocation.X, mapLocation.Y);
                Tile tile = WorldUtil.GetTile(mapLocation, chunk);
                ComponentSelectable selectable = tile.GetExactComponent<ComponentSelectable>();

                itemLocations.Add(r, selectable.MapLocation);
            }
        }

        /// <summary>
        /// Internally stores that a certain chunk has at least one item of the specified item ID.
        /// </summary>
        /// <param name="chunkLocation"></param>
        /// <param name="itemId"></param>
        private static void RememberWhichChunk(Point3D chunkLocation, int itemId)
        {
            Dimension dimension = World.Data.World.DefaultWorldProvider.GetDimension(chunkLocation.DimensionId);
            RTree<Point2D> chunkLocations = dimension.Items.ItemIdToChunk[itemId];
            List<Point2D> result = chunkLocations.Contains(new Rectangle(chunkLocation.X, chunkLocation.Y, chunkLocation.X, chunkLocation.Y));
            if (result.Count > 0)
            {
                //We already know that the specified chunk contains at least one of the item type.
                return;
            }
            else
            {
                chunkLocations.Add(new Rectangle(chunkLocation.X, chunkLocation.Y, chunkLocation.X, chunkLocation.Y), chunkLocation);
            }
        }

        /// <summary>
        /// Adds an item to the specified map location.
        /// </summary>
        public static void AddItem(Item item, Point2D mapLocation, Guid dimensionId)
        {
            if (World.Data.World.Mode != Networking.EngineMode.ServerOnly)
            {
                NetworkAdd(item, mapLocation, dimensionId);
            }

            Point3D chunkLocation = Point3D.From2D(WorldUtil.CalculateChunkLocation(mapLocation), dimensionId);
            Chunk chunk = World.Data.World.DefaultWorldProvider.GetChunk(chunkLocation);

            ItemAdder.RememberWhichChunk(chunkLocation, item.ItemId);
            ItemAdder.RememberWhichTile(item, mapLocation, chunk);
            ItemAdder.StoreItem(chunk, mapLocation, item);
        }

        /// <summary>
        /// Handles sending out sync messages to keep the other clients and the server appraised of the added item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="mapLocation"></param>
        /// <param name="dimension"></param>
        private static void NetworkAdd(Item item, Point2D mapLocation, Guid dimensionId)
        {
            switch (World.Data.World.Mode)
            {
                case Networking.EngineMode.ServerOnly:
                    ServerSendRecieve.SendAll(new WorldModifierMessage(new ItemCreatedModifier(item, mapLocation, dimensionId)));
                    break;

                case Networking.EngineMode.ClientOnly:
                    ClientSendRecieve.Send(new WorldModifierMessage(new ItemCreatedModifier(item, mapLocation, dimensionId)));
                    break;

                case Networking.EngineMode.ServerAndClient:
                    break;

                default:
                    throw new InvalidOperationException("Unexpected Mode for the World: " + World.Data.World.Mode.ToString());
            }
        }

        /// <summary>
        /// Adds an item during the ongoing world generation.
        /// </summary>
        public static void AddItemWorldGen(Item item, Point3D mapLocation, ProtoArray<Chunk> map)
        {
            Point3D chunkLocation = Point3D.From2D(WorldUtil.CalculateChunkLocation(mapLocation), mapLocation.DimensionId);
            Chunk chunk = map[chunkLocation.X, chunkLocation.Y];

            ItemAdder.RememberWhichChunk(chunkLocation, item.ItemId);
            ItemAdder.RememberWhichTile(item, mapLocation, chunk);
            ItemAdder.StoreItem(chunk, mapLocation, item);
        }

        /// <summary>
        /// Stores an item in the specified tile.
        /// If the tile is already full or cannot accept all of the item(s) being added,
        /// then this method returns any excess.
        /// Otherwise, this method returns null.
        /// </summary>
        internal static Item StoreItem(Chunk chunk, Point2D mapLocation, Item item)
        {
            Tile tile = WorldUtil.GetTile(mapLocation, chunk);
            Item overflow = null;

            if (tile.MainObject == null)
            {
                tile.MainObject = item;
            }
            else
            {
                Item existing = tile.MainObject as Item;
                if (existing == null)
                {
                    throw new UnexpectedStateException("Invalid addition of an item to a tile with an object of another type occuping the main object slot.");
                }
                tile.MainObject = Item.Combine(existing, item, out overflow);
            }

            return overflow;
        }
    }
}