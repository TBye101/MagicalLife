using MagicalLifeAPI.GUI;
using Microsoft.Xna.Framework;
using ProtoBuf;

namespace MagicalLifeAPI.Entities.Humanoid
{
    /// <summary>
    /// A class that holds logic for control of regular humans.
    /// </summary>
    [ProtoContract]
    public class Human : Living
    {
        public Human(int health, int movementSpeed, Point location) : base(health, movementSpeed, location)
        {
            Filing.Logging.MasterLog.DebugWriteLine("Living spawned at: " + location.ToString());
        }

        public Human() : base()
        {
        }

        public override string GetTextureName()
        {
            return "Basic Human";
        }

        public override SelectionType InGameObjectType(Selectable selectable)
        {
            return SelectionType.Creature;
        }
    }
}