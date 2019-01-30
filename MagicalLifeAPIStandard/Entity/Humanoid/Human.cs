using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Visual.Rendering.Animation;
using MagicalLifeAPI.World.Items;
using MagicalLifeSettings;
using ProtoBuf;
using System;
using System.Reflection;

namespace MagicalLifeAPI.Entity.Humanoid
{
    /// <summary>
    /// A class that holds logic for control of regular humans.
    /// </summary>
    [ProtoContract]
    public class Human : Living
    {
        private static readonly int[] DownSequenceFrames = { 0, 1, 0, 2 };
        private static readonly int[] LeftSequenceFrames = { 3, 4, 3, 5 };
        private static readonly int[] RightSequenceFrames = { 6, 7, 6, 8 };
        private static readonly int[] UpSequenceFrames = { 9, 10, 9, 11 };

        /// <summary>
        /// The ID of the animation sequences that can be triggered.
        /// </summary>
        public static readonly int DownSequence;

        /// <summary>
        /// The ID of the animation sequences that can be triggered.
        /// </summary>
        public static readonly int LeftSequence = 1;

        /// <summary>
        /// The ID of the animation sequences that can be triggered.
        /// </summary>
        public static readonly int RightSequence = 2;

        /// <summary>
        /// The ID of the animation sequences that can be triggered.
        /// </summary>
        public static readonly int UpSequence = 3;

        public override AbstractVisual Visual { get; set; }

        public Human(int health, float movementSpeed, Point2D location, int dimension, Guid playerID, string creatureName)
            : base(health, movementSpeed, location, dimension, playerID, "Human", creatureName)
        {
            Filing.Logging.MasterLog.DebugWriteLine("Living spawned at: " + location.ToString());
            this.Visual = new AnimatedTexture(RenderLayer.Character, this.GetSequences(),
                TextureLoader.AnimationBaseCharacter,
                XMLPaths.BaseCharacterSpriteSheet, Assembly.GetAssembly(typeof(AssemblyGetter)));
            this.Inventory.AddItem(new Log(15, 30));
            this.Inventory.AddItem(new StoneRubble(25));
        }

        public Human() : base()
        {
        }

        public override string GetTextureName()
        {
            return "Character/Character";
        }

        private AnimationSequence[] GetSequences()
        {
            int fps = 3;

            AnimationSequence down = new AnimationSequence(Human.DownSequenceFrames, fps);
            AnimationSequence left = new AnimationSequence(Human.LeftSequenceFrames, fps);
            AnimationSequence right = new AnimationSequence(Human.RightSequenceFrames, fps);
            AnimationSequence up = new AnimationSequence(Human.UpSequenceFrames, fps);

            AnimationSequence[] sequences = { down, left, right, up };

            return sequences;
        }

        public override SelectionType InGameObjectType(Selectable selectable)
        {
            return SelectionType.Creature;
        }
    }
}