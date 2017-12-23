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
        bool canEquip(IItem item);
        bool canUse(IItem item);
    }
}
