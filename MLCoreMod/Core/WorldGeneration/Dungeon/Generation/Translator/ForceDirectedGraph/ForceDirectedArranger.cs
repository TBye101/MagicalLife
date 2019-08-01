using MagicalLifeAPI.DataTypes.R;
using MagicalLifeAPI.Util;
using Microsoft.Xna.Framework;
using MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator.ForceDirectedGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Constructors.Translator.ForceDirectedGraph
{
    public class ForceDirectedArranger : IDungeonGraphArranger
    {
        private static readonly int AttractionDistance = 1000;
        private static readonly int ConnectedRepulsionDistance = 2;
        private static readonly int UnconnectedRepulsionDistance = 10;
        private static readonly int MaxAttraction = 100;
        private static readonly int MaxRepulsion = 110;
        //private static readonly int SimulationTimeOut = 10000;

        public ForceDirectedArranger()
        {
        }

        public Dictionary<Guid, DungeonTranslationNode> Arrange(Dictionary<Guid, DungeonTranslationNode> nodes)
        {
            List<SimulationNode> tempNodeChanges = this.CalculateSystemChanges(nodes);
            this.ApplySystemChanges(nodes, tempNodeChanges);

            //Is system in equilibrium?
            if (tempNodeChanges.Count < 1)
            {
                return nodes;
            }
            else
            {
                //Keep running the simulation
                return this.Arrange(nodes);
            }
        }

        private void ApplySystemChanges(Dictionary<Guid, DungeonTranslationNode> nodes, List<SimulationNode> tempNodeChanges)
        {
            for (int i = 0; i < tempNodeChanges.Count; i++)
            {
                SimulationNode changesNode = tempNodeChanges[i];
                DungeonTranslationNode translationNode = nodes[changesNode.TranslationNode.DesignNode.NodeID];
                translationNode.SectionXOffset += (int)changesNode.Force.X;
                translationNode.SectionYOffset += (int)changesNode.Force.Y;
            }
        }

        private List<SimulationNode> CalculateSystemChanges(Dictionary<Guid, DungeonTranslationNode> nodes)
        {
            List<SimulationNode> simulationNodes = new List<SimulationNode>();

            foreach (KeyValuePair<Guid, DungeonTranslationNode> item in nodes)
            {
                Vector2 forces = this.CalculateForcesOnNode(item.Value, nodes);

                if (!forces.Equals(Vector2.Zero))
                {
                    SimulationNode changesNode = new SimulationNode(item.Value, forces);
                    simulationNodes.Add(changesNode);
                }
            }

            return simulationNodes;
        }

        private Vector2 CalculateForcesOnNode(DungeonTranslationNode translationNode, Dictionary<Guid, DungeonTranslationNode> nodes)
        {
            List<Vector2> forces = new List<Vector2>();

            foreach (KeyValuePair<Guid, DungeonTranslationNode> item in nodes)
            {
                Vector2 force = this.CalculateForce(translationNode, item);

                if (!force.Equals(Vector2.Zero))
                {
                    forces.Add(force);
                }
            }

            return this.CombineForces(forces);
        }

        private Vector2 CombineForces(List<Vector2> forces)
        {
            Vector2 combinedVector = Vector2.Zero;

            for (int i = 0; i < forces.Count; i++)
            {
                Vector2 force = forces[i];
                combinedVector = Vector2.Add(combinedVector, force);
            }

            return Vector2.Divide(combinedVector, forces.Count);
        }

        private Vector2 CalculateForce(DungeonTranslationNode translationNode, KeyValuePair<Guid, DungeonTranslationNode> item)
        {
            int xDif = item.Value.SectionXOffset.Value - translationNode.SectionXOffset.Value;
            int yDif = item.Value.SectionYOffset.Value - translationNode.SectionYOffset.Value;
            double radianAngle = Math.Atan2(yDif, xDif);
            int distance = (int)MathUtil.GetDistance(translationNode.SectionXOffset.Value, translationNode.SectionYOffset.Value, item.Value.SectionXOffset.Value, item.Value.SectionYOffset.Value);

            if (this.IsAttracting(translationNode, item.Value))
            {
                return this.CalculateAttraction(radianAngle, distance);
            }
            if (this.IsRepulsing(translationNode, item.Value))
            {
                return this.CalculateRepulsion(radianAngle, distance);
            }

            return Vector2.Zero;
        }

        private Vector2 CalculateAttraction(double radianAngle, int distance)
        {
            distance = Math.Max(distance, 1);
            double totalAttraction = (AttractionDistance / distance) * MaxAttraction;
            float xForce = (float)(totalAttraction * Math.Cos(totalAttraction));
            float yForce = (float)(totalAttraction * Math.Sin(totalAttraction));
            return new Vector2(xForce, yForce);
        }

        private Vector2 CalculateRepulsion(double radianAngle, int distance)
        {
            distance = Math.Max(distance, 1);
            double totalRepulsion = (UnconnectedRepulsionDistance / distance) * MaxRepulsion;
            float xForce = (float)(totalRepulsion * Math.Cos(totalRepulsion));
            float yForce = (float)(totalRepulsion * Math.Sin(totalRepulsion));
            return new Vector2(xForce * -1, yForce * -1);
        }

        /// <summary>
        /// Returns true if the <paramref name="node"/> is repulsing to the <paramref name="translationNode"/>.
        /// Doesn't account for connected nodes, so <see cref="IsAttracting(DungeonTranslationNode, DungeonTranslationNode)"/> should be called first when determining node force type.
        /// </summary>
        /// <param name="translationNode"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool IsRepulsing(DungeonTranslationNode translationNode, DungeonTranslationNode node)
        {
            int distance = (int)MathUtil.GetDistance(translationNode.SectionXOffset.Value, translationNode.SectionYOffset.Value, node.SectionXOffset.Value, node.SectionYOffset.Value);

            return distance < UnconnectedRepulsionDistance;
        }

        /// <summary>
        /// Returns true if the <paramref name="node"/> is attracting to the <paramref name="translationNode"/>.
        /// </summary>
        /// <param name="translationNode"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool IsAttracting(DungeonTranslationNode translationNode, DungeonTranslationNode node)
        {
            if (translationNode.DesignNode.Connections.Contains(node.DesignNode))
            {
                int distance = (int)MathUtil.GetDistance(translationNode.SectionXOffset.Value, translationNode.SectionYOffset.Value, node.SectionXOffset.Value, node.SectionYOffset.Value);

                return distance < AttractionDistance && distance > ConnectedRepulsionDistance;
            }

            return false;
        }
    }
}
