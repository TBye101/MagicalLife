using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using MLCoreMod.Core.WorldGeneration.Dungeon.Constructors.Translator;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator.ForceDirectedGraph
{
    /// <summary>
    /// Used to hold vector data as well as its corrosponding <see cref="DungeonTranslationNode"/>.
    /// </summary>
    internal struct SimulationNode
    {
        public DungeonTranslationNode TranslationNode { get; set; }
        public Vector2 Force { get; set; }

        public SimulationNode(DungeonTranslationNode translationNode, Vector2 force)
        {
            this.TranslationNode = translationNode;
            this.Force = force;
        }
    }
}
