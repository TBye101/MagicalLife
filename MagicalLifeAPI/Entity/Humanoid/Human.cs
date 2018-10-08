using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.GUI;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.Entity.Humanoid
{
    /// <summary>
    /// A class that holds logic for control of regular humans.
    /// </summary>
    [ProtoContract]
    public class Human : Living
    {
        public Human(int health, float movementSpeed, Point2D location, int dimension, Guid playerID) : base(health, movementSpeed, location, dimension, playerID)
        {
            Filing.Logging.MasterLog.DebugWriteLine("Living spawned at: " + location.ToString());
        }

        public Human() : base()
        {
        }

        public override string GetTextureName()
        {
            return "Character/Character";
        }

        public override SelectionType InGameObjectType(Selectable selectable)
        {
            return SelectionType.Creature;
        }
    }
}