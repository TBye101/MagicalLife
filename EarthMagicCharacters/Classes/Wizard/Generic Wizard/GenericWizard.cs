namespace EarthMagicCharacters.Classes.Wizard.Generic_Wizard
{
    using System;
    using EarthWithMagicAPI.API.Creature;
    using EarthWithMagicAPI.API.Interfaces.Items;
    using EarthWithMagicAPI.API.Stuff;

    /// <summary>
    /// The base wizard class.
    /// </summary>
    public class GenericWizard : ICreature
    {
        public GenericWizard(CreatureAttributes attributes, CreatureAbilities abilities, string documentationPath, string imagePath)
            : base(attributes, abilities, documentationPath, imagePath)
        {
        }

        public override void EquipItem(IItem item)
        {
            throw new NotImplementedException();
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

        public override void YourTurn(Encounter encounter)
        {
            throw new NotImplementedException();
        }
    }
}