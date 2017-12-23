namespace EarthMagicCharacters.Rules.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API.Interfaces.Items;

    /// <summary>
    /// All classes that implement this are used to determine if a creature can do something.
    /// </summary>
    public interface ICreatureRules
    {
        bool CanUse(IItem item);
        bool CanUse(IWeapon weapon);
        bool CanUse(IThrowableWeapon weapon);
        bool CanUse(IAmmo ammo);
        bool CanUse(IAmulet amulet);
        bool CanUse(IRing ring);
        bool CanUse(IWand wand);
        bool CanUse(IRangedWeapon rangedWeapon);
        bool CanUse(IArmor armor);
    }
}
