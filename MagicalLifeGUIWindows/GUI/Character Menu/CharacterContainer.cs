using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Base;
using MagicalLifeGUIWindows.GUI.Character_Menu.Buttons;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Reusable.Premade;
using MagicalLifeGUIWindows.Input;
using Microsoft.Xna.Framework;
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

        public ScrollableGrid Inventory { get; set; }

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
            this.X.ClickEvent += this.X_ClickEvent;
            this.CharacterName = new MonoLabel(CharacterMenuLayout.GetNameBounds(), TextureLoader.GUIMenuBackground, true, creature.CreatureName);
            this.Skills = this.InitializeSkills(creature);
            this.Inventory = this.InitializeInventory(creature);
            this.Inventory.Visible = false;

            this.Controls.Add(this.X);
            this.Controls.Add(this.CharacterName);
            this.Controls.Add(this.Skills);
            this.Controls.Add(this.InventoryButton);
            this.Controls.Add(this.SkillsButton);
            this.Controls.Add(this.Inventory);
        }

        private void X_ClickEvent(object sender, Reusable.Event.ClickEventArgs e)
        {
            BoundHandler.RemoveContainer(this);
        }

        /// <summary>
        /// Counts how many items there are in all of the stacks.
        /// </summary>
        /// <param name="stacks"></param>
        /// <returns></returns>
        private int CountAllItems(List<Item> stacks)
        {
            int count = 0;
            foreach (Item item in stacks)
            {
                count += item.CurrentlyStacked;
            }

            return count;
        }

        private ScrollableGrid InitializeInventory(Living creature)
        {
            ScrollableGrid grid = new ScrollableGrid(4, CharacterMenuLayout.GetInventoryBounds(), int.MaxValue, true, TextureLoader.FontMainMenuFont12x, 10);

            Dictionary<int, List<Item>> inventoryItems = creature.Inventory.GetAllInventoryItems();
            foreach (KeyValuePair<int, List<Item>> item in inventoryItems)
            {
                int itemCount = this.CountAllItems(item.Value);

                Rectangle imageBounds = new Rectangle(0, 0, 32, 32);
                RenderableImage itemImage = new RenderableImage(imageBounds, item.Value[0].TextureName, true);
                RenderableString itemName = new RenderableString(ItemFont, item.Value[0].Name, Rendering.Text.SimpleTextRenderer.Alignment.Left);

                double stackWeight = item.Value[0].ItemWeight * itemCount;
                RenderableString itemWeight = new RenderableString(ItemFont, "Weight: " + stackWeight.ToString(), Rendering.Text.SimpleTextRenderer.Alignment.Left);

                RenderableString itemNumber = new RenderableString(ItemFont, "Count: " + itemCount.ToString(), Rendering.Text.SimpleTextRenderer.Alignment.Right);

                grid.Add(0, itemImage);
                grid.Add(1, itemName);
                grid.Add(2, itemWeight);
                grid.Add(3, itemNumber);
            }

            return grid;
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

                RenderableString result = new RenderableString(ItemFont, skillText, Rendering.Text.SimpleTextRenderer.Alignment.Center);
                skills.Add(result);
            }

            return new ListBox(
                CharacterMenuLayout.GetSkillsBounds(),
                int.MaxValue, true,
                TextureLoader.FontMainMenuFont12x, 10, skills);
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