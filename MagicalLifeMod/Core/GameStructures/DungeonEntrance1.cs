using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeMod.Core.GameStructures
{
    public class DungeonEntrance1 : Structure
    {
        public DungeonEntrance1(Guid ownerID, List<Point2D> parts, Guid structureID) 
            : base(CoreLang.DungeonEntranceName, ownerID, parts, structureID)
        {
        }

        protected DungeonEntrance1()
        {
            //Protobuf-net constructor.
        }
    }
}
