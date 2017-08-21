using EarthWithMagicAPI.API.Util;
using System.Linq;
namespace EarthMagicCharacters.Classes.Wizard.Generic_Wizard
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Stuff;

    public class WizardAI : IAI
    {
        public void YourTurn(Encounter encounter, ICreature creature)
        {
            creature.UsableSpells[Dice.RollDice(new Die(1, creature.UsableSpells.Count + 1, -1), creature.Name + " is casting a random spell!")].Cast(encounter.Party, encounter.Enemies, creature);
        }
    }
}
