using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.DataTypes.Attribute;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.Entity.Eventing;
using MagicalLifeAPI.Entity.Skills;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Util.Reusable;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entity
{
    /// <summary>
    /// All living things inherit from this, and utilize it.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(8, typeof(Humanoid.Human))]
    public abstract class Living : Selectable
    {
        /// <summary>
        /// A queue that holds the queued movement steps up for this living creature.
        /// </summary>
        [ProtoMember(1)]
        public ProtoQueue<PathLink> QueuedMovement { get; set; } = new ProtoQueue<PathLink>();

        /// <summary>
        /// How many hit Point2Ds this creature has.
        /// </summary>
        [ProtoMember(2)]
        public Attribute32 Health { get; set; }

        /// <summary>
        /// How fast this creature can during a single tick.
        /// </summary>
        [ProtoMember(3)]
        public AttributeDouble Movement { get; set; }

        /// <summary>
        /// The location of the creature on the screen. This represents the progress through a tile for a moving creature.
        /// </summary>
        [ProtoMember(4)]
        public Point2DDouble TileLocation { get; set; }

        /// <summary>
        /// The dimension that this creature is in.
        /// </summary>
        [ProtoMember(5)]
        public int Dimension { get; set; }

        [ProtoMember(6)]
        public MagicalTask Task { get; set; }

        /// <summary>
        /// The ID of the player that this creature belongs to.
        /// </summary>
        [ProtoMember(7)]
        public Guid PlayerID { get; set; }

        [ProtoMember(9)]
        public TickTimer FootStepTimer { get; set; }

        [ProtoMember(10)]
        public Guid ID { get; }

        [ProtoMember(11)]
        public abstract AbstractVisual Visual { get; set; }

        [ProtoMember(12)]
        public List<Skill> CreatureSkills { get; set; }

        [ProtoMember(13)]
        public string CreatureTypeName { get; set; }

        [ProtoMember(14)]
        public string CreatureName { get; set; }

        [ProtoMember(15)]
        public Inventory Inventory { get; set; }

        /// <summary>
        /// Raised when a <see cref="Living"/> is created.
        /// </summary>
        public static event EventHandler<LivingEventArg> LivingCreated;

        /// <summary>
        /// Raised when this <see cref="Living"/> is modified.
        /// </summary>
        public event EventHandler<LivingEventArg> LivingModified;

        /// <param name="creatureTypeName">The name of our creature's type. Ex: Lion, Human, Robot.</param>
        /// <param name="creatureName">The name of this specific creature.</param>
        protected Living(int health, double movementSpeed, Point2D location,
            int dimension, Guid playerID, string creatureTypeName, string creatureName)
        {
            this.ID = Guid.NewGuid();
            this.PlayerID = playerID;
            this.Initialize(health, movementSpeed, location, dimension);
            this.CreatureSkills = new List<Skill>();
            this.CreatureName = creatureName;
            this.Inventory = new Inventory(true);
        }

        protected void Initialize(int health, double movementSpeed, Point2D location, int dimension)
        {
            this.Health = new Attribute32(health);
            this.Movement = new AttributeDouble(movementSpeed);
            this.MapLocation = location;
            this.TileLocation = new Point2DDouble(location.X, location.Y);
            this.Dimension = dimension;
            Living.LivingCreatedHandler(new LivingEventArg(this, location));
            this.FootStepTimer = new TickTimer(5);
        }

        public Living()
        {
        }

        public void AssignTask(MagicalTask task)
        {
            this.Task = task;
            this.Task.Completed += this.Task_Completed;
        }

        private void Task_Completed(MagicalTask task)
        {
            this.Task = null;
        }

        /// <summary>
        /// Returns the name of the texture.
        /// </summary>
        /// <returns></returns>
        public abstract string GetTextureName();

        /// <summary>
        /// Raises the <see cref="LivingModified"/> event.
        /// </summary>
        /// <param name="e"></param>
        public void LivingModifiedHandler(LivingEventArg e)
        {
            LivingModified?.Invoke(e.Living, e);
        }

        /// <summary>
        /// Raises the <see cref="LivingCreated"/> event.
        /// </summary>
        /// <param name="e"></param>
        public static void LivingCreatedHandler(LivingEventArg e)
        {
            LivingCreated?.Invoke(e.Living, e);
        }
    }
}