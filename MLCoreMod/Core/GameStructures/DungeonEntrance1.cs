using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.World.Base;
using MLCoreMod;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeMod.Core.GameStructures
{
    public class DungeonEntrance1 : Structure
    {
        private static readonly Guid StructureID = Guid.Parse("54FC7274-0DFA-4D5E-B8A6-52635A69E6EC");

        public DungeonEntrance1(List<Point3D> parts)
            : base(CoreLang.DungeonEntranceName, Guid.Empty, parts, StructureID)
        {
        }

        protected DungeonEntrance1()
        {
            //Protobuf-net constructor.
        }
    }
}