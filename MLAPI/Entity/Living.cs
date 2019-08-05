using System;
using System.Collections.Generic;
using MLAPI.Components;
using MLAPI.Components.Entity;
using MLAPI.DataTypes;
using MLAPI.DataTypes.Attribute;
using MLAPI.Entity.AI.Task;
using MLAPI.Entity.Eventing;
using MLAPI.Entity.Skills;
using MLAPI.Visual;
using MLAPI.Visual.Rendering;
using ProtoBuf;

namespace MLAPI.Entity
{
    /// <summary>
    /// All living things inherit from this, and utilize it.
    /// </summary>
    [ProtoContract]
    public abstract class Living : HasComponents
    {
        /// <summary>
        /// How many hit points this creature has.
        /// </summary>
        [ProtoMember(1)]
        public Attribute32 Health { get; set; }

        /// <summary>
        /// The dimension that this creature is in.
        /// </summary>
        [ProtoMember(2)]
        public Guid DimensionId { get; set; }

        [ProtoMember(3)]
        public MagicalTask Task { get; set; }

        /// <summary>
        /// The ID of the player that this creature belongs to.
        /// </summary>
        [ProtoMember(4)]
        public Guid PlayerId { get; set; }

        [ProtoMember(5)]
        public Guid Id { get; }

        [ProtoMember(6)]
        public abstract AbstractVisual Visual { get; set; }

        [ProtoMember(7)]
        public List<Skill> CreatureSkills { get; set; }

        [ProtoMember(8)]
        public string CreatureTypeName { get; set; }

        [ProtoMember(9)]
        public string CreatureName { get; set; }

        [ProtoMember(10)]
        public Inventory Inventory { get; set; }

        /// <summary>
        /// Raised when a <see cref="Living"/> is created.
        /// </summary>
        public static event EventHandler<LivingEventArg> LivingCreated;

        /// <summary>
        /// Raised when this <see cref="Living"/> is modified.
        /// </summary>
        public event EventHandler<LivingEventArg> LivingModified;

        /// <summary>
        ///
        /// </summary>
        /// <param name="health"></param>
        /// <param name="movementSpeed"></param>
        /// <param name="location"></param>
        /// <param name="dimension"></param>
        /// <param name="playerId"></param>
        /// <param name="creatureTypeName">The name of our creature's type. Ex: Lion, Human, Robot.</param>
        /// <param name="creatureName">The name of this specific creature.</param>
        protected Living(int health, double movementSpeed, Point3D location,
            Guid dimensionId, Guid playerId, string creatureTypeName, string creatureName)
            : base(true)
        {
            this.AddComponent(new ComponentSelectable(SelectionType.Creature));
            this.AddComponent(new ComponentMovement(movementSpeed, location));

            this.Id = Guid.NewGuid();
            this.PlayerId = playerId;
            this.Initialize(health, movementSpeed, location, dimensionId);
            this.CreatureSkills = new List<Skill>();
            this.CreatureTypeName = creatureTypeName;
            this.CreatureName = creatureName;
            this.Inventory = new Inventory(true);
        }

        protected Living()
        {
        }

        protected void Initialize(int health, double movementSpeed, Point3D location, Guid dimensionId)
        {
            this.Health = new Attribute32(health);
            this.GetExactComponent<ComponentSelectable>().MapLocation = location;
            this.DimensionId = dimensionId;
            LivingCreatedHandler(new LivingEventArg(this, location));
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