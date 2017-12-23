namespace EarthMagicCharacters.Rules.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API.Interfaces.Items;

    /// <summary>
    /// Used to determine if a monk can do something, or not do something.
    /// </summary>
    public class MonkRules : ICreatureRules
    {
        public bool canEquip(IItem item)
        {
            
        }

        public bool canUse(IItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines if this monk can use the specified weapon.
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public bool canUseWeapon(IWeapon weapon)
        {

        }
    }
}
