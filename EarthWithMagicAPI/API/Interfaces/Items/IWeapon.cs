using EarthWithMagicAPI.API.Util;
using EarthWithMagicAPI.API.Creature;
using System.Security.Cryptography.X509Certificates;
namespace EarthWithMagicAPI.API.Interfaces.Items
{
    /// <summary>
    /// The interface of all weapons.
    /// </summary>
    public abstract class IWeapon : IItem
    {
        /// <summary>
        /// Called when this weapon is thrown.
        /// </summary>
        public abstract void OnThrow();

        /// <summary>
        /// Called whenever this weapon is attacked with.
        /// </summary>
        public abstract void OnAttack();

        /// <summary>
        /// Called when attacking another creature.
        /// </summary>
        /// <returns></returns>
        public void Attack(ICreature creature)
        {
            int D = Dice.RollDice(this.Damage.AcidDamage, "Acid damage");

            if (D > 0)
            {
                Util.Util.WriteLine(this.Owner + " dealt " + D.ToString() + " acid damage.");
            }

            D = Dice.RollDice(this.Damage.BluntDamage, "Blunt damage");

            if (D > 0)
            {
                Util.Util.WriteLine(this.Owner + " dealt " + D.ToString() + " blunt damage.");
            }

            D = Dice.RollDice(this.Damage.ColdDamage, "Cold damage");

            if (D > 0)
            {
                Util.Util.WriteLine(this.Owner + " dealt " + D.ToString() + " cold damage.");
            }

            D = Dice.RollDice(this.Damage.ElectricDamage, "Electric damage");

            if (D > 0)
            {
                Util.Util.WriteLine(this.Owner + " dealt " + D.ToString() + " electric damage.");
            }

            D = Dice.RollDice(this.Damage.FireDamage, "Fire damage");

            if (D > 0)
            {
                Util.Util.WriteLine(this.Owner + " dealt " + D.ToString() + " fire damage.");
            }

            D = Dice.RollDice(this.Damage.MagicDamage, "Magic damage");

            if (D > 0)
            {
                Util.Util.WriteLine(this.Owner + " dealt " + D.ToString() + " magic damage.");
            }

            D = Dice.RollDice(this.Damage.PiercingDamage, "Piercing damage");

            if (D > 0)
            {
                Util.Util.WriteLine(this.Owner + " dealt " + D.ToString() + " piercing damage.");
            }

            D = Dice.RollDice(this.Damage.PoisonDamage, "Poison damage");

            if (D > 0)
            {
                Util.Util.WriteLine(this.Owner + " dealt " + D.ToString() + " poison damage.");
            }

            D = Dice.RollDice(this.Damage.SlashingDamage, "Slashing damage");

            if (D > 0)
            {
                Util.Util.WriteLine(this.Owner + " dealt " + D.ToString() + " slashing damage.");
            }

            creature.RecieveDamage(this.Damage);
        }
    }
}