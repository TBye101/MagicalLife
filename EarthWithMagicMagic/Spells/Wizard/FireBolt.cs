namespace EarthWithMagicMagic.Spells.Wizard
{
    using System.Collections.Generic;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Util;

    public class Fire_Bolt : ISpell
    {
        public Fire_Bolt() : base("Firebolt", "EarthMagicDocumentation.Spells.Wizard.Firebolt.md", 9, 0, "EarthMagicDocumentation.ASCII_Art.Spells.Wizard.Firebolt.txt")
        {
        }

        protected override bool Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster)
        {
            Damage damage = new Damage(Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 10, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero());

            int Missiles = 4;

            while (Missiles != 0)
            {
                Missiles--;

                if (Caster.IsHostile())
                {
                    Party[0].RecieveDamage(damage);
                }
                else
                {
                    Enemies[0].RecieveDamage(damage);
                }
            }

            return true;
        }

        public override bool OnAction(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            return true;
        }

        public override bool OnTurn(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
            return true;
        }

        public override void OnWearOff(List<ICreature> Party, List<ICreature> Enemies, ICreature Affected)
        {
        }
    }
}