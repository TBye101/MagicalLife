namespace EarthWithMagicAPI.API.Interfaces.Items
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;

    public abstract class IRangedWeapon : IWeapon
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IRangedWeapon"/> class.
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="imagePath"></param>
        /// <param name="documentationPath"></param>
        /// <param name="range">The number of creatures that it can hit in the enemy party with a value of 1 being able to hit the 1st enemy, and 10 being able to hit the 10th enemy.</param>
        protected IRangedWeapon(Damage damage, string name, double weight, string imagePath, string documentationPath, int range, IAmmo ammo) : base(damage, name, weight, imagePath, documentationPath)
        {
            this.Range = range;
            this.Ammo = ammo;
        }

        public int Range { get; set; }

        /// <summary>
        /// Gets or sets the projectile that is shot by this ranged weapon.
        /// </summary>
        public IAmmo Ammo { get; set; }
    }
}
