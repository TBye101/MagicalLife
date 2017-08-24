// <copyright file="ISpellbook.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthMagicItems.Books
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// Shared logic for all spellbooks.
    /// </summary>
    public abstract class ISpellbook : IItem
    {
        private int memorizationProgress = 0;

        /// <summary>
        /// A list of spells in the spellbook.
        /// </summary>
        public List<ISpell> Spells = new List<ISpell>();

        public ISpellbook(string name, double weight, string imagePath, string documentationPath)
            : base(name, weight, imagePath, documentationPath)
        {
        }

        public override void Use(ICreature user)
        {
            this.RemoveKnown(user);

            if (this.Spells.Count > 0)
            {
                int progress = Dice.RollDice(new Die(1, user.Attributes.XP.CreatureLevel, 1), "Memorization progress towards " + Spells[0].Name);
                this.memorizationProgress += progress;

                if (this.memorizationProgress >= this.Spells[0].MemorizationDifficulty)
                {
                    this.memorizationProgress = 0;
                    Util.WriteLine(user.Name + " has memorized " + this.Spells[0].Name);
                    user.SpellsKnown.Add(this.Spells[0]);
                    this.Spells.RemoveAt(0);

                    if (this.Spells.Count < 1)
                    {
                        this.Name = "Ashes of " + this.Name;
                    }
                }
            }
            else
            {
                Util.WriteLine("You can't use learn anything more from this!");
            }
        }

        /// <summary>
        /// Removes all known spells in the book.
        /// </summary>
        /// <param name="user"></param>
        private void RemoveKnown(ICreature user)
        {
            int length = this.Spells.Count;

            for (int i = 0; i < length; i++)
            {
                ISpell item = this.Spells[i];

                foreach (ISpell ob in user.SpellsKnown)
                {
                    if (item == ob)
                    {
                        this.Spells.RemoveAt(i);
                        i--;
                        length--;
                    }
                }
            }
        }
    }
}
