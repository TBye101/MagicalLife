namespace EarthMagicItems.Weapons.Throwing.Throwing_Axes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API.Interfaces.Items;

    public abstract class ThrowingAxeBase : IThrowableWeapon
    {
        protected ThrowingAxeBase(string name, double weight, string imagePath, string documentationPath, EarthWithMagicAPI.API.Util.Die uses, int chanceToHit, EarthWithMagicAPI.API.Damage attackDamage) : base(name, weight, imagePath, documentationPath, uses, chanceToHit, attackDamage)
        {
        }
    }
}
