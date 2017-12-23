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
        public bool CanUse(IItem item)
        {
            throw new NotImplementedException();
        }

        public bool CanUse(IAmmo ammo)
        {
            return false;
        }

        public bool CanUse(IAmulet amulet)
        {
            return true;
        }

        public bool CanUse(IArmor armor)
        {
            throw new NotImplementedException();
        }

        public bool CanUse(IRangedWeapon rangedWeapon)
        {
            return false;
        }

        public bool CanUse(IRing ring)
        {
            return true;
        }

        public bool CanUse(IThrowableWeapon weapon)
        {
            //Type weaponType = weapon.GetType();
            //weaponType.IsAssignableFrom(DartBase)
            return false;
        }

        public bool CanUse(IWand wand)
        {
            // Monks cannot use wands
            return false;
        }

        public bool CanUse(IWeapon weapon)
        {
            return false;
        }
    }
}
