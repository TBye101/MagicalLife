namespace EarthMagicItems.Ammo.Stones
{
    using System.Collections.Generic;
    using EarthMagicItems.Ammo.Arrows;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// Storage for generic stones.
    /// </summary>
    public class GenericStoneStorage
    {
        #region NormalStones

        private GenericAmmo _1Stone = new GenericAmmo(new Die(2, 4, 0), "+1 Stone", GenericStoneStorage.StandardStone(new Die(1, 4, 1)), 
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Stone.txt", 
            "EarthMagicDocumentation.Items.Ammo.Stones.+1Stone.md", .1);

        private GenericAmmo _2Stone = new GenericAmmo(new Die(3, 5, 0), "+2 Stone", GenericStoneStorage.StandardStone(new Die(1, 4, 2)),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Stone.txt",
            "EarthMagicDocumentation.Items.Ammo.Stones.+2Stone.md", .1);

        private GenericAmmo _3Stone = new GenericAmmo(new Die(4, 6, 0), "+3 Stone", GenericStoneStorage.StandardStone(new Die(1, 4, 3)),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Stone.txt",
            "EarthMagicDocumentation.Items.Ammo.Stones.+3Stone.md", .1);

        private GenericAmmo _4Stone = new GenericAmmo(new Die(5, 7, 0), "+4 Stone", GenericStoneStorage.StandardStone(new Die(1, 4, 4)),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Stone.txt",
            "EarthMagicDocumentation.Items.Ammo.Stones.+4Stone.md", .1);

        private GenericAmmo _5Stone = new GenericAmmo(new Die(6, 7, 0), "+5 Stone", GenericStoneStorage.StandardStone(new Die(1, 4, 5)),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Stone.txt",
            "EarthMagicDocumentation.Items.Ammo.Stones.+5Stone.md", .1);

        private GenericAmmo Stone = new GenericAmmo(new Die(1, 2, 0), "Stone", GenericStoneStorage.StandardStone(new Die(1, 4, 0)),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Stone.txt",
            "EarthMagicDocumentation.Items.Ammo.Stones.Stone.md", .15);

        #endregion NormalStones

        private GenericAmmo AcidStone = new GenericAmmo(new Die(1, 3, 0), "Acid Stone",
            new Damage(new Die(1, 8, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 4, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Stone.txt",
            "EarthMagicDocumentation.Items.Ammo.Stones.AcidStone.md", .13);

        private GenericAmmo FireStone = new GenericAmmo(new Die(1, 3, 0), "Fire Stone",
            new Damage(Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), new Die(1, 4, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Stone.txt",
            "EarthMagicDocumentation.Items.Ammo.Stones.FireStone.md", .2);

        private GenericAmmo FrostStone = new GenericAmmo(new Die(1, 3, 0), "Frost Stone",
            new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), new Die(1, 4, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Stone.txt",
            "EarthMagicDocumentation.Items.Ammo.Stones.FrostStone.md", .14);

        private GenericAmmo PoisonStone = new GenericAmmo(new Die(1, 3, 0), "Poison Stone",
            new Damage(Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 4, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Stone.txt",
            "EarthMagicDocumentation.Items.Ammo.Stones.PoisonStone.md", .11);

        /// <summary>
        /// Creates a damage object for a arrow that only does normal piercing damage.
        /// </summary>
        /// <param name="piercingDamage"></param>
        /// <param name="bluntDamage"></param>
        /// <returns></returns>
        private static Damage StandardStone(Die bluntDamage)
        {
            return new Damage(Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), bluntDamage);
        }
    }
}