// <copyright file="LesserAngel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicCreatures.Creatures.Heavenly.Angels
{
    using System;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Util;

    public class LesserAngel : ICreature
    {
        public LesserAngel()
            : base(GetBaseAttributes(), new CreatureAbilities(), "EarthMagicDocumentation.Creatures.Heavenly.LesserAngel.md", "EarthMagicDocumentation.ASCII_Art.Creatures.Heavenly.Angels.LesserAngel.txt", null)
        {
        }

        public override bool IsHostile()
        {
            return !this.IsInParty;
        }

        public override void OnCreatureDied(ICreature dead)
        {
        }

        public override void OnCreatureHealed(ICreature healer)
        {
            Filing.Writeline("You hear a eerie otherworldly whisper that seems to come from everywhere and nowhere: Thank you");
        }

        public override void OnDealDamage()
        {
        }

        public override void OnItemUnequipped(IItem item)
        {
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