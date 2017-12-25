using EarthMagicCharacters.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// This class is used to determine who can THEORETICALLY use the item. In all reality, the character might already have another item on that conflicts with the item this is describing.
    /// </summary>
    public class UsabilityDescription
    {
        public bool CanAlchemist { get; set; } = false;
        public bool CanBard { get; set; } = false;
        public bool CanCleric { get; set; } = false;
        public bool CanNecromancer { get; set; } = false;
        public bool CanColdDruid { get; set; } = false;
        public bool CanElectricDruid { get; set; } = false;
        public bool CanFireDruid { get; set; } = false;
        public bool CanWaterDruid { get; set; } = false;
        public bool CanBarbarian { get; set; } = false;
        public bool CanDuelist { get; set; } = false;
        public bool CanDwarvenDefender { get; set; } = false;
        public bool CanFighter { get; set; } = false;
        public bool CanKnight { get; set; } = false;
        public bool CanPaladin { get; set; } = false;
        public bool CanSamurai { get; set; } = false;
        public bool CanMonk { get; set; } = false;
        public bool CanRanger { get; set; } = false;
        public bool CanMarksman { get; set; } = false;
        public bool CanShapeShifter { get; set; } = false;
        public bool CanThief { get; set; } = false;
        public bool CanGymnist { get; set; } = false;
        public bool CanShadewalker { get; set; } = false;
        public bool CanDragonborn { get; set; } = false;
        public bool CanWizard { get; set; } = false;
        public bool CanPlaneswalker { get; set; } = false;
    }
}
