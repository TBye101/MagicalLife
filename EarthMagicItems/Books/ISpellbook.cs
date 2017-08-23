using EarthWithMagicAPI.API.Util;
namespace EarthMagicItems.Books
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Interfaces.Spells;

    /// <summary>
    /// Shared logic for all spellbooks.
    /// </summary>
    public abstract class ISpellbook : IItem
    {
        private int memorizationProgress = 0;

        /// <summary>
        /// A list of spells in the spellbook.
        /// </summary>
        private List<ISpell> Spells = new List<ISpell>();

        public ISpellbook(string name, double weight, string imagePath, string documentationPath)
            : base(name, weight, imagePath, documentationPath)
        {
        }

        public override void Use(ICreature user)
        {
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
    }
}
