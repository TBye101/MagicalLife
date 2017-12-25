using EarthWithMagicAPI.API.Interfaces.Items;
// <copyright file="ICharacter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicCharacters.Classes
{
    using EarthWithMagicAPI.API.Controls;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Stuff;

    public abstract class ICharacter : ICreature
    {
        protected ICharacter(CreatureAttributes attributes, CreatureAbilities abilities, string documentationPath, string imagePath, IAI aI)
            : base(attributes, abilities, documentationPath, imagePath, aI)
        {
        }

        /// <summary>
        /// Called whenever it is time to level up this creature.
        /// The player should control the level up.
        /// </summary>
        public abstract void LevelUp();

        /// <summary>
        /// Determines if we can use or equip the item.
        /// </summary>
        /// <returns></returns>
        public abstract bool CanUse(IItem item);

        public override void YourTurn(Encounter encounter)
        {
            this.YourTurn(encounter);
        }

        public override bool YourTurn()
        {
            if (this.IsInParty)
            {
                return NonCombatControl.YourTurn(this);
            }
            return true;
        }
    }
}