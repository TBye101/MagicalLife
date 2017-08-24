// <copyright file="LesserAngel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicCreatures.Creatures.Heavenly.Angels
{
    using System;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Stuff;
    using EarthWithMagicAPI.API.Util;

    public class LesserAngel : ICreature
    {
        public LesserAngel() : base(GetBaseAttributes(), new CreatureAbilities(), "EarthMagicDocumentation.Creatures.Heavenly.LesserAngel.md", "EarthMagicDocumentation.ASCII_Art.Creatures.Heavenly.Angels.LesserAngel.txt", null)
        {
        }

        public override void EquipItem(IItem item)
        {
        }

        public override bool IsHostile()
        {
            throw new NotImplementedException();
        }

        public override void OnCreatureDied(ICreature dead)
        {
            throw new NotImplementedException();
        }

        public override void OnCreatureHealed(ICreature healer)
        {
            throw new NotImplementedException();
        }

        public override void OnDealDamage()
        {
            throw new NotImplementedException();
        }

        public override void OnItemUnequipped(IItem item)
        {
            throw new NotImplementedException();
        }

        private static CreatureAttributes GetBaseAttributes()
        {
            int hP = Dice.RollDice(new Die(50, 12, 3), "Lesser Angel hit points");
            CreatureAttributes baseAtt = new CreatureAttributes(Gender.Female, Alignment.LawfulGood, Race.Unspecified, .75, hP, hP, 20,
                22, 19, 15, 23, 1, 0, .5, 0, -.2, .4, .75, .25, true, 45, 0, .5, 16);
            return baseAtt;
        }
    }
}