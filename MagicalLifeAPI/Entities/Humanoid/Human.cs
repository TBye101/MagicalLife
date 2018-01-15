using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entities.Humanoid
{
    /// <summary>
    /// A class that holds logic for control of regular humans.
    /// </summary>
    public class Human : Living
    {
        public Human(int health, int movementSpeed) : base(health, movementSpeed)
        {
        }

        public override string GetTextureName()
        {
            return "Basic Human.png";
        }
    }
}
