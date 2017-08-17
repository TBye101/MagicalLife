namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Holds a list of flags that determine what abilities a creature has.
    /// </summary>
    public class CreatureAbilities
    {
        public int Backstab = 0;

        /// <summary>
        /// The creature's ability to back stab.
        /// </summary>
        public int BaseBackstab = 0;

        /// <summary>
        /// If true, the creature can suck the blood of another creature, and actually benefit from it.
        /// </summary>
        public bool BaseBloodSucking = false;

        /// <summary>
        /// If true, the creature can breath water.
        /// </summary>
        public bool BaseBreathWater = false;

        /// <summary>
        /// If true, the creature can become incorporeal.
        /// </summary>
        public bool BaseCanBecomeIncorporeal = false;

        /// <summary>
        /// If the creature has dark vision, it can see perfectly fine in the dark.
        /// </summary>
        public bool BaseDarkVision = false;

        /// <summary>
        /// If true, the creature can kill another creature with a look.
        /// </summary>
        public bool BaseDeathStare = false;

        /// <summary>
        /// The creature's ability to detect illusions.
        /// </summary>
        public int BaseDetectIllusions = 0;

        /// <summary>
        /// The creature's ability to detect traps.
        /// </summary>
        public int BaseDetectTraps = 0;

        /// <summary>
        /// The creature's ability to disarm traps.
        /// </summary>
        public int BaseDisarmTraps = 0;

        /// <summary>
        /// If true, the creature can fly.
        /// </summary>
        public bool BaseFly = false;

        /// <summary>
        /// How good the creature is at hiding in the shadows.
        /// </summary>
        public int BaseHideInShadows = 0;

        /// <summary>
        /// If true, the creature is immune to non magical weapons.
        /// </summary>
        public bool BaseImmunityToNonMagicWeapons = false;

        /// <summary>
        /// The creature's ability to pick a lock.
        /// </summary>
        public int BaseOpenLock = 0;

        /// <summary>
        /// The creature's ability to pick pockets successfully.
        /// If the creature makes a successful roll of this, they pick the pocket.
        /// They must make another roll to determine if their thievery was detected.
        /// </summary>
        public int BasePickPocket = 0;

        /// <summary>
        /// If true, the creature can shoot poison from their body.
        /// Ex: Spider.
        /// </summary>
        public bool BaseShootPoison = false;

        /// <summary>
        /// If true, the creature can shoot a web from their body.
        /// </summary>
        public bool BaseShootWeb = false;

        /// <summary>
        /// If true, the creature can turn another to stone with a look.
        /// Saving throw: Fear
        /// </summary>
        public bool BaseStoneStare = false;

        /// <summary>
        /// The maximum amount of stunning blows this monk could use.
        /// </summary>
        public int BaseStunningBlows = 0;

        /// <summary>
        /// If true, the creature can take a gaseous form.
        /// </summary>
        public bool BaseTakeGaseousForm = false;

        /// <summary>
        /// If true, the creature can communicate without speaking.
        /// </summary>
        public bool BaseTelepathy = false;

        /// <summary>
        /// How quite the creature walks. 0 is loud, 100 is quiet.
        /// </summary>
        public int BaseWalkSilently = 0;

        public bool BloodSucking = false;
        public bool BreathWater = false;
        public bool CanBecomeIncorporeal = false;
        public bool DarkVision = false;
        public bool DeathStare = false;
        public int DetectIllusions = 0;
        public int DetectTraps = 0;
        public int DisarmTraps = 0;
        public bool Fly = false;
        public int HideInShadows = 0;

        /// <summary>
        /// Is the creature immune to acid?
        /// </summary>
        public bool ImmunityToAcid = false;

        /// <summary>
        /// Is the creature immune to charms?
        /// </summary>
        public bool ImmunityToCharm = false;

        /// <summary>
        /// Is the creature immune to cold?
        /// </summary>
        public bool ImmunityToCold = false;

        /// <summary>
        /// Is the creature immune to electricity?
        /// </summary>
        public bool ImmunityToElectricity = false;

        /// <summary>
        /// Is the creature immune to fire?
        /// </summary>
        public bool ImmunityToFire = false;

        public bool ImmunityToNonMagicWeapons = false;

        /// <summary>
        /// Is the creature immune to poison?
        /// </summary>
        public bool ImmunityToPoison = false;

        /// <summary>
        /// Is the creature immune to sleep?
        /// </summary>
        public bool ImmunityToSleep = false;

        /// <summary>
        /// The creature's current ability to pick a lock.
        /// </summary>
        public int OpenLock = 0;

        public int PickPocket = 0;
        public bool ShootPoison = false;
        public bool ShootWeb = false;
        public bool StoneStare = false;

        /// <summary>
        /// The amount of stunning blows this monk has left.
        /// </summary>
        public int StunningBlows = 0;

        public bool TakeGaseousForm = false;
        public bool Telepathy = false;
        public int WalkSilently = 0;

        public void Rest()
        {
            this.DarkVision = this.BaseDarkVision;
            this.BreathWater = this.BaseBreathWater;
            this.DeathStare = this.BaseDeathStare;
            this.StoneStare = this.BaseStoneStare;
            this.BloodSucking = this.BaseBloodSucking;
            this.ImmunityToNonMagicWeapons = this.BaseImmunityToNonMagicWeapons;
            this.ShootWeb = this.BaseShootWeb;
            this.ShootPoison = this.BaseShootPoison;
            this.Fly = this.BaseFly;
            this.TakeGaseousForm = this.BaseTakeGaseousForm;
            this.CanBecomeIncorporeal = this.BaseCanBecomeIncorporeal;
            this.Telepathy = this.BaseTelepathy;
            this.HideInShadows = this.BaseHideInShadows;
            this.WalkSilently = this.BaseWalkSilently;
            this.PickPocket = this.BasePickPocket;
            this.DetectTraps = this.BaseDetectTraps;
            this.DisarmTraps = this.BaseDisarmTraps;
            this.DetectIllusions = this.BaseDetectIllusions;
            this.Backstab = this.BaseBackstab;
            this.StunningBlows = this.BaseStunningBlows;
        }
    }
}