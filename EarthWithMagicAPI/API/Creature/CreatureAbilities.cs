using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Holds a list of flags that determine what abilities a creature has.
    /// </summary>
    public class CreatureAbilities
    {
        /// <summary>
        /// If the creature has dark vision, it can see perfectly fine in the dark.
        /// </summary>
        public bool DarkVision = false;

        /// <summary>
        /// If true, the creature can breath water.
        /// </summary>
        public bool BreathWater = false;

        /// <summary>
        /// If true, the creature can kill another creature with a look.
        /// </summary>
        public bool DeathStare = false;

        /// <summary>
        /// If true, the creature can turn another to stone with a look.
        /// Saving throw: Fear
        /// </summary>
        public bool StoneStare = false;

        /// <summary>
        /// If true, the creature can suck the blood of another creature, and actually benefit from it.
        /// </summary>
        public bool BloodSucking = false;

        /// <summary>
        /// If true, the creature is immune to non magical weapons.
        /// </summary>
        public bool ImmunityToNonMagicWeapons = false;

        /// <summary>
        /// If true, the creature can shoot a web from their body.
        /// </summary>
        public bool ShootWeb = false;

        /// <summary>
        /// If true, the creature can shoot poison from their body.
        /// Ex: Spider.
        /// </summary>
        public bool ShootPoison = false;

        /// <summary>
        /// If true, the creature can fly.
        /// </summary>
        public bool Fly = false;

        /// <summary>
        /// If true, the creature can take a gaseous form.
        /// </summary>
        public bool TakeGaseousForm = false;

        /// <summary>
        /// If true, the creature can become incorporeal.
        /// </summary>
        public bool CanBecomeIncorporeal = false;

        /// <summary>
        /// If true, the creature can communicate without speaking.
        /// </summary>
        public bool Telepathy = false;
    }
}
