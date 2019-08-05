using System;
using System.Collections.Generic;
using MLAPI.DataTypes;
using MLAPI.World.Structure;

namespace MLCoreMod.Core.GameStructures
{
    public class DungeonEntrance1 : Structure
    {
        private static readonly Guid StructureId = Guid.Parse("54FC7274-0DFA-4D5E-B8A6-52635A69E6EC");

        public DungeonEntrance1(List<Point3D> parts)
            : base(CoreLang.DungeonEntranceName, Guid.Empty, parts, StructureId)
        {
        }

        protected DungeonEntrance1()
        {
            //Protobuf-net constructor.
        }
    }
}