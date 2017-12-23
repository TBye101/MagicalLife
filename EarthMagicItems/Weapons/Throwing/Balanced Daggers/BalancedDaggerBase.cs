namespace EarthMagicItems.Weapons.Throwing.Balanced_Daggers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API.Interfaces.Items;

    public abstract class BalancedDaggerBase : IThrowableWeapon
    {
        protected BalancedDaggerBase(string name, double weight, string imagePath, string documentationPath, EarthWithMagicAPI.API.Util.Die uses, int chanceToHit, EarthWithMagicAPI.API.Damage attackDamage) : base(name, weight, imagePath, documentationPath, uses, chanceToHit, attackDamage)
        {
        }
    }
}
