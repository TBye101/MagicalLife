using EarthMagicItems;
using System;
using System.Collections.Generic;

namespace DungeonsAndFantasyLands.API.Items
{
    public interface IItem
    {
        /// <summary>
        /// Returns if the item is a quest item.
        /// </summary>
        bool QuestItem { get; set; }

        /// <summary>
        /// The base value of the item, that if the player has 100% trading skills, they will get.
        /// </summary>
        int Value { get; }

        /// <summary>
        /// The level of the item. Used to determine what loot table to put it on.
        /// </summary>
        int Level { get; }

        /// <summary>
        /// The ID of the item.
        /// </summary>
        Guid ID { get; }

        /// <summary>
        /// The human readable name of the item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The flavor text/lore of the item.
        /// </summary>
        List<string> Lore { get; }

        /// <summary>
        /// Any other information the item might display.
        /// </summary>
        List<string> OtherInformation { get; }
    }
}