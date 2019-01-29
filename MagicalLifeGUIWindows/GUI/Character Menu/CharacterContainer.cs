using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Entity;
using MagicalLifeGUIWindows.GUI.Character_Menu.Buttons;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Reusable.API;
using MagicalLifeGUIWindows.GUI.Reusable.Premade;
using MagicalLifeGUIWindows.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.GUI.Character_Menu
{
    public class CharacterContainer : GUIContainer
    {
        public WindowX X { get; set; }
        public MonoLabel CharacterName { get; set; }

        public ListBox Skills { get; set; }

        public InventoryTabButton InventoryButton { get; set; } = new InventoryTabButton();
        public SkillsTabButton SkillsButton { get; set; } = new SkillsTabButton();

        private static readonly SpriteFont ItemFont = Game1.AssetManager.Load<SpriteFont>(TextureLoader.FontMainMenuFont12x);

        /// <summary>
        /// The creature that has information being displayed about it.
        /// </summary>
        public Living Creature { get; set; }

        /// <param name="creature">The creature that has information being displayed about it.</param>
        public CharacterContainer(Living creature) : base(TextureLoader.GUIMenuBackground, CharacterMenuLayout.GetMenuBounds(), true)
        {
            this.Creature = creature;

            this.X = new WindowX(new MagicalLifeAPI.DataTypes.Point2D(this.DrawingBounds.Width, this.DrawingBounds.Height));
            this.X.XClicked += this.X_XClicked;
            this.CharacterName = new MonoLabel(CharacterMenuLayout.GetNameBounds(), TextureLoader.GUIMenuBackground, true, creature.CreatureName);
            this.Skills = this.InitializeSkills(creature);

            this.Controls.Add(this.X);
            this.Controls.Add(this.CharacterName);
            this.Controls.Add(this.Skills);
            this.Controls.Add(this.InventoryButton);
            this.Controls.Add(this.SkillsButton);
        }

        private ListBox InitializeSkills(Living creature)
        {
            List<GUIElement> skills = new List<GUIElement>();

            foreach (MagicalLifeAPI.Entity.Skills.Skill item in creature.CreatureSkills)
            {
                string skillText = "" + item.DisplayName + ": ("
                    + item.SkillAmount.GetValue().ToString() + "), ";

                if (item.Learnable)
                {
                    skillText += item.Experience.CurrentXP.ToString()
                        + "/" + item.Experience.NextLevelXPRequired.ToString() + "XP";
                }
                else
                {
                    skillText += "Not Able to Learn";
                }

                RenderableString result = new RenderableString(ItemFont, skillText);
                skills.Add(result);
            }

            return new ListBox(
                CharacterMenuLayout.GetSkillsBounds(),
                int.MaxValue, true,
                TextureLoader.FontMainMenuFont12x, 10, skills);
        }

        private void X_XClicked(object sender, EventArgs e)
        {
            BoundHandler.RemoveContainer(this);
        }

        public override string GetTextureName()
        {
            return TextureLoader.GUIMenuBackground;
        }

        public void HideAllControls()
        {
            foreach (GUIElement item in this.Controls)
            {
                item.Visible = false;
            }
        }
    }
}