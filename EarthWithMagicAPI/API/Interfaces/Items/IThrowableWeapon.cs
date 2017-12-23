namespace EarthWithMagicAPI.API.Interfaces.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// Used by weapons that are throwable, such as shrukens or darts.
    /// </summary>
    public abstract class IThrowableWeapon : IItem
    {
        protected IThrowableWeapon(string name, double weight, string imagePath, string documentationPath, Die uses, int chanceToHit, Damage attackDamage)
            : base(name, weight, imagePath, documentationPath)
        {
            this.Uses = uses;
            this.ChanceToHit = chanceToHit;
            this.AttackDamage = attackDamage;
        }

        public Die Uses { get; set; }

        public int ChanceToHit { get; set; }

        public Damage AttackDamage { get; set; }
    }
}
