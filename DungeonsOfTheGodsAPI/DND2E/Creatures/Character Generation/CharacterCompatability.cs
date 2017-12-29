using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsOfTheGodsAPI.DND2E.Creatures.Character_Generation
{
    /// <summary>
    /// Used to determine availible options
    /// </summary>
    public class CharacterCompatability
    {
           
    }

    /// <summary>
    /// The names of all classes playable by characters in D & D.
    /// </summary>
    public enum ClassName
    {
        Cleric, Druid, Fighter, Paladin, Ranger, Thief, Assasin, Wizard, Illusionist, Monk, None
    }

    /// <summary>
    /// The names of all races playable by characters in D & D.
    /// </summary>
    public enum RaceName
    {// 
        Dwarven, Elven, Gnome, HalfElven, Hafling, HalfOrc, Human
    }

    /// <summary>
    /// The gender names.
    /// </summary>
    public enum Gender
    {
        Male, Female
    }

    /// <summary>
    /// Used to hold an option that is possible from a ability score.
    /// </summary>
    public struct CharacterOption
    {
        public readonly RaceName race;
        public readonly ClassName nameOfClass;
        public readonly ClassName nameOfSecondaryClass;
        public readonly Gender gender;

        public CharacterOption(RaceName race, ClassName nameOfClass, ClassName nameOfSecondaryClass, Gender gender)
        {
            this.race = race;
            this.nameOfClass = nameOfClass;
            this.nameOfSecondaryClass = nameOfSecondaryClass;
            this.gender = gender;
        }
    }
}
