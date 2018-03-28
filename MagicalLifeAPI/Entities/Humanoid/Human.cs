using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.GUI;

namespace MagicalLifeAPI.Entities.Humanoid
{
    /// <summary>
    /// A class that holds logic for control of regular humans.
    /// </summary>
    public class Human : Living
    {
        public Human(int health, int movementSpeed, Point3D location) : base(health, movementSpeed, location)
        {
        }

        public override string GetTextureName()
        {
            return "Basic Human";
        }

        public override SelectionType InGameObjectType(ISelectable selectable)
        {
            return SelectionType.Creature;
        }
    }
}