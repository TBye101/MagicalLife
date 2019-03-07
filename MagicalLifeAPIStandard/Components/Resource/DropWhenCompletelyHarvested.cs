using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.Components.Resource
{
    [ProtoContract]
    public class DropWhenCompletelyHarvested : AbstractHarvestable
    {
        [ProtoMember(1)]
        protected List<Item> Items { get; set; }

        /// <summary>
        /// The sound that plays whenever harvesting happens.
        /// </summary>
        [ProtoMember(2)]
        protected string HarvestSound { get; set; }

        /// <summary>
        /// The sound played when the object is completely harvested.
        /// </summary>
        [ProtoMember(3)]
        protected string CompletionSound { get; set; }

        /// <param name="items">The items to drop when harvested.</param>
        /// <param name="harvestSound">The sound to play each harvest tick. Can be empty to play no sound.</param>
        /// <param name="completionSound">The sound to play when completely harvested/done. Can be empty to play no sound.</param>
        public DropWhenCompletelyHarvested(List<Item> items, string harvestSound, string completionSound)
        {
            this.Items = items;
            this.HarvestSound = harvestSound;
            this.CompletionSound = completionSound;
        }

        protected DropWhenCompletelyHarvested()
        {
        }

        public override List<Item> Harvested(Point2D position)
        {
            if (this.CompletionSound != string.Empty)
            {
                Point2D screenPosition = new Point2D(position.X * Tile.GetTileSize().X, position.Y * Tile.GetTileSize().Y);
                FMODUtil.RaiseEvent(this.CompletionSound, "", 0, screenPosition);
            }
            return this.Items;
        }

        protected override List<Item> HarvestPercent(double percentMined, Point2D position)
        {
            if (this.HarvestSound != string.Empty)
            {
                Point2D screenPosition = new Point2D(position.X * Tile.GetTileSize().X, position.Y * Tile.GetTileSize().Y);
                FMODUtil.RaiseEvent(this.HarvestSound, "", 0, screenPosition);
            }
            return null;
        }
    }
}