using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MLAPI.DataTypes;
using MLAPI.Filing.Logging;
using MLAPI.Util.Math;
using MLAPI.Util.RandomUtils;
using MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.Generation.Translator.ForceDirectedGraph
{
    /// <summary>
    /// Arranges the rooms and hallways via a force directed diagram algorithm.
    /// Borrows ideas and functions from:
    /// https://www.brad-smith.info/blog/archives/129
    /// </summary>
    public class PhysicsDirectedArranger : IDungeonGraphArranger
    {
        private static readonly int MaxNodeDispersal = 10000;
        private static readonly int MinNodeDispersal = 0;

        private const double ATTRACTION_CONSTANT = 0.1;		// spring constant
        private const double REPULSION_CONSTANT = 225;	// charge constant
        private const double DEFAULT_DAMPING = .5;
        private const int DEFAULT_SPRING_LENGTH = 200;
        private const int DEFAULT_MAX_ITERATIONS = 500;
        private List<DungeonTranslationNode> MNodes;

        public PhysicsDirectedArranger()
        {

        }

        public void Setup(List<DungeonTranslationNode> nodes)
        {
            this.MNodes = nodes;
            foreach (DungeonTranslationNode item in nodes)
            {
                int x = StaticRandom.Rand(MinNodeDispersal, MaxNodeDispersal);
                int y = StaticRandom.Rand(MinNodeDispersal, MaxNodeDispersal);
                item.Offset = new Point2D(x, y);
            }
        }

        public List<DungeonTranslationNode> Arrange(List<DungeonTranslationNode> nodes)
        {
            this.Arrange(DEFAULT_DAMPING, DEFAULT_SPRING_LENGTH, DEFAULT_MAX_ITERATIONS, true);
            return this.MNodes;
        }

        private void LogNodes(List<DungeonTranslationNode> nodes)
        {
            foreach (DungeonTranslationNode item in nodes)
            {
                string toLog = "Translation Node [" + item.DesignNode.NodeType.ToString() + "]" + ": " +
                               item.DesignNode.NodeId.ToString() + ", Location: " +
                               item.Offset.ToString();
                MasterLog.DebugWriteLine(toLog);
            }
        }

        /// <summary>
        /// Calculates the bearing angle from one point to another.
        /// Borrowed from:
        /// https://www.brad-smith.info/blog/archives/129
        /// </summary>
        /// <param name="start">The node that the angle is measured from.</param>
        /// <param name="end">The node that creates the angle.</param>
        /// <returns>The bearing angle, in degrees.</returns>
        private double GetBearingAngle(Point2D start, Point2D end)
        {
            Point2D half = new Point2D(start.X + ((end.X - start.X) / 2), start.Y + ((end.Y - start.Y) / 2));

            double diffX = (double)(half.X - start.X);
            double diffY = (double)(half.Y - start.Y);

            if (diffX == 0)
            {
                diffX = 0.001;
            }

            if (diffY == 0)
            {
                diffY = 0.001;
            }

            double angle;
            if (Math.Abs(diffX) > Math.Abs(diffY)) {
                angle = Math.Tanh(diffY / diffX) * (180.0 / Math.PI);
                if (((diffX < 0) && (diffY > 0)) || ((diffX < 0) && (diffY < 0)))
                {
                    angle += 180;
                }
            }
            else {
                angle = Math.Tanh(diffX / diffY) * (180.0 / Math.PI);
                if (((diffY < 0) && (diffX > 0)) || ((diffY < 0) && (diffX < 0)))
                {
                    angle += 180;
                }

                angle = (180 - (angle + 90));
            }

            return angle;
        } 
        
        /// <summary>
	    /// Runs the force-directed layout algorithm on this Diagram, using the specified parameters.
	    /// </summary>
	    /// <param name="damping">Value between 0 and 1 that slows the motion of the nodes during layout.</param>
	    /// <param name="springLength">Value in pixels representing the length of the imaginary springs that run along the connectors.</param>
	    /// <param name="maxIterations">Maximum number of iterations before the algorithm terminates.</param>
	    /// <param name="deterministic">Whether to use a random or deterministic layout.</param>
	    public void Arrange(double damping, int springLength, int maxIterations, bool deterministic) {
		    // random starting positions can be made deterministic by seeding System.Random with a constant
		    Random rnd = deterministic ? new Random(0) : new Random();

		    // copy nodes into an array of metadata and randomise initial coordinates for each node
		    NodeLayoutInfo[] layout = new NodeLayoutInfo[this.MNodes.Count];
		    for (int i = 0; i < this.MNodes.Count; i++) {
			    layout[i] = new NodeLayoutInfo(this.MNodes[i], new ForceVector(), Point2D.Zero);
			    layout[i].Node.Offset = new Point2D(rnd.Next(-50, 50), rnd.Next(-50, 50));
		    }

		    int stopCount = 0;
		    int iterations = 0;

		    while (true)
            {
                this.LogNodes(this.MNodes);
			    double totalDisplacement = 0;

			    for (int i=0; i<layout.Length; i++)
                {
				    NodeLayoutInfo current = layout[i];

				    // express the node's current position as a vector, relative to the origin
                    ForceVector currentPosition = new ForceVector(MathUtil.GetDistance(Point2D.Zero, current.Node.Offset), this.GetBearingAngle(Point2D.Zero, current.Node.Offset));
                    ForceVector netForce = new ForceVector(0, 0);

				    // determine repulsion between nodes
				    foreach (DungeonTranslationNode other in this.MNodes)
                    {
					    if (other != current.Node)
                        {
                            netForce += this.CalcRepulsionForce(current.Node, other);
                        }
                    }

                    List<DungeonTranslationNode> nodeConnections = this.GetConnections(current.Node);
                    // determine attraction caused by connections
				    foreach (DungeonTranslationNode child in nodeConnections)
                    {
					    netForce += this.CalcAttractionForce(current.Node, child, springLength);
				    }
				    foreach (DungeonTranslationNode parent in this.MNodes)
                    {
                        List<DungeonTranslationNode> parentConnections = this.GetConnections(parent);
					    if (parentConnections.Contains(current.Node))
                        {
                            netForce += this.CalcAttractionForce(current.Node, parent, springLength);
                        }
                    }

				    // apply net force to node velocity
				    current.Velocity = (current.Velocity + netForce) * damping;

				    // apply velocity to node position
				    current.NextPosition = (currentPosition + current.Velocity).ToPoint();
			    }

			    // move nodes to resultant positions (and calculate total displacement)
			    for (int i = 0; i < layout.Length; i++)
                {
				    NodeLayoutInfo current = layout[i];

				    totalDisplacement += MathUtil.GetDistance(current.Node.Offset, current.NextPosition);
				    current.Node.Offset = current.NextPosition;
			    }

			    iterations++;
			    if (totalDisplacement < 10)
                {
                    stopCount++;
                }

                if (stopCount > 15)
                {
                    break;
                }

                if (iterations > maxIterations)
                {
                    break;
                }
            }

		    // center the diagram around the origin
		    //Rectangle logicalBounds = GetDiagramBounds();
		    //Point midPoint = new Point(logicalBounds.X + (logicalBounds.Width / 2), logicalBounds.Y + (logicalBounds.Height / 2));

		    //foreach (DungeonTranslationNode node in this.mNodes)
      //      {
			   // node.Offset -= (Size)midPoint;
		    //}
	    }

        private List<DungeonTranslationNode> GetConnections(DungeonTranslationNode node)
        {
            List<DungeonTranslationNode> connections = new List<DungeonTranslationNode>();
            foreach (DungeonNode item in node.DesignNode.Connections)
            {
                DungeonTranslationNode foundNode = this.MNodes.Find(x => x.DesignNode.NodeId.Equals(item.NodeId));
                connections.Add(foundNode);
            }

            return connections;
        }

        /// <summary>
	    /// Calculates the attraction force between two connected nodes, using the specified spring length.
	    /// </summary>
	    /// <param name="x">The node that the force is acting on.</param>
	    /// <param name="y">The node creating the force.</param>
	    /// <param name="springLength">The length of the spring, in pixels.</param>
	    /// <returns>A Vector representing the attraction force.</returns>
	    private ForceVector CalcAttractionForce(DungeonTranslationNode x, DungeonTranslationNode y, double springLength) {
		    int proximity = (int)Math.Max(MathUtil.GetDistance(x.Offset, y.Offset), 1);

		    // Hooke's Law: F = -kx
		    double force = ATTRACTION_CONSTANT * Math.Max(proximity - springLength, 0);
		    double angle = this.GetBearingAngle(x.Offset, y.Offset);

		    return new ForceVector(force, angle);
	    }

        /// <summary>
	    /// Calculates the repulsion force between any two nodes in the diagram space.
	    /// </summary>
	    /// <param name="x">The node that the force is acting on.</param>
	    /// <param name="y">The node creating the force.</param>
	    /// <returns>A Vector representing the repulsion force.</returns>
	    private ForceVector CalcRepulsionForce(DungeonTranslationNode x, DungeonTranslationNode y)
        {
		    int proximity = (int)Math.Max(MathUtil.GetDistance(x.Offset, y.Offset), 1);

		    // Coulomb's Law: F = k(Qq/r^2)
		    double force = -(REPULSION_CONSTANT / Math.Pow(proximity, 2));
		    double angle = this.GetBearingAngle(x.Offset, y.Offset);

		    return new ForceVector(force, angle);
	    }

        /// <summary>
        /// Private inner class used to track the node's position and velocity during simulation.
        /// </summary>
        private class NodeLayoutInfo
        {
            public readonly DungeonTranslationNode Node; // reference to the node in the simulation
            public ForceVector Velocity; // the node's current velocity, expressed in vector form
            public Point2D NextPosition; // the node's position after the next iteration

            /// <summary>
            /// Initializes a new instance of the Diagram.NodeLayoutInfo class, using the specified parameters.
            /// </summary>
            /// <param name="node"></param>
            /// <param name="velocity"></param>
            /// <param name="nextPosition"></param>
            public NodeLayoutInfo(DungeonTranslationNode node, ForceVector velocity, Point2D nextPosition)
            {
                this.Node = node;
                this.Velocity = velocity;
                this.NextPosition = nextPosition;
            }
        }
    }
}
